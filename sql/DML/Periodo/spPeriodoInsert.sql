use db20172001423
go
drop proc spPeriodoInsert
go
create proc spPeriodoInsert
as
	
	declare @PeriodoID int,@iniAnt date, @finAnt date, @iniAct date, @finAct date

	select @PeriodoID = isNull(MAX(periodoID),0) from Periodo --ultimo periodo
	select @iniAnt = inicio, @finAnt = final from Periodo where PeriodoID = @PeriodoID
	
	select @iniAct = DATEADD(day,1,@finAnt)
	select @finAct = EOMONTH(@iniAct)
	--select @iniAct InicialNuevo, @finAct FinalNuevo

	set @PeriodoID = @PeriodoID + 1
	insert into Periodo values (@PeriodoID,@iniAct,@finAct,'I','A')
	select *from Periodo where PeriodoID = @PeriodoID

go

exec spPeriodoInsert