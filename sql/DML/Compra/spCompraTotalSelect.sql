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
	select * into #tipo from vValores where Tabla = 'Compra' and Columna = 'Tipo'
	select * into #estado from vValores where Tabla = 'Compra' and Columna = 'Estado'

	select c.Codigo,u.Nombre as 'Ingresado Por',  c.Fecha, t.Valor as 'Tipo de Compra', c.Documento,
		e.Valor as 'Estado',
		p.Nombre as Proveedor,
		'L ' + cast(isnull(cast(SUM(cd.Cantidad * cd.Precio * (1+cd.Impuesto - cd.Descuento)) as decimal(7,2)),0) as varchar) as 'Valor Total'
	from #compra as c
	left join #compradetalle as cd on c.CompraID = cd.CompraID
	left join #usuario as u on u.UsuarioID = c.UsuarioID
	left join #proveedor as p on p.ProveedorID = c.ProveedorID
	left join #tipo as t on t.Codigo = c.Tipo
	left join #estado as e on e.Codigo = c.Estado
	group by c.Codigo, p.Nombre, c.Fecha, t.Valor, e.Valor, c.Documento, c.Estado, u.Nombre

	exec spCompraTotaleSelect 

	spSelectFactura