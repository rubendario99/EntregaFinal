# Creación y administración de BBDD

## Repaso sentencias SQL

- Estructurado (**S**tructured)
- Normalizado (casi estándar)
	- Comandos (SELECT, INSERT)
	- Cláusulas (FROM, WHERE)
	- Operadores (DISTINCT, LIKE)

## Sintaxis SQL

- No sensitivo a mayúsculas
- Usar **;** para terminar consultas
- Comentarios (puede variar en cada SGBDR): /* */

## Operadores de comparación

- = / > / < / >= / <= / <> (!= en algunos DBMS)
- Operador LIKE + wildcards (%)
	- SELECT * FROM film WHERE title LIKE '%LOVE%' ;
- Operador IN vs igualdad (=)
	- SELECT * FROM actor WHERE last_name IN ('ALLEN','MCCONAUGHEY','PALTROW') ;
- Ejemplo consulta:
	- SELECT title AS 'film name', rental_rate AS price FROM film WHERE (length BETWEEN 90 AND 120) AND (rental_rate <=3 OR replacement_cost <15) ORDER BY price DESC, title ;

## Funciones de agregado 

- SELECT count(*) AS 'Clientes Activos' FROM customer WHERE active=1;
- SELECT max(rental_rate) AS ‘Precio máximo’ FROM film ;
- SELECT count(film_id), rental_rate FROM film GROUP BY rental_rate ;
- SELECT count(film_id), rental_rate FROM film WHERE replacement_cost <= 20 GROUP BY rental_rate ORDER BY rental_rate DESC ;

**Importante** :  Si requerimos de agrupación, no podemos exigir detalle y viceversa

## Consultas sobre más de una tabla

- Inner join
- Left join
- Right join
- Full outer join

## DML Consultas de Acción

- **Insert** 
	- INSERT INTO actor (last_name, first_name) VALUES ('DE LA    CALZADA’,'CHIQUITO') ;
- **Update** 
	- UPDATE actor SET first_name = 'TXIKITO', last_name = 'DE LA  KALZADA' WHERE last_name = 'DE LA CALZADA' ;
- **Delete**
	- DELETE FROM actor WHERE last_name = 'DE LA KALZADA' ;

**Importante** : Son consultas altamente peligrosas si se construyen sin WHERE o erróneo!

## Iniciación al diseño de BBDD

- Diagramas ER / EER
- Esquema lógico BBDD
- Objetos de una Base de Datos
	- Tablas
		- Campos (columnas) – Tipo de datos 
		- Registros (filas)
	- Relaciones
		- 1 - 1
		- 1 - n
		- n - n
	- Índices, claves y restricciones (constraints)
	- Consultas / Vistas
	- Formularios
	- Otros
		- Procedimientos / Triggers (disparadores)
	
	- Restricciones
		- **NOT NULL** – Obliga a rellenar el campo
		- **UNIQUE** – Asegura que todo los valores son diferentes
		- **PRIMARY KEY** – Clave principal. De hecho, una combinación de NOT NULL + UNIQUE. Identifica unívocamente cada fila en una table.
		- **FOREIGN KEY** – Clave foránea. Relaciona unívocamente al registro de otra tabla
		- **CHECK** – Establece reglas de validación para los datos
		- **DEFAULT** – Valor por defecto
		- **INDEX**– Acelera las búsquedas bajo este campo.


## Lenguaje Definición de Datos (DDL)

- Crear nueva base de datos:
	- CREATE DATABASE testDB;
- Crear nueva tabla, sintáxis genérica:
	- CREATE TABLE nombre_tabla ( columna1 datatype, columna2 datatype, .... ) ;
- CONSTRAINTS: Restricciones más habituales
	- **NOT NULL** – Obliga a rellenar el campo
	- **UNIQUE** – Asegura que todo los valores son diferentes 
	- **PRIMARY KEY** – Clave principal. De hecho, una combinación de NOT NULL + UNIQUE. Identifica unívocamente cada fila en una table. 
	- **FOREIGN KEY** – Clave foránea. Relaciona unívocamente al registro de otra tabla  
	- **CHECK** – Establece reglas de validación para los datos
	- **DEFAULT** – Valor por defecto 
	- **INDEX**– Acelera las búsquedas bajo este campo.
- Ejemplo, script creación tabla actor:

	> CREATE TABLE actor ( actor_id SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT, first_name VARCHAR(45) NOT NULL, last_name VARCHAR(45) NOT NULL, last_update TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP, PRIMARY KEY (actor_id), KEY idx_actor_last_name (last_name) );