use DB20172001423
go
drop proc spAjusteDetUpdate
go
create proc spAjusteDetUpdate @AjusteDetID int,@AjusteID int, @ArticuloID int,@Cantidad int,@TipoAjusteID int
as
	update AjusteDet set AjusteID = @AjusteID,  ArticuloID = @ArticuloID, Cantidad = @Cantidad, TipoAjusteID = @TipoAjusteID
		where AjusteDetID = @AjusteDetID
go
