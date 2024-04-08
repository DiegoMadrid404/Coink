CREATE DATABASE Coink
go
use Coink
go
-- Creaci�n del esquema para las tablas param�tricas
CREATE SCHEMA parametricas;
go
-- Creaci�n de la tabla de pa�ses
CREATE TABLE parametricas.Pais (
    id INT PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(50),
    activo BIT DEFAULT 1,
    fechaCreacion DATETIME DEFAULT GETDATE(),
    fechaModificacion DATETIME NULL
);

-- Creaci�n de la tabla de departamentos
CREATE TABLE parametricas.Departamento (
    id INT PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(50),
    paisId INT,
    activo BIT DEFAULT 1,
    fechaCreacion DATETIME DEFAULT GETDATE(),
    fechaModificacion DATETIME NULL,
    CONSTRAINT FK_Departamento_Pais FOREIGN KEY (paisId) REFERENCES parametricas.Pais(id)
);

-- Creaci�n de la tabla de municipios
CREATE TABLE parametricas.Municipio (
    id INT PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(50),
    departamentoId INT,
    activo BIT DEFAULT 1,
    fechaCreacion DATETIME DEFAULT GETDATE(),
    fechaModificacion DATETIME NULL,
    CONSTRAINT FK_Municipio_Departamento FOREIGN KEY (departamentoId) REFERENCES parametricas.Departamento(id)
);

go



-- Creaci�n del esquema para la tabla de usuarios
CREATE SCHEMA aplicacion;
GO

-- Creaci�n de la tabla de usuarios
CREATE TABLE aplicacion.Usuario (
    id INT PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(50),
    telefono nvarchar(20),
    direccion NVARCHAR(100),
    municipioId INT,
    activo BIT DEFAULT 1,
    fechaCreacion DATETIME DEFAULT GETDATE(),
    fechaModificacion DATETIME NULL,
    CONSTRAINT FK_Usuario_Municipio FOREIGN KEY (municipioId) REFERENCES parametricas.Municipio(id)
);
GO

-- Procedimientos almacenados para CRUD en la tabla de usuarios
CREATE PROCEDURE aplicacion.InsertarUsuario (
    @nombre NVARCHAR(50)=null,
    @telefono NVARCHAR(25)=null,
    @direccion NVARCHAR(100)=null,
    @municipioId INT =null
)
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRANSACTION;

    INSERT INTO aplicacion.Usuario (nombre, telefono, direccion, municipioId) 
    VALUES (@nombre, @telefono, @direccion, @municipioId);


  select * from aplicacion.Usuario     WHERE id = @@IDENTITY;

    COMMIT TRANSACTION;
END;
GO

CREATE PROCEDURE aplicacion.ActualizarUsuario (
    @id INT =null,
    @nombre NVARCHAR(50)=null,
    @telefono NVARCHAR(25)=null,
    @direccion NVARCHAR(100)=null,
    @municipioId INT =null
)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRANSACTION;

    UPDATE aplicacion.Usuario 
    SET
     nombre  = isnull(@nombre,nombre) ,
	telefono= isnull (@telefono,telefono) ,
	direccion = isnull(@direccion, direccion) ,
	municipioId = isnull(@municipioId,municipioId) ,
	fechaModificacion = SYSUTCDATETIME() 
    WHERE id = @id;

	select * from aplicacion.Usuario     WHERE id = @id;

    COMMIT TRANSACTION;
END;
GO


CREATE PROCEDURE aplicacion.EliminarUsuario (
    @id INT
)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRANSACTION;

    UPDATE aplicacion.Usuario 
    SET activo = 0, fechaModificacion = SYSUTCDATETIME() 
    WHERE id = @id;

    COMMIT TRANSACTION;
END;
GO

CREATE PROCEDURE aplicacion.ListarUsuarios

    @id INT =null,
    @nombre NVARCHAR(50)=null,
    @telefono NVARCHAR(15)=null,
    @direccion NVARCHAR(100)=null,
    @municipioId INT =null
