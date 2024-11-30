use db20172001423
go
drop proc spFamiliaSelect
go
create proc spFamiliaSelect @FamiliaID int = 0
as
	select *from Familia where FamiliaID = @FamiliaID or @FamiliaID = 0
go
