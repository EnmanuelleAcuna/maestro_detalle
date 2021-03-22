USE maestro_detalle
GO

CREATE TYPE DATOS_CONCEPTO AS TABLE (
	Id INT,
	Nombre VARCHAR (50),
	Cantidad INT,
	Precio DECIMAL (18, 2),
	PRIMARY KEY (Id)
)
GO