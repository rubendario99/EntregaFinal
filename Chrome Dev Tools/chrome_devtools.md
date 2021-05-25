# Chrome DevTools: Herramientas para el desarrollo

- Chrome DevTools es un conjunto de herramientas de creación web y depuración integrado en Google Chrome...
- El objetivo que buscamos al usar las DevTools es mejorar nuestro sitio web, depurarlo en busca de errores (si los hubiera) y crear perfiles de rendimiento de la misma
- Chrome DevTools se organiza en paneles. Cada uno de estos paneles nos da acceso a un grupo de funcionalidades.
- Versiones
	- Estable
	- Canary

## ¿Cómo acceder a las DevTools?

- Botón Derecho + Inspeccionar
- Ctrl+Shift+I (Windows & Linux)
- CMD+Opción+I (Mac)
- CMD+Opción+I (Mac)
- Consola Ctrl+Shift+J (Windows & Linux) CMD+Opción+J (Mac)

Podemos colocar este panel en 4 posiciones distintas.

## Paneles

Un panel es un conjunto de herramientas relacionadas entre sí que se muestran agrupadas en distintas pestañas.

### Descripción de los paneles
- Elements: Para trabajar en el diseño de mi página accediendo al DOM (HTML) y al CSS. 
- Console: Para trabajar con el JavaScript de la página (en caso de existir). 
- Sources: Para depurar JavaScript o trabajar con los WorkSpaces de Chrome Dev. Tools (conexión a archivos locales). 
- Network: Para analizar el rendimiento de mi página en relación al tráfico que genera.
- Performance & Memory : Para analizar el rendimiento y el perfil de consumo de memoria de mi página. 
- Application: Control y análisis de recursos cargados (Cookies, caché, IndexedDB etc..). 
- LightHouse: Herramienta para el análisis de mi web para la detección de posibles problemas. 
- Security: Para obtener información del uso del HTTP en mi página.

## Modo Device

Es la herramienta de las DevTools que nos va a permites ver cuál es el aspecto y el rendimiento de mi página en distintos tipos de dispositivos, ya sean unos prefijados o definidos por nosotros

### Opciones Generales

- Mostrar/Ocultar Media Queries. 
- Mostrar/Ocultar Reglas. 
- Controles para el Pixel/Ratio y Tipo de dispositivos. 
- Capturas de pantalla.

### Simular dispositivos

Para simular cómo queda mi página web puedo elegir entre una serie de dispositivos predefinidos o bien puedo crear dispositivos con las características que yo estime pertinentes.

### Más Opciones
- Rotar dispositivos
- Simular localización
- Simular condiciones de conectividad

## El Panel Elements

Desde el panel **Elements** vamos a poder trabajar tanto con el HTML de la página como con las hojas de estilos (**CSS**)

### Selección de elementos

- Seleccionar elementos visualmente
- Seleccionar elementos desde el teclado
- Scroll to View

### Modificación de la página

- Añadir/Editar atributos
- Editar HTML del nodo seleccionado
- Copiar/Cortar/Pegar diversos elementos

### Otras opciones

- Pantallazo
- Breakpoints JS
- Expandir/Colapsar
- Guardar elementos como variables

### Inspector CSS

Desde el inspector CSS podremos consultar y modificar los estilos CSS de los distintos elementos que conforman mi página

- Capas
- Cobertura CSS
- Animaciones
- Grid/~~Flex~~

### Workspaces

Es la herramienta de las DevTools que me va a permitir persistir los cambios que haga en la página en una copia web en la que estoy haciendo esos cambios

### ¿Qué cambios puedo guardar?

- HTML
- CSS
- JavaScript

### Requisitos

- Una página con la que trabajar
- Las DevTools
- Un servidor web local 

### Proceso

- Arrancar el servidor web
- Seleccionar la carpeta desde WorkSpaces
- Realizar cambios
- Aplicar cambios

### Problemas / Limitaciones

- Código de los Frameworks (source maps)
- No funciona con React

## Consola JavaScript

Herramienta de Chrome DevTools para depurar durante el desarrollo o como intérprete JavaScript para interactuar con la pagina que se ha cargado y con sus ficheros

### ¿Cómo accedo a la consola?
- Ctrl+Mayús+J (Windows/Linux) 
- Cmd+Opt+J (Mac) 
- Desde la Paleta de Comandos (Ctrl+Mayús+P) 
- ESC estando en cualquier otro panel

### ¿Qué puedo hacer desde la consola?
 - Ver mensajes de Log causados por nuestro código Js. 
 - Ejecutar todo tipo de código Js. 
 - Crear nuestras propias LiveExpressions y tener mi biblioteca de código en DevTools.
 - Acceder directamente al código Js que causó los mensajes para poder depurarlo.
 
 ### Ejecutando JavaScript

- **REPL**
	- **R**ead
	- **E**valuate
	- **P**rint
	- **L**oop

Podemos en cualquier momento probar código JavaScript que no tenga nada que ver con la página en la que estoy para testear, para experimentar características de Js etc...

Podremos modificar el DOM...

### Utilizando la consola

Utilizando el Console API puede mostrar mensajes desde mi código Js en la consola

### Funciones para logs

- console.log() / .debug() /.info() 
- console.warn() 
- console.error() 
- console.group() / .groupCollapse() / .groupEnd()
- console.table() 
- console.trace() 
- console.assert() 
- console.dirxml() / .dir()

Usando las flechas de arriba y abajo tengo acceso al histórico de comandos ejecutados

### Filtros

- url:http……. Muestro mensaje de una URL. 
- url:http…...Oculto menajes de una URL.
- Literales. 
- Expresiones Regulares.

### Live Expressions

Expresiones Js que consulto de manera repetida y que guardo para tenerlas siempre visibles

- Algunos ejemplos:
	- Ver el valor del campo password.
	- Ver el elemento que tiene el Foco. 
	- Mostrar fecha. 
	- Mostrar cookies. 
	- Juegos de caracteres.


### Opciones de la consola y snippets

- $_ -> Última expresión evaluada 
- $0 - $4 -> Últimos elementos del DOM seleccionados 
- clear() -> Borra la consola 
- $(selector…) -> document.querySelector()
- debug(function) / undebug(function()) -> Comienza depuración al iniciar esa función

#### Utilities API

- copy(element) -> Copia elemento(String) en portapapeles 
- monitor(function() ) / unmonitor(function() ) -> “Logea” llamadas a funciones. 
- inspect(elemento) -> Abre un elemento DOM/JS 
- getEventListener(element) -> Manejadores de eventos

#### Opciones de consola

- Hide Network
- Preserve Log
- Selected Context Only
- Group Similar
- Log XHMLHttpRequests
- Eager Evaluation
- Autocomplete from history 
- Evaluate triggers user activation

#### Snippets

Código Js que uso muchas veces en la consola y decido guardarlos en el panel Sources de JavaScript

### Depurando JavaScript

Para depurar y encontrar los errores en mi código Js debo entrar el panel Source de Chrome Dev Tools

#### Formas de depuración

- Utilizando los distintos tipos de Breakpoints
	- Un breakpoint es una parada intencionada en un programa para depurar y obtener información de dicha ejecución (contenido de las variables, pila de llamadas a funciones etc...)

#### Tipos de Breakpoints

- En línea de código.
- En línea de código de manera condicional. 
- Modificaciones del DOM. 
- En peticiones asíncronas. 
- Eventos dentro del navegador.
- En excepciones.
- En función.

También es posible la depuración remota