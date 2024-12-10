use DB20172001423
go
drop procedure spConsumoDetSelect
go
create procedure spConsumoDetSelect @ConsumoID int
as
	select *into #ConsumoDet from ConsumoDet where ConsumoID = @ConsumoID or @ConsumoID = 0
	select *into #Articulo from Articulo where articuloID in (select ArticuloID from #ConsumoDet)
	select *into #Familia from Familia where FamiliaID in (select FamiliaID from #Articulo)

	select c.ConsumoDetID,c.ConsumoID,c.ArticuloID,a.Codigo, a.Nombre Articulo, f.Nombre Familia
	from #ConsumoDet c
	inner join #Articulo a on a.ArticuloID = c.ArticuloID
	inner join #Familia f on f.FamiliaID = a.FamiliaID
go

exec spConsumoDetSelect 1