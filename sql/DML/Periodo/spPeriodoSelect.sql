use db20172001423
go
drop proc spPeriodoSelect
go
create proc spPeriodoSelect @PeriodoID int = 0
as
	select PeriodoID CodigoPeriodo, Inicio,Final
	,case Tipo when 'I' then 'Inventario' else 'Otro?' end as Tipo
	,case Estado when 'A' then 'Abierto' else 'Cerrado' end as Estado
		from Periodo where PeriodoID = @PeriodoID or @PeriodoID = 0
	order by Inicio desc
go

exec spPeriodoSelect 0