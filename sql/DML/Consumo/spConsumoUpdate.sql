use DB20172001423
go
drop procedure spConsumoUpdate 
go
create procedure spConsumoUpdate @ConsumoID int,@ArticuloID int, @Observacion varchar(100)
as
	Update Consumo set ArticuloID = @ArticuloID, Observacion = @Observacion where ConsumoID = @ConsumoID
go
