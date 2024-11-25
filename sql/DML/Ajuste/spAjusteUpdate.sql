use db20172001423
go
drop proc spAjusteUpdate
go
create proc spAjusteUpdate @AjusteID int, @Fecha datetime, @PeriodoID int output,@UsuarioID int,@Tipo varchar,@Observacion varchar(100),@Estado varchar
as
	select @PeriodoID = PeriodoID from periodo where @Fecha between Inicio and Final

	update Ajuste set Fecha = @Fecha, PeriodoID = @PeriodoID, UsuarioID = @UsuarioID, Tipo = @Tipo, Observacion = @Observacion, Estado = @Estado
		where AjusteID = @AjusteID

go

--exec spAjusteInsert 1,'2024-11-23',1,1,'I','Inventario Inicial','S'