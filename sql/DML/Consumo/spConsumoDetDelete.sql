use db20172001423
go
drop proc spConsumoDetDelete
go
create proc spConsumoDetDelete @ConsumoDetID int
as
	delete from ConsumoDet where ConsumoDetID = @ConsumoDetID
go