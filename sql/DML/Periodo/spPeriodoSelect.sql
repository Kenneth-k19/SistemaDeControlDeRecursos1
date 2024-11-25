use db20172001423
go
drop proc spPeriodoSelect
go
create proc spPeriodoSelect @PeriodoID int = 0
as
	select *
		from Periodo where PeriodoID = @PeriodoID or @PeriodoID = 0
go

exec spPeriodoSelect 0