use db20172001423
go
drop procedure spArticuloUpdate
go
create procedure spArticuloUpdate @ArticuloID int output,@Codigo varchar(5), @Nombre varchar(100),@Tipo varchar,@FamiliaID int,
	@precio float,@unidadID int, @Inventario bit, @observacion varchar(200), @minimo int
as
	update Articulo set Codigo = @Codigo, Nombre = @Nombre, Tipo = @Tipo, FamiliaID = @FamiliaID, Precio = @precio
	,UnidadID = @unidadID, Inventario = @Inventario, Observacion = @observacion, minimo = @minimo
	where ArticuloID = @ArticuloID
go


