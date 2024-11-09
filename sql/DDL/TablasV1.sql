use DB20172001423

CREATE TABLE Proveedor (
    ProveedorID INT NOT NULL,
    Identidad VARCHAR(13),
    Nombre VARCHAR(50),
    Tipo CHAR(1),
    Direccion VARCHAR(100),
    Telefono VARCHAR(13),
    Contacto VARCHAR(35),
    CONSTRAINT pkProveedor PRIMARY KEY (ProveedorID)
);

CREATE TABLE Area (
    AreaID INT NOT NULL,
    Nombre VARCHAR(25),
    EncargadoID INT,
    CONSTRAINT pkArea PRIMARY KEY (AreaID)
);

CREATE TABLE Usuario (
    UsuarioID INT NOT NULL,
    Codigo VARCHAR(15),
    Nombre VARCHAR(50),
    Identidad VARCHAR(13),
    AreaID INT,
    CONSTRAINT pkUsuario PRIMARY KEY (UsuarioID),
    CONSTRAINT fkUsuarioArea FOREIGN KEY (AreaID) REFERENCES Area (AreaID)
);

CREATE TABLE Familia (
    FamiliaID INT NOT NULL,
    Nombre VARCHAR(20),
    CONSTRAINT pkFamilia PRIMARY KEY (FamiliaID)
);

CREATE TABLE Articulo (
    ArticuloID INT NOT NULL,
    Codigo VARCHAR(5),
    Nombre VARCHAR(20),
    Tipo CHAR(1),
    FamiliaID INT,
    Precio FLOAT,
    UnidadID INT,
    Inventario BIT,
    Observacion VARCHAR(50),
    FechaGrabacion DATETIME,
	minimo int,
    CONSTRAINT pkArticulo PRIMARY KEY (ArticuloID),
    CONSTRAINT fkArticuloFamilia FOREIGN KEY (FamiliaID) REFERENCES Familia (FamiliaID)
);

CREATE TABLE Periodo (
    PeriodoID INT NOT NULL,
    Inicio DATE,
    Final DATE,
    Tipo CHAR(1),
    Estado CHAR(1),
    CONSTRAINT pkPeriodo PRIMARY KEY (PeriodoID)
);

CREATE TABLE Modulo (
    ModuloID INT NOT NULL,
    Nombre VARCHAR(15),
    frmButton VARCHAR(20),
    Observacion VARCHAR(20),
    CONSTRAINT pkModulo PRIMARY KEY (ModuloID)
);

-- Tablas dependientes (Hijas)

CREATE TABLE Compra (
    CompraID INT NOT NULL,
    ProveedorID INT,
    Fecha DATE NOT NULL,
    Tipo CHAR(1),
    Documento VARCHAR(20),
    Estado CHAR(1),
    UsuarioID INT,
    CONSTRAINT pkCompra PRIMARY KEY (CompraID),
    CONSTRAINT fkCompraProveedor FOREIGN KEY (ProveedorID) REFERENCES Proveedor (ProveedorID),
    CONSTRAINT fkCompraUsuario FOREIGN KEY (UsuarioID) REFERENCES Usuario (UsuarioID)
);

CREATE TABLE Factura (
    FacturaID INT NOT NULL,
    Codigo VARCHAR(20),
    Fecha DATETIME,
    Tipo CHAR(1),
    Consumo CHAR(1),
    UsuarioID INT,
    Estado CHAR(1),
    CONSTRAINT pkFactura PRIMARY KEY (FacturaID),
    CONSTRAINT fkFacturaUsuario FOREIGN KEY (UsuarioID) REFERENCES Usuario (UsuarioID)
);

CREATE TABLE FacturaPago (
    FacturaPagoID INT NOT NULL,
    FacturaID INT,
    Tipo CHAR(1),
    Valor FLOAT,
    CONSTRAINT pkFacturaPago PRIMARY KEY (FacturaPagoID),
    CONSTRAINT fkFacturaPagoFactura FOREIGN KEY (FacturaID) REFERENCES Factura (FacturaID)
);

CREATE TABLE Consumo (
    ConsumoID INT NOT NULL,
    ArticuloID INT,
    Observacion VARCHAR(50),
    CONSTRAINT pkConsumo PRIMARY KEY (ConsumoID),
    CONSTRAINT fkConsumoArticulo FOREIGN KEY (ArticuloID) REFERENCES Articulo (ArticuloID)
);

