Crear BD en Microsoft SQL Server con el nombre de InventarioPerecederosDB
Estas son las tablas
-- Crear tabla Productos CREATE TABLE Productos ( Id INT IDENTITY(1,1) PRIMARY KEY, Nombre VARCHAR(255) NOT NULL, Descripcion VARCHAR(500) NULL, Categoria VARCHAR(100) NULL, FechaCaducidad DATE NOT NULL, CantidadInicial INT NOT NULL, Estado VARCHAR(50) NOT NULL,
PrecioUnitario DECIMAL(18, 2) NULL );

-- Crear tabla Entradas CREATE TABLE Entradas ( Id INT IDENTITY(1,1) PRIMARY KEY, IdProducto INT NOT NULL, FechaEntrada DATE NOT NULL, Cantidad INT NOT NULL, Proveedor VARCHAR(255) NULL, PrecioTotal DECIMAL(18, 2) NULL, FOREIGN KEY (IdProducto) REFERENCES Productos(Id) ON DELETE CASCADE );

-- Crear tabla Salidas CREATE TABLE Salidas ( Id INT IDENTITY(1,1) PRIMARY KEY, IdProducto INT NOT NULL, FechaSalida DATE NOT NULL, Cantidad INT NOT NULL, MotivoSalida VARCHAR(255) NOT NULL, - PrecioTotal DECIMAL(18, 2) NULL, FOREIGN KEY (IdProducto) REFERENCES Productos(Id) ON DELETE CASCADE );

Luego de clonar el repositorio en visual studio, validar el puerto y cambiarlo en el front en el TS C:\Users\caggonzalez\source\repos\FrontIKBO\src\app\services\producto.service.ts en la linea 23
