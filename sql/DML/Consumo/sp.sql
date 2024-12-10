use DB20172001423
go
drop procedure spConsumoinsert 
go
create procedure spConsumoinsert @ConsumoID int output,@ArticuloID int, @Observacion varchar(100)
as
	select @ConsumoID = ISNULL(max(consumoID),0) + 1 from Consumo

	insert into Consumo values (@ConsumoID, @ArticuloID,@Observacion)
go
