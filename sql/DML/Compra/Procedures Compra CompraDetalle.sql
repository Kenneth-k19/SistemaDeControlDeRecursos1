USE DB20172001423


select * from FacturaDet
select * from Periodo where GETDATE() between Inicio and Final
select * from Existencia
select * from Proveedor
select * from Compra
exec spCompraTotaleSelect 
select * from CompraDet
select * from Articulo
select * from vValores
select * from Unidad
GO

CREATE FUNCTION dbo.fCalcularPkCompra() returns int
AS
	BEGIN
		DECLARE @pk INT

		SELECT @pk = ISNULL(MAX(CompraID),0) + 1 FROM Compra

		return @pk
	END

alter Function dbo.fCalcularCodigoCompra() returns varchar(20)
AS
	BEGIN
		declare @compraid int, @codigo varchar(20)

		select @compraID = dbo.fCalcularPkCompra()

		select @codigo = 'COM' + RIGHT('0000' + CAST(@compraid AS VARCHAR), 4)

		return @codigo
	END

	select * from Compra

alter procedure spCompraInsert @proveedorID int, @fecha datetime, @tipo varchar(1), @documento varchar(20), @estado varchar(1), @usuarioID int
AS
	BEGIN
		declare @compraID int, @codigo varchar(20)
		select @compraID = dbo.fCalcularPkCompra();
		select @codigo = dbo.fCalcularCodigoCompra();

		insert into Compra (CompraID, Codigo, ProveedorID, Fecha, Tipo, Documento, Estado, UsuarioID)
		values
			(@compraID, @codigo, @proveedorID, GETDATE(), @tipo, @documento, @estado, @usuarioID)

	END

alter PROCEdUrE spCompraUpdate @codigo varchar(20), @proveedorID int, @tipo varchar(1), @documento varchar(20), @estado varchar(1), @usuarioID int
AS
	BEGIN
		update Compra
			set ProveedorID = @proveedorID, Tipo= @tipo, Documento = @documento, Estado = @estado, UsuarioID = @usuarioID
		Where Codigo = @codigo

	END

alter procedure spCompraDetalleSelect @codigoCompra varchar(20)
AS
	Begin
		declare @compraID int

		select @compraID = CompraID from Compra where Codigo = @codigoCompra

		select * into #compradetalle from CompraDet where CompraID = @compraID
		select * into #articulo from Articulo where ArticuloID in (select ArticuloID from #compradetalle)
		select * into #unidad from Unidad where UnidadID in (select UnidadID from #articulo)


		select cd.CompraDetID, a.Nombre as Articulo, (cast(cd.Cantidad as varchar) + ' ' +u.Nombre) as Cantidad, 'L ' + cast( cast(cd.Precio as decimal(7,2)) as varchar) as Precio, 
				cd.Descuento, cd.Impuesto  from
		#compradetalle as cd
		inner join #articulo as a on a.ArticuloID =  cd.ArticuloID
		inner join #unidad as u	 on u.UnidadID = a.UnidadID

	END

	spCompraDetalleSelect '1'

ALTER procedure spCompraDetalleInsert @codigo varchar(20), @articuloID int, @cantidad int, @precio float, @descuento float, @impuesto float
AS
	BEGIN
		declare @compraid int, @compradetalleid int;

		select @compraid = CompraID from Compra where Codigo = @codigo

		select @compradetalleid = isnull(max(CompraDetID), 0)+1 from CompraDet

		insert into CompraDet (CompraDetID, CompraID, ArticuloID, Cantidad, Precio, Descuento, Impuesto)
		values
			(@compradetalleid, @compraid, @articuloID, @cantidad, @precio, @descuento, @impuesto)

			--@compradetid int, @compraid int, @articuloid int, @cantidad int
		exec spInsertarExistenciaCompra @compradetalleid, @compraid, @articuloID, @cantidad
	END

ALTER procedure spCompraDetalleUpdate @codigo varchar(20), @articuloID int, @cantidad int, @precio float, @descuento float, @impuesto float
AS
	BEGIN
		declare @compraid int, @compradetalleid int;

		select @compraid = CompraID from Compra where Codigo = @codigo

		select @compradetalleid = CompraDetID from CompraDet where CompraID = @compraid and ArticuloID = @articuloID

		Update CompraDet
		set ArticuloID = @articuloID, Cantidad = @cantidad, Precio = @precio, Descuento= @descuento, Impuesto = @impuesto
		where CompraDetID = @compradetalleid

	END

ALTER procedure spCompraDetalleDelete @compradetalleid int
AS
	Delete from CompraDet
	where CompraDetID = @compradetalleid

	EXEC spEximinarExistenciaCompra @compradetalleid


alter PROCEDURE spInsertarExistenciaCompra @compradetid int, @compraid int, @articuloid int, @cantidad int
AS
	declare @periodoid int, @existenciaid int, @fechaperiodo date

	select @existenciaid = ISNULL(max(ExistenciaID), 0) +1 from Existencia

	select @fechaperiodo = Fecha from Compra where CompraID = @compraid

	select @periodoid = PeriodoID from Periodo where @fechaperiodo between Inicio and Final

	insert into Existencia(ExistenciaID, PeriodoID, ArticuloID, Compras, CompraDetID)
	values(@existenciaid, @periodoid, @articuloid, @cantidad, @compradetid)

CREATE PROCEDURE spEximinarExistenciaCompra @compradetid int
AS
	delete from Existencia
	where CompraDetID = @compradetid

	select getdate()

	select * from Articulo
	

	ALTER TABLE Compra ALTER COLUMN Estado VARCHAR(1);
	ALTER TABLE Compra ALTER COLUMN Codigo VARCHAR(7);
	Alter table Existencia ADD CompraDetID int