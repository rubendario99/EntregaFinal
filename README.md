# EntregaFinal

## SQL desde Cero

### Objetos BBDD
- Tablas
  - Campos (columnas)
  - Registros (filas)
- Relaciones
  - 1 - 1
  - 1 - n
  - n - n
- Índices, claves, constranints
- Formularios
- Procedimientos/Triggers

### SQL (Structured Query Language)
- Modelo Relacional Codd 1970
- IBM crea primera versión en 1974
- 1986 entra en el estándar ANSI
- 2016, última revisión
- No todas las empresas siguen el estándar

### Sublenguajes SQL
- DDL - Data Definition Language
  - CREATE
  - ALTER
  - DROP
- DMl - Data Manipulation Language
  - GRANT
  - REVOKE
- DCL - Data Control Language
  - SELECT
  - INSERT
  - UPDATE
- TCL - Transaction Control Language
  - BEGIN
  - COMMIT
  - ROLLBACK

### DML (Data Manipulation Language)
- Sintaxis normalizada
  - Comandos   (select, insert...)
  - Cláusulas  (from, where...)
  - Operadores (distinct, like...)
- No sensitivo
- Recomendando ';', al final de las consultas aunque no sea obligatorio

### Operadores Lógicos
- AND
- OR
- NOT
- IN

### Consulta UNION
Permite crear consultas de varias tablas en una sola con datos no repetidos

### Subconsulta
Consulta que se realiza dentro de otra consulta

Ejemplo: SELECT lastName,firstName FROM employees WHERE officeCode **IN** (SELECT officeCode FROM offices WHERE country = 'USA');

## Funciones Escalares
Son funciones que retornan un único valor
- Ejemplos:
  - LCASE()
  - CONCAT()
