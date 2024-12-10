use DB20172001423
go
drop procedure spConsumoDetUpdate
go
create procedure spConsumoDetUpdate @ConsumoDetID int, @ConsumoID int,@ArticuloID int, @Cantidad int
as
	Update ConsumoDet set ConsumoID = @ConsumoID, ArticuloID = @ArticuloID, Cantidad = @Cantidad
		where ConsumoDetID = @ConsumoDetID
go
