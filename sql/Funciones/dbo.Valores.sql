use db20212020720
go
drop function dbo.valores
go
CREATE FUNCTION dbo.Valores (@tabla NVARCHAR(50), @columna NVARCHAR(50))
RETURNS @Resultado TABLE (
    Tabla NVARCHAR(50),
    Columna NVARCHAR(50),
    Codigo CHAR(1),
    Valor NVARCHAR(100)
)
AS
BEGIN
	declare @temp TABLE (
    Tabla NVARCHAR(50),
    Columna NVARCHAR(50),
    Codigo CHAR(1),
    Valor NVARCHAR(100)
)
    INSERT INTO @temp (Tabla, Columna, Codigo, Valor)
    SELECT 
        'Compra', 'Tipo', 'C', 'Credito'
    UNION ALL
    SELECT 
        'Compra', 'Tipo', 'O', 'Contado'
    UNION ALL
    SELECT 
        'Compra', 'Estado', 'F', 'Finalizada'
    UNION ALL
    SELECT 
        'Compra', 'Estado', 'S', 'Salvada'
    UNION ALL
    SELECT 
        'Factura', 'Estado', 'G', 'Guardada'
    UNION ALL
    SELECT 
        'Factura', 'Estado', 'S', 'Salvada'
    UNION ALL
    SELECT 
        'Factura', 'Consumo', 'L', 'Llevar'
    UNION ALL
    SELECT 
        'Factura', 'Consumo', 'C', 'Comer en restaurante'
    UNION ALL
    SELECT 
        'Factura', 'Consumo', 'D', 'A domicilio'
    UNION ALL
    SELECT 
        'Articulo', 'Tipo', 'V', 'Venta'
    UNION ALL
    SELECT 
        'Articulo', 'Tipo', 'C', 'Consumo'
    UNION ALL
    SELECT 
        'Proveedor', 'Tipo', 'D', 'entrega'
    UNION ALL
    SELECT 
        'Proveedor', 'Tipo', 'P', 'En tienda'
    UNION ALL
    SELECT 
        'FacturaPago', 'Tipo', 'E', 'Efectivo'
    UNION ALL
    SELECT 
        'FacturaPago', 'Tipo', 'T', 'Tarjeta'
    UNION ALL
    SELECT 
        'Periodo', 'Tipo', 'I', 'Inventario'
    UNION ALL
    SELECT 
        'Periodo', 'Estado', 'A', 'Abierto'
    UNION ALL
    SELECT 
        'Periodo', 'Estado', 'C', 'Cerrado'
    UNION ALL
    SELECT 
        'Ajuste', 'Tipo', 'E', 'Ajuste de entrada'
    UNION ALL
    SELECT 
        'Ajuste', 'Tipo', 'S', 'Ajuste de Salida'
    UNION ALL
    SELECT 
        'Ajuste', 'Tipo', 'P', 'Proceso de productos'
    UNION ALL
    SELECT 
        'Ajuste', 'Estado', 'S', 'Salvado'
    UNION ALL
    SELECT 
        'Ajuste', 'Estado', 'F', 'Finalizado';

	insert into @Resultado
		select *from @temp where Tabla = @tabla and Columna = @columna
    RETURN;
END;
