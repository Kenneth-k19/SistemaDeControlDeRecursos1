use db20172001423

-- Genera y ejecuta el script para eliminar todas las tablas creadas por el usuario
DECLARE @sql NVARCHAR(MAX) = ''

-- Construye el comando DROP TABLE para cada tabla de usuario
SELECT @sql += 'DROP TABLE IF EXISTS [' + TABLE_SCHEMA + '].[' + TABLE_NAME + ']; '
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_SCHEMA = 'dbo' -- Ajusta el esquema si es necesario

-- Ejecuta el comando generado
EXEC sp_executesql @sql;
