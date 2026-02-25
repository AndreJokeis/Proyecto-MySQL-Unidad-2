create database tallermecanico;

use tallermecanico;

show tables;

create table clientes(
	idCliente int auto_increment primary key not null,
    RFC char(13) not null unique,
    Nombre varchar(100) not null,
    Direccion varchar(200) not null,
    Telefono1 char(10) not null,
    Telefono2 char(10),
    Telefono3 char(10),
    Correo varchar(320) not null unique,
    FechaRegistro TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE vehiculos (
    NumeroDeSerie INT PRIMARY KEY NOT NULL,
    idCliente INT NOT NULL,
    Placa VARCHAR(7) NOT NULL UNIQUE,
    Marca VARCHAR(20) NOT NULL,
    Modelo VARCHAR(50) NOT NULL,
    Año YEAR NOT NULL,
    Color VARCHAR(15) NOT NULL,
    Kilometraje INT NOT NULL,
    Tipo VARCHAR(25),
    Antiguedad INT,
    FOREIGN KEY (idCliente)
        REFERENCES clientes (idCliente)
);

create table mecanicos(
	idMecanico int auto_increment primary key not null,
    RFC char(13) not null unique,
    Nombre varchar(100) not null,
    Especialidad varchar(25),
    Telefono char(10) not null,
    Salario decimal(9,2) not null,
    AñosExperiencia int not null
);

create table servicios(
	idServicio int auto_increment primary key not null,
    NombreServicio varchar(50) not null,
    Descripcion varchar(200),
    Costo decimal(9,2) not null,
    TiempoEstimado decimal(3,1) not null
);

create table refacciones(
	idRefaccion int auto_increment primary key not null,
    Nombre varchar(50) not null,
    Marca varchar(20) not null,
    PrecioUnitario decimal(7,2) not null,
    Stock int unsigned not null,
    StockMinimo int unsigned not null,
    Proveedor varchar(50) not null
);

create table orden_servicios(
	Folio int auto_increment primary key not null,
    FechaIngreso date not null,
    EntregaEstimada date not null,
    EntregaReal date not null,
    Estado ENUM('Abierto', 'En proceso', 'Finalizado', 'Cancelado') NOT NULL DEFAULT 'Abierto',
    CostoTotal decimal(8,2),
    
    idServicio int not null,
    NumeroDeSerie int not null,
    
	foreign key (idServicio)
        references servicios (idServicio),
	foreign key (NumeroDeSerie)
        references vehiculos (NumeroDeSerie)
);

create table orden_mecanicos(
	idOrden int not null,
    Folio int not null,
    idMecanico int not null,
    
    primary key (idOrden, idMecanico),
    
    foreign key (Folio)
		references orden_servicios (Folio),
	foreign key (idMecanico)
		references mecanicos (idMecanico)
);

create table orden_refacciones(
	idOrden int not null,
    Folio int not null,
    idRefaccion int not null,
    
    primary key (idOrden, idRefaccion),
    
    foreign key (Folio)
		references orden_servicios (Folio),
	foreign key (idRefaccion)
		references refacciones (idRefaccion)
);

INSERT INTO servicios (NombreServicio, Descripcion, Costo, TiempoEstimado) VALUES
    ('Afinación Mayor', 'Cambio de bujías, filtros de aire y gasolina, y limpieza de inyectores', 1850.00, 3.5),
    ('Cambio de Aceite y Filtro', 'Reemplazo de aceite sintético y filtro de aceite', 850.00, 1.0),
    ('Revisión de Frenos', 'Inspección de balatas, discos y rectificado si es necesario', 1200.00, 2.5),
    ('Diagnóstico por Computadora', 'Escaneo de códigos de error y revisión de sensores', 450.00, 0.5),
    ('Alineación y Balanceo', 'Ajuste de ángulos de llantas y contrapesos', 600.00, 1.5),
    ('Reparación de Suspensión', 'Cambio de amortiguadores y terminales de dirección', 2500.00, 4.0),
    ('Limpieza de Sistema de Enfriamiento', 'Drenado y cambio de anticongelante', 750.00, 2.0);
    
INSERT INTO refacciones (Nombre, Marca, PrecioUnitario, Stock, StockMinimo, Proveedor) VALUES
    ('Aceite Sintético 5W-30 (1L)', 'Mobil 1', 210.00, 50, 10, 'Distribuidora Automotriz del Centro'),
    ('Filtro de Aceite', 'Bosch', 145.50, 30, 5, 'Refacciones Unidas'),
    ('Bujía de Iridio', 'NGK', 185.00, 100, 20, 'AutoZone Proveedores'),
    ('Balatas Delanteras', 'Brembo', 890.00, 12, 4, 'Frenos de México'),
    ('Filtro de Aire', 'Fram', 175.00, 25, 5, 'Refacciones Unidas'),
    ('Amortiguador Delantero', 'Monroe', 1350.00, 8, 2, 'Suspensiones del Bajío'),
    ('Anticongelante Rosa (4L)', 'Prestone', 320.00, 20, 6, 'Químicos Automotrices S.A.'),
    ('Batería 12V', 'LTH', 2450.00, 10, 3, 'Acumuladores Monterrey');
    
select * from refacciones;
select * from servicios;

drop procedure add_refaccion;

DELIMITER //
CREATE PROCEDURE add_refaccion (
    IN nNombre varchar(50),
    IN nMarca varchar(20),
    IN nPrecioUnitario decimal(7,2),
    IN nStock int,
    IN nStockMinimo int,
    IN nProveedor varchar(50)
)
BEGIN
    INSERT INTO refacciones 
		(Nombre, Marca, PrecioUnitario, Stock, StockMinimo, Proveedor) 
	VALUES
		(nNombre, nMarca, nPrecioUnitario, nStock, nStockMinimo, nProveedor);
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE get_refaccion (
	IN id int
)
BEGIN
    select * from refacciones 
		where idRefaccion = id;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE get_refacciones (
)
BEGIN
    select * from refacciones;
END //
DELIMITER ;

call get_refaccion(1);
call get_refacciones;
call add_refaccion('Bujia racing', 'NGK', 250, 25, 5, 'Andre');

select * from refacciones;