AS
BEGIN
    SET NOCOUNT ON;

    SELECT u.id,u.nombre, u.telefono, u.direccion,u.activo,u.fechaCreacion,u.fechaModificacion, 
	u.municipioId, m.nombre nombreMunicipio, d.id departamentoId, d.nombre  nombreDepartamento
	
	FROM aplicacion.Usuario u 
	INNER JOIN parametricas.Municipio m on m.id=u.municipioId
	INNER JOIN parametricas.Departamento d on d.id= m.departamentoId
	WHERE
	u.id=isnull(@id,u.id) and
    u.nombre  = isnull(@nombre,u.nombre) and
	u.telefono= isnull (@telefono,u.telefono) and
	u.direccion = isnull(@direccion, u.direccion) and
	u.municipioId = isnull(@municipioId,u.municipioId) and
	u.activo = 1;
END;
GO






  -- Insertar informaci�n sobre Colombia en la tabla de pa�ses
INSERT INTO parametricas.Pais (nombre) VALUES ('Colombia');

-- Insertar informaci�n sobre departamentos en Colombia
INSERT INTO parametricas.Departamento (nombre, paisId) VALUES ('Antioquia', 1);
INSERT INTO parametricas.Departamento (nombre, paisId) VALUES ('Bogot� D.C.', 1);
INSERT INTO parametricas.Departamento (nombre, paisId) VALUES ('Valle del Cauca', 1);
INSERT INTO parametricas.Departamento (nombre, paisId) VALUES ('Atl�ntico', 1);

-- Insertar informaci�n sobre municipios en Colombia
INSERT INTO parametricas.Municipio (nombre, departamentoId) VALUES ('Medell�n', 1);
INSERT INTO parametricas.Municipio (nombre, departamentoId) VALUES ('Envigado', 1);
INSERT INTO parametricas.Municipio (nombre, departamentoId) VALUES ('Itag��', 1);
INSERT INTO parametricas.Municipio (nombre, departamentoId) VALUES ('Bello', 1);
INSERT INTO parametricas.Municipio (nombre, departamentoId) VALUES ('Cali', 3);
INSERT INTO parametricas.Municipio (nombre, departamentoId) VALUES ('Yumbo', 3);
INSERT INTO parametricas.Municipio (nombre, departamentoId) VALUES ('Palmira', 3);
INSERT INTO parametricas.Municipio (nombre, departamentoId) VALUES ('Buga', 3);
INSERT INTO parametricas.Municipio (nombre, departamentoId) VALUES ('Barranquilla', 4);
INSERT INTO parametricas.Municipio (nombre, departamentoId) VALUES ('Soledad', 4);
INSERT INTO parametricas.Municipio (nombre, departamentoId) VALUES ('Malambo', 4);
INSERT INTO parametricas.Municipio (nombre, departamentoId) VALUES ('Sabanalarga', 4);
INSERT INTO parametricas.Municipio (nombre, departamentoId) VALUES ('Bogot� D.C.', 2);
INSERT INTO parametricas.Municipio (nombre, departamentoId) VALUES ('Soacha', 2);
INSERT INTO parametricas.Municipio (nombre, departamentoId) VALUES ('Zipaquir�', 2);
INSERT INTO parametricas.Municipio (nombre, departamentoId) VALUES ('Facatativ�', 2);
INSERT INTO parametricas.Municipio (nombre, departamentoId) VALUES ('Cartago', 3);
INSERT INTO parametricas.Municipio (nombre, departamentoId) VALUES ('Tulu�', 3);
INSERT INTO parametricas.Municipio (nombre, departamentoId) VALUES ('Buga', 3);
INSERT INTO parametricas.Municipio (nombre, departamentoId) VALUES ('Cartago', 3);

-- Insertar informaci�n sobre los usuarios

INSERT INTO aplicacion.Usuario (nombre, telefono, direccion, municipioId) 
VALUES ('Juan P�rez', '1234567890', 'Calle 123', 1); 

INSERT INTO aplicacion.Usuario (nombre, telefono, direccion, municipioId) 
VALUES ('Mar�a Rodr�guez', '0987654321', 'Carrera 456', 2); 

INSERT INTO aplicacion.Usuario (nombre, telefono, direccion, municipioId) 
VALUES ('Carlos G�mez', '1122334455', 'Avenida 789', 5); 

INSERT INTO aplicacion.Usuario (nombre, telefono, direccion, municipioId) 
VALUES ('Ana Mart�nez', '3107648324', 'Calle 987', 10); 

INSERT INTO aplicacion.Usuario (nombre, telefono, direccion, municipioId) 
VALUES ('Pedro L�pez', '3138078495', 'Carrera 654', 12); 
 
  