CREATE DATABASE Cerrajeria_Hns

CREATE TABLE Empleados(
NumTrabajador TINYINT PRIMARY KEY NOT NULL IDENTITY(001,1),
NomUsuario varchar(20) NOT NULL,
Contrasena varbinary(8000) NOT NULL,
Nombre varchar(30) NOT NULL,
Apellido_P varchar(30) NOT NULL,
Apellido_M varchar(30),
F_Nacimiento smalldatetime NOT NULL,
F_Registro smalldatetime NOT NULL,
Direccion varchar(80) NOT NULL,
Telefono varchar (10))

CREATE TABLE Clientes(
ID TINYINT PRIMARY KEY NOT NULL IDENTITY (001,1),
Nombre varchar(60),
RFC varchar(13) NOT NULL,
Direccion varchar(80) NOT NULL,
Cod_Post varchar(5) NOT NULL,
Ciudad varchar (80) NOT NULL,
Telefono varchar(10)NOT NULL,
Colonia varchar(40) NOT NULL)

CREATE TABLE Trabajos(
Ticket TINYINT PRIMARY KEY NOT NULL IDENTITY (001,1),
Detalles VARCHAR(300)NOT NULL,
Costo SMALLMONEY NOT NULL,
IVA SMALLMONEY,
NT TINYINT NOT NULL,
IDCliente TINYINT NOT NULL,
NomCliente VARCHAR(30) NOT NULL,
TipoTrabajo TINYINT NOT NULL)

CREATE TABLE TiposDeTrabajos(
ID TINYINT PRIMARY KEY NOT NULL,
Descripcion VARCHAR(20))

CREATE TABLE MaterialesUsados(
NTicket TINYINT NOT NULL,
ClaveLlave TINYINT NOT NULL,
Cantidad SMALLINT NOT NULL)

CREATE TABLE Llaves(
Clave TINYINT PRIMARY KEY NOT NULL,
Tipo VARCHAR(10) NOT NULL,
Inventario SMALLINT NOT NULL)

--LLAVE COMPUESTA
ALTER TABLE MaterialesUsados ADD PRIMARY KEY (NTicket,ClaveLlave)

--LLAVES FORANEAS
ALTER TABLE Trabajos ADD CONSTRAINT FK_Trabajos_Empelados_1M FOREIGN KEY (NT) REFERENCES Empleados (NumTrabajador) ON DELETE CASCADE
ALTER TABLE Trabajos ADD CONSTRAINT FK_Trabajos_Clientes_1M FOREIGN KEY (IDCliente) REFERENCES Clientes (ID) ON DELETE CASCADE
ALTER TABLE Trabajos ADD CONSTRAINT FK_Tipo_Trabajos_1M FOREIGN KEY (TipoTrabajo) REFERENCES TiposDeTrabajos (ID) ON DELETE CASCADE

ALTER TABLE MaterialesUsados ADD CONSTRAINT FK_Materiales_Trabajos_1M FOREIGN KEY (NTicket) REFERENCES Trabajos (Ticket) ON DELETE CASCADE
ALTER TABLE MaterialesUsados ADD CONSTRAINT FK_Materiales_Llaves_1M FOREIGN KEY (ClaveLlave) REFERENCES Llaves (Clave) ON DELETE CASCADE

