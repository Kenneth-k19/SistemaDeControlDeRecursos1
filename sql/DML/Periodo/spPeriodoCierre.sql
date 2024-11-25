use db20172001423
go
drop proc spPeriodoCierre
go
create proc spPeriodoCierre @PeriodoID int
as
	update Periodo set Estado = 'C' where PeriodoID = @PeriodoID
go

