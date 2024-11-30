use db20172001423
go
drop proc spFamiliaUpdate
go
create proc spFamiliaUpdate @FamiliaID int, @Nombre varchar(50)
as
	update Familia set Nombre = @Nombre where FamiliaID = @FamiliaID
go
