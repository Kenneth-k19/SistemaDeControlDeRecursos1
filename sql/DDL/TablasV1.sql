use db20212020720

-- Tabla Proveedor
CREATE TABLE Proveedor (
    ProveedorID INT,
    Tipo CHAR(1) NOT NULL,
    Nombre NVARCHAR(100) NOT NULL,
    CONSTRAINT pkProveedor PRIMARY KEY (ProveedorID)
);

-- Tabla Articulo
CREATE TABLE Articulo (
    ArticuloID int,
    Tipo CHAR(1) NOT NULL,
    Descripcion NVARCHAR(100) NOT NULL,
	Minimo int,
    CONSTRAINT pkArticulo PRIMARY KEY (ArticuloID)

);

-- Tabla Periodo
CREATE TABLE Periodo (
    PeriodoID int,
    Tipo CHAR(1) NOT NULL,
    Estado CHAR(1) NOT NULL,
    FechaInicio DATE NOT NULL,
    FechaFin DATE NULL,
    CONSTRAINT pkPeriodo PRIMARY KEY (PeriodoID)
);

-- Tabla Compra
CREATE TABLE Compra (
    CompraID int,
    ProveedorID INT NOT NULL,
    Tipo CHAR(1) NOT NULL,
    Estado CHAR(1) NOT NULL,
    Fecha DATE NOT NULL,
    CONSTRAINT pkCompra PRIMARY KEY (CompraID),
    CONSTRAINT fkCompraProveedor FOREIGN KEY (ProveedorID) REFERENCES Proveedor(ProveedorID)
);

-- Tabla Factura
CREATE TABLE Factura (
    FacturaID int,
    Tipo CHAR(1) NOT NULL,
    Estado CHAR(1) NOT NULL,
    Consumo CHAR(1) NOT NULL,
    Fecha DATE NOT NULL,
    CONSTRAINT pkFactura PRIMARY KEY (FacturaID)
);

-- Tabla FacturaPago
CREATE TABLE FacturaPago (
    PagoID int,
    FacturaID INT NOT NULL,
    Tipo CHAR(1) NOT NULL,
    Monto DECIMAL(10, 2) NOT NULL,
    CONSTRAINT pkFacturaPago PRIMARY KEY (PagoID),
    CONSTRAINT fkFacturaPagoFactura FOREIGN KEY (FacturaID) REFERENCES Factura(FacturaID)
);

-- Tabla Ajuste
CREATE TABLE Ajuste (
    AjusteID int,
    Tipo CHAR(1) NOT NULL,
    Estado CHAR(1) NOT NULL,
    PeriodoID INT NOT NULL,
    Fecha DATE NOT NULL,
    CONSTRAINT pkAjuste PRIMARY KEY (AjusteID),
    CONSTRAINT fkAjustePeriodo FOREIGN KEY (PeriodoID) REFERENCES Periodo(PeriodoID)
);
