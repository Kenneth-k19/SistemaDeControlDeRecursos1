USE DB20172001423

select * from Proveedor
select * from Compra
exec spCompraTotaleSelect 
select * from CompraDet
select * from vValores
GO


alter procedure spCompraTotaleSelect @compraID int = 0
AS
	select * into #compra from Compra where CompraID= @compraID or @compraID = 0
	select * into #compradetalle from CompraDet where CompraID in (select CompraID from #compra)
	select * into #usuario from Usuario where UsuarioID in (select UsuarioID from #compra)
	select * into #proveedor from Proveedor where ProveedorID in (select ProveedorID from #compra)
	select * into #valores from vValores where Tabla = 'Compra'

	select c.Codigo,u.Nombre as 'Ingresado Por',  c.Fecha, v.Valor as 'Tipo de Compra', c.Documento,
		case c.Estado when 1 then 'Finalizada' else 'Guardada' end as Estado,
		p.Nombre as Proveedor,
		'L ' + cast(isnull(cast(SUM(cd.Cantidad * cd.Precio * (1+cd.Impuesto - cd.Descuento)) as decimal(7,2)),0) as varchar) as 'Valor Total'
	from #compra as c
	left join #compradetalle as cd on c.CompraID = cd.CompraID
	left join #usuario as u on u.UsuarioID = c.UsuarioID
	left join #proveedor as p on p.ProveedorID = c.ProveedorID
	left join #valores as v on v.Codigo = c.Tipo
	group by c.Codigo, p.Nombre, c.Fecha, v.Valor, c.Documento, c.Estado, u.Nombre

	exec spCompraTotaleSelect 

