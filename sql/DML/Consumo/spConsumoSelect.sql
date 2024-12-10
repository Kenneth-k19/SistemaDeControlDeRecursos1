use DB20172001423
go
drop procedure spConsumoSelect 
go
create procedure spConsumoSelect @ConsumoID int = 0
as
	select *from Consumo where ConsumoID = @ConsumoID or @ConsumoID = 0
go
exec spConsumoSelect 