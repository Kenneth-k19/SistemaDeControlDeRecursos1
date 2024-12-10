use DB20172001423
go
drop procedure spConsumoDetSelect
go
create procedure spConsumoDetSelect @ConsumoID int
as
	select *from ConsumoDet where ConsumoID = @ConsumoID
go

exec spConsumoDetSelect 1