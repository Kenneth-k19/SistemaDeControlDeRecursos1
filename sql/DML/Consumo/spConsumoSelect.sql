use DB20172001423
go
drop procedure spConsumoSelect 
go
create procedure spConsumoSelect @ConsumoID int = 0
as
	select *into #Consumo from Consumo where ConsumoID = @ConsumoID or @ConsumoID = 0
	select *into #Articulo from Articulo where articuloID in (select ArticuloID from #Consumo)
	select *into #Familia from Familia where FamiliaID in (select FamiliaID from #Articulo)

	select c.ConsumoID, a.ArticuloID,a.Codigo, a.Nombre Articulo, a.Precio, c.Observacion
	from #Consumo c
	inner join #Articulo a on a.ArticuloID = c.ArticuloID
	inner join #Familia f on f.FamiliaID = a.FamiliaID
go
exec spConsumoSelect 0

select *from Articulo where tipo = 'V'