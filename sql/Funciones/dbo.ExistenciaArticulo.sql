use DB20172001423
go
drop function dbo.ExistenciaArticulo
go 
create function dbo.ExistenciaArticulo(@ArticuloID int) returns int
as
	begin
		declare @AjusteSal int,@AjusteEnt int, @Ventas int, @Compras int

		select @AjusteEnt = SUM(isnull(Cantidad,0)) from AjusteDet where TipoAjusteID in (1,3) and ArticuloID = @ArticuloID
		select @AjusteSal = SUM(isnull(Cantidad,0)) from AjusteDet where TipoAjusteID in (2,4) and ArticuloID = @ArticuloID
		select @Ventas = SUM(isNull(Ventas,0)) from Existencia where ArticuloID = @ArticuloID
		select @Compras = SUM(isNull(Compras,0)) from Existencia where ArticuloID = @ArticuloID

		return isNull(@AjusteEnt,0) + isNull(@Compras,0) - isNull(@Ventas,0) - isNull(@AjusteSal,0)		 
	end
go

select dbo.ExistenciaArticulo(24) Existencia



