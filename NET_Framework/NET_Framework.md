# Curso .NET Framework

## Introducción

### ¿Qué es?

- Entorno de ejecución administrado para Windows que proporciona diversos servicios a las aplicaciones en ejecución. Consta de dos componentes principales: **Common Language Runtime (CLR)**, que es el motor de ejecución que controla las aplicaciones en ejecución, y la biblioteca de clases

- Se puede programar en: 
	- C#
	- F#
	- Vb

## SQL Server

Microsoft **SQL Server** es un sistema de gestión de base de datos relacional desarrollado como un producto de software con la función principal de almacenar y recuperar datos según lo solicitado por otras aplicaciones

## Entity Framework

Es una tecnología desarrollada por Microsoft, que a través de **ADO.NET** genera un conjunto de objetos que están directamente ligados a una Base de Datos, permitiendo a los desarrolladores manejar dichos objetos en lugar de utilizar lenguaje SQL contra la Base de Datos

## Arquitectura de proyectos por capas

La **arquitectura** basada en **capas** se enfoca en la distribución de roles y responsabilidades de forma jerárquica proveyendo una forma muy efectiva de separación de responsabilidades. El rol indica el modo y tipo de interacción con otras **capas**, y la responsabilidad indica la funcionalidad que está siendo desarrollada.

Una de las implementaciones más conocidas es MVC:

	- Modelo -> datos
	- Vista -> presentación
	- Controlador -> lógica

## Creación y modelado SQL Server

- Crear tablas
- Normalizar modelo
- Creación y modificación de registros
- Consultas y procedimientos almacenados
- Copiar y restaurar copias de seguridad

## Generar modelo EDMX

El archivo **.edmx** es propio de **Entity Framework** y puede decirse que es el mapeo de tu base de datos convertida a un lenguaje de programación, en este caso **C#**.

No sustituye a la base de datos, simplemente es el modelo de tu base de datos según como la hayas definido

## Creación de operaciones CRUD

El concepto CRUD está estrechamente vinculado a la gestión de datos digitales. CRUD hace referencia a  **un acrónimo**  en el que se reúnen las primeras letras de las cuatro operaciones fundamentales de aplicaciones persistentes en sistemas de bases de datos:

-   **C**reate (Crear registros)

-   **R**ead   (Leer registros)

-   **U**pdate (Actualizar registros)

-   **D**elete (Borrar registros)

## Debug, compilación y publicación

- Debug:
	- Su objetivo es encontrar errores que pueden impedir que los códigos funcionen de forma adecuada. Con este, es posible determinar lo que está ocurriendo dentro del código fuente y obtener sugerencias de acciones para mejoras.

- Compilación: 
	- se denomina la fase de codificación en que un programa es traducido del código fuente al código máquina para que pueda ejecutarse
	
- Publicación:
	- mediante este procedimiento se pone a disposición de cualquier usuario con acceso a Internet las páginas web del centro o proyecto al pasar a estar alojadas físicamente en un ordenador servidor con acceso permanente desde Internet.