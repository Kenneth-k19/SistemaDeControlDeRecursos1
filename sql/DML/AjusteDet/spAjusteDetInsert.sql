use DB20172001423
go
drop proc spAjusteDetInsert
go
create proc spAjusteDetInsert @AjusteDetID int,@AjusteID int, @ArticuloID int,@Cantidad int,@TipoAjusteID int
as
	select @AjusteDetID = ISNULL(max(ajusteDetID),0)+1 from AjusteDet

	insert into AjusteDet values (@AjusteDetID, @AjusteID,@ArticuloID,@Cantidad,null,@TipoAjusteID)
go
