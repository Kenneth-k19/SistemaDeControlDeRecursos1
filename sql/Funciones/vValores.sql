use DB20172001423
go
drop view vValores
go
CREATE VIEW vValores AS
	SELECT 
		'Compra' AS Tabla, 'Tipo' AS Columna, 'C' AS Codigo, 'Credito' AS Valor
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
			'Proveedor', 'Tipo', 'D', 'Entrega'
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
go

select *from vValores