use db20172001423
go
drop procedure spArticuloSelect
go
create procedure spArticuloSelect @ArticuloID int=0
as
	select *, case Tipo when 'C' then 'Consumo' when 'V' then 'Venta' end as nomTipo
		into #Articulo from Articulo where articuloID = @ArticuloID or @ArticuloID = 0
	select * into #Unidad from Unidad where UnidadID in (select UnidadID from #Articulo)
	select * into #Fam from Familia where FamiliaID in (select FamiliaID from #Articulo)

	select a.ArticuloID,a.Codigo,a.Nombre nomArticulo,a.Tipo codTipo, a.nomTipo,a.Precio
	,f.FamiliaID codFamilia, f.Nombre nomFamilia 
	,u.unidadID codUnidad,u.Nombre nomUnidad,a.Inventario, a.Observacion,a.FechaGrabacion,a.minimo
	from #Articulo a
	inner join #Unidad u on u.UnidadID = a.unidadID
	inner join #Fam f on f.FamiliaID = a.FamiliaID
	
go

exec spArticuloSelect 