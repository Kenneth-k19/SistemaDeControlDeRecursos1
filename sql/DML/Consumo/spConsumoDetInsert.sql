use DB20172001423
go
drop procedure spConsumoDetInsert
go
create procedure spConsumoDetInsert @ConsumoDetID int, @ConsumoID int,@ArticuloID int, @Cantidad int
as
	select @ConsumoDetID = ISNULL(max(consumoDetID),0)+1 from ConsumoDet 

	insert into ConsumoDet values (@ConsumoDetID,@ConsumoID,@ArticuloID,@Cantidad)
go
