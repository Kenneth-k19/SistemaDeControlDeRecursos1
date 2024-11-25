use db20172001423
go
drop proc spAjusteSelect
go
create proc spAjusteSelect @AjusteID int = 0
as
	select *into #Ajuste from Ajuste where AjusteID = @AjusteID or @AjusteID = 0
	select *into #Periodo from Periodo where PeriodoID in (Select PeriodoID from #Ajuste)
	select *into #Usuario from Usuario where UsuarioID in (select UsuarioID from #Ajuste)
	select *into #Valores from vValores where tabla in ('Usuario','Periodo','Ajuste') and Valor <> 'Inventario'
	

	select AjusteID [Codigo Ajuste], CONVERT(varchar,Fecha,7) Fecha, CONCAT(dbo.getMes(Inicio),' - ',YEAR(Inicio)) Periodo
		,u.Nombre Usuario, Observacion
	from #Ajuste a
	inner join #Periodo p on p.PeriodoID = a.PeriodoID
	inner join #Usuario u on u.UsuarioID = a.UsuarioID
	inner join #Valores v on v.Codigo = P.Estado or v.Codigo = a.Tipo or v.Codigo = a.Estado


go

exec spAjusteSelect 1