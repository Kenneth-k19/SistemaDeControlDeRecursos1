USE DB20172001423

select * from Existencia

alter procedure spExistenciaSelect
AS
	select a.ArticuloID, a.Nombre, a.Codigo, Sum(isnull(e.Compras, 0)) as 'Total Compras', 
			Sum(isnull(e.Ventas, 0)) as 'Total Ventas' from Existencia e
	inner join Articulo a on e.ArticuloID = a.ArticuloID
	group by a.ArticuloID, a.Codigo, a.Nombre
	order by a.Nombre

	spExistenciaSelect
	