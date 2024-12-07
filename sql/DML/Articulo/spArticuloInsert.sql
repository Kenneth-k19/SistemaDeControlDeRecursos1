use db20172001423
go
drop procedure spArticuloInsert
go
create procedure spArticuloInsert @ArticuloID int output,@Codigo varchar(5), @Nombre varchar(100),@Tipo varchar,@FamiliaID int,
	@precio float,@unidadID int, @Inventario bit, @observacion varchar(200), @minimo int = 0
as
	select @ArticuloID = ISNULL(max(articuloID),0) + 1 from Articulo

	insert into Articulo values(@ArticuloID,@Codigo, @Nombre,@Tipo,@FamiliaID,@precio,@unidadID,@Inventario,@observacion,GETDATE(),@minimo,GETDATE())

go

select *from articulo