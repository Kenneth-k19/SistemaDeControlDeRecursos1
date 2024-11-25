use db20172001423
go
drop proc spAjusteInsert
go
create proc spAjusteInsert @AjusteID int output, @Fecha datetime, @PeriodoID int output,@UsuarioID int,@Observacion varchar(100),@Estado varchar
as
	select @AjusteID = ISNULL(max(ajusteID),0) +1 from Ajuste
	select @PeriodoID = periodoID from Periodo where @Fecha between Inicio and Final
	Insert into Ajuste values (@AjusteID, @Fecha,@PeriodoID,@UsuarioID,@Observacion,@Estado)

go

--exec spAjusteInsert 1,'2024-11-23',1,1,'I','Inventario Inicial','S'
exec spAjusteInsert 2,'2024-11-24',1,2,'Proceso de pollo','S'