CREATE TABLE CompraDet (
    CompraDetID INT NOT NULL,
    CompraID INT,
    ArticuloID INT,
    Cantidad INT,
    Precio FLOAT,
    Descuento FLOAT,
    Impuesto FLOAT,
    CONSTRAINT pkCompraDet PRIMARY KEY (CompraDetID),
    CONSTRAINT fkCompraDetCompra FOREIGN KEY (CompraID) REFERENCES Compra (CompraID),
    CONSTRAINT fkCompraDetArticulo FOREIGN KEY (ArticuloID) REFERENCES Articulo (ArticuloID)
);

CREATE TABLE FacturaDet (
    FacturaDetID INT NOT NULL,
    FacturaCabID INT,
    ArticuloID INT,
    Cantidad INT,
    Precio FLOAT,
    Observacion VARCHAR(75),
    CONSTRAINT pkFacturaDet PRIMARY KEY (FacturaDetID),
    CONSTRAINT fkFacturaDetFactura FOREIGN KEY (FacturaCabID) REFERENCES Factura (FacturaID),
    CONSTRAINT fkFacturaDetArticulo FOREIGN KEY (ArticuloID) REFERENCES Articulo (ArticuloID)
);

CREATE TABLE ConsumoDet (
    ConsumoDetID INT NOT NULL,
    ConsumoID INT,
    ArticuloID INT,
    Cantidad INT,
    CONSTRAINT pkConsumoDet PRIMARY KEY (ConsumoDetID),
    CONSTRAINT fkConsumoDetConsumo FOREIGN KEY (ConsumoID) REFERENCES Consumo (ConsumoID),
    CONSTRAINT fkConsumoDetArticulo FOREIGN KEY (ArticuloID) REFERENCES Articulo (ArticuloID)
);

CREATE TABLE Existencia (
    ExistenciaID INT NOT NULL,
    PeriodoID INT,
    ArticuloID INT,
    Cantidad INT,
    Compras INT,
    Ventas INT,
    Salidas INT,
    Entradas INT,
    CONSTRAINT pkExistencia PRIMARY KEY (ExistenciaID),
    CONSTRAINT fkExistenciaPeriodo FOREIGN KEY (PeriodoID) REFERENCES Periodo (PeriodoID),
    CONSTRAINT fkExistenciaArticulo FOREIGN KEY (ArticuloID) REFERENCES Articulo (ArticuloID)
);

CREATE TABLE Ajuste (
    AjusteID INT NOT NULL,
    Fecha DATETIME,
    PeriodoID INT,
    UsuarioID INT,
    Tipo CHAR(1),
    Observacion VARCHAR(20),
    Estado CHAR(1),
    CONSTRAINT pkAjuste PRIMARY KEY (AjusteID),
    CONSTRAINT fkAjustePeriodo FOREIGN KEY (PeriodoID) REFERENCES Periodo (PeriodoID),
    CONSTRAINT fkAjusteUsuario FOREIGN KEY (UsuarioID) REFERENCES Usuario (UsuarioID)
);

CREATE TABLE AjusteDet (
    AjusteDetID INT NOT NULL,
    AjusteID INT,
    ArticuloID INT,
    Cantidad INT,
    Precio FLOAT,
    CONSTRAINT pkAjusteDet PRIMARY KEY (AjusteDetID),
    CONSTRAINT fkAjusteDetAjuste FOREIGN KEY (AjusteID) REFERENCES Ajuste (AjusteID),
    CONSTRAINT fkAjusteDetArticulo FOREIGN KEY (ArticuloID) REFERENCES Articulo (ArticuloID)
);

CREATE TABLE Acceso (
    AccesoID INT NOT NULL,
    UsuarioID INT,
    ModuloDetID INT,
    CONSTRAINT pkAcceso PRIMARY KEY (AccesoID),
    CONSTRAINT fkAccesoUsuario FOREIGN KEY (UsuarioID) REFERENCES Usuario (UsuarioID),
    CONSTRAINT fkAccesoModuloDet FOREIGN KEY (ModuloDetID) REFERENCES Modulo (ModuloID)
);

CREATE TABLE ModuloDet (
    ModuloDetID INT NOT NULL,
    ModuloID INT,
    frmButton VARCHAR(20),
    frmName VARCHAR(20),
    Nombre VARCHAR(20),
    Observacion CHAR(1),
    CONSTRAINT pkModuloDet PRIMARY KEY (ModuloDetID),
    CONSTRAINT fkModuloDetModulo FOREIGN KEY (ModuloID) REFERENCES Modulo (ModuloID)
);
