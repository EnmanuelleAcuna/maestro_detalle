DECLARE @conceptos AS DATOS_CONCEPTO
INSERT INTO @conceptos (Id, Nombre, Cantidad, Precio)
VALUES (1, 'Papas', 10, 10)
INSERT INTO @conceptos (Id, Nombre, Cantidad, Precio)
VALUES (2, 'Coca', 5, 5)

EXEC SP_GUARDAR_VENTA 'Amelie Acuna', @conceptos

SELECT * FROM VENTAS

SELECT * FROM CONCEPTOS