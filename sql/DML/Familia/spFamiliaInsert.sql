use db20172001423
go
drop proc spFamiliaInsert
go
create proc spFamiliaInsert @FamiliaID int output, @Nombre varchar(50)
as
	select @FamiliaID = ISNULL(max(familiaID),0) + 1 from Familia

	insert into Familia values (@FamiliaID, @Nombre)
go
