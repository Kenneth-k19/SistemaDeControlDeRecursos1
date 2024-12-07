use DB20172001423
go
drop proc spAjusteDetSelect
go
create proc spAjusteDetSelect @AjusteID int
as
	select *into #AjusteDet from AjusteDet where AjusteID = @AjusteID
	select *into #Articulo from Articulo where ArticuloID in (select articuloID from #AjusteDet)

	select AjusteDetID, AjusteID,ad.ArticuloID,a.Nombre Articulo,Cantidad, ta.TipoAjusteID,ta.Nombre TipoAjuste
	from #AjusteDet ad
	inner join TipoAjuste ta on ta.TipoAjusteID = ad.TipoAjusteID
	inner join #Articulo a on a.articuloID = ad.ArticuloID
go

exec spAjusteDetSelect 1