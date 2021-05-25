# Curso jQuery

## Glosario de Términos

- **Árbol HTML**:
	- Es la representación de una página HTML en forma de árbol jerárquico cuyo elemento raíz es la etiqueta .
- **Script**:
	- Elemento ejecutable (pequeño programa) dentro de mi página HTML, normalmente en javascript y que se incluye dentro dentro de la etiqueta
- **Evento**:
	- Acción que sucede en un navegador y que está relacionada con el procesos del propio navegador (carga de una página, impresión, error…), o con interacciones del usuario que visualiza una página web
- **Ajax**:
	- Comunicación asíncrona (en segundo plano) de una web que me van a permitir actualizar ciertas partes de mi página web sin tener que recargar la página entera.

## ¿Qué es jQuery?

### write less, do more… 
Fast, small, and feature-rich JavaScript library. It makes things like HTML document traversal and manipulation, event handling, animation, and Ajax much simpler with an easy-to-use API that works across a multitude of browsers….

### Características

- Manipulación del DOM. 
- Selectores avanzados.
- Eventos.
- Efectos y animaciones. 
- Ajax
- Parseado json. 
- Extensible (plugins). 
- Compatibilidad para navegadores. 
- Sencillo

### Desventajas

- Ya no es necesario (estandarización API en navegadores). 
- Rendimiento no es óptimo (acceso continuo al DOM, no virtual) 
- Abandonada por BootStrap 5 y gitHub
- Sintaxis que puede producir código poco legible . (proyectos grandes) 
- Nuevos frameworks (React, Angular, Vue)


## Entendiendo el DOM

Es una API para documentos HTML y XML. Proporciona una representación estructurada del documento permitiendo la modificación de su contenido o presentación visual. También comunica las páginas webs con los scripts.

### Árbol HTML

Es la representación de una página HTML en forma de árbol jerárquico cuyo elemento raíz es la etiqueta **< HTML >**

- Antecesor
- Descendiente
- Padres e hijos
- Hermanos

### API DOM

- Referenciar objetos. (document.getElementById(“...”) ) 
- Modificar las propiedades y funciones. ( obj.color = “#FFF” )
 - Responder a eventos. (< element onevent="some_script">...</...>)
 
 jQuery hace todo esot más sencillo y directo

## Instalación de jQuery

Para empezar usar a  **jQuery**  en mi página web y, de esta manera, poder dotarla de vida e interactividad lo primero que tengo que hacer es  _instalar_  **jQuery**  en mi proyecto para que dicha librería esté disponible cuando se carga la página.

Lo primero que tenemos que hacer es descargar  **jQuery**  desde la siguiente  [página](https://jquery.com/downloads). Actualmente la versión disponible es la versión 3.4.1.

En esa página encontraremos varias cosas pero para empezar elegiremos entre una de estas dos opciones:

-   jQuery  **_compressed_**  que es la más adecuada para producción. Ocupa menos espacio pero es prácticamente ilegible.
-   jQuery  **_uncompressed_**  que es la más adecuada para desarrollo. Ocupa más espacio pero es legible y podremos consultar el código de jQuery si es necesario.

Una vez hemos descargado ese fichero tendremos que añadirlo a nuestra página. Esto se hará en el código HTML de la siguiente manera:

```
<!-- DENTRO DE LA CABECERA>
<head>
    ....
    <!-- o la versión uncompressed -->
    <!-- hemos colocado el fichero en la carpeta js -->
    <script src="js/jquery-3.4.1.js"></script>
    ....
</head>

```

Podemos comprobar fácilmente que todo está correcto desde la consola que nos proporcionan todos los navegadores dentro de sus herramientas para desarrolladores. Dentro de esa consola puedo ejecutar cualquiera de estas dos opciones para comprobarlo:

```
$();

jQuery;

```

En caso de que nos devuelva algo diferente de  _null_  (en el primer caso) o *_jQuery is no defined_  (en el segundo caso) es que todo está correcto. Y si está correcto es muy interesante que profundicéis en lo que se os muestra ya que contiene todo lo que nos puede proporcionar la librería.

Una vez hemos hecho esta  _instalación_  ya podemos crear nuestros scripts usando la librería  **jQuery**. Estos scripts los añadiremos al final de \

### Instalación Remota

De la misma manera que nos hemos descargado  **jQuery**  para usarlo en nuestro proyecto podemos usar jQuery remotamente usando la copia almacenada en un  **CDN**. Este CDN puede ser de varios proveedores como  _Microsoft_,  _Google_  etc…

Esto se hará en el código HTML de la siguiente manera:

```
<!-- DENTRO DE LA CABECERA>
<head>
    ....
    <!-- o la versión uncompressed -->
    <!-- usando el CDN de Google -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    ....
</head>

```

Pero exactamente, ¿qué es esto de un CDN?:

Un  _**CDN**_  _(Content Delivery Network)_  es una red de servidores distribuidos geográficamente que actúan como  _caché_  , normalmente para achivos de uso frecuente, y que mejoran la velocidad de navegación de los usuarios.

De igual manera que cuando lo instalamos localmente, podemos comprobar fácilmente que todo está correcto desde la consola que nos proporcionan todos los navegadores dentro de sus herramientas para desarrolladores. Dentro de esa consola puedo ejecutar cualquiera de estas dos opciones para comprobarlo:

```
$();

jQuery;

```

En caso de que nos devuelva algo diferente de  _null_  (en el primer caso) o *_jQuery is no defined_  (en el segundo caso) es que todo está correcto. Y si está correcto es muy interesante que profundicéis en lo que se os muestra ya que contiene todo lo que nos puede proporcionar la librería.

Y para usarla la librería en este caso la usaremos de la misma manera que lo hacíamos cuando instalábamos  **jQuery**  para ser usada de manera local.

### Versiones de jQuery

- **Compressed** : menor tamaño. Ilegible. Ideal para producción.
- **Uncompressed** : mayor tamaño. Legible. Ideal para desarrollo.
- **Normal** : librería completa
- **Slim** : no contiene los módulos Ajax ni el módulo de Efectos.
- **jQuery Mobile** : framework CSS basado en jQuery para el diseño de páginas web responsivas para dispositivos móviles y que tiene soporte para pantallas táctiles.
- **jQuery UI** : librería de componentes para jQuery que permite añadir widgets, plugins y efectos a nuestra página web.

## Selectores jQuery

Para poder dotar de vida e interactividad a nuestra página web lo primero que debemos hacer siempre es seleccionar los elementos con los que vamos a trabajar.

Para poder realizar esta selección con  **jQuery**  podremos usar tanto los selectores de  _CSS3_  como una serie de selectores propios.

En este capítulo y en el siguiente vamos a recordar los selectores  _CSS3_  más comunes.

Tanto para estos selectores de  _CSS3_  como para los selectores propios de  **jQuery**  la forma de trabajar suele ser siempre la misma, una de estas dos iteraciones:

-   **Selección - Acción**  (ocultar, cambiar propiedades, aplicar efectos etc..).
-   **Selección - Añadir Handler de Evento**.

Si ponemos esto con síntaxis de  _jQuery_  nos quedará como en la siguiente imagen:

![](https://dc722jrlp2zu8.cloudfront.net/media/uploads/2020/02/07/iteraccion_seleccion_accion.png)

Es entre las  **“”**  donde nosotros incluiremos los selectores.

### Selectores CSS más comunes I

Una vez hemos fijado la forma de trabajar vamos a repasar los selectores más frecuentes. Empezaremos en este capítulo y continuaremos en el siguiente.

-   ***** : El selector universal.
-   **etiqueta**  : Para seleccionar una etiqueta en concreto.
-   **#id**  : Elementos con un id determinado.
-   **.clase**  : Elementos con una clase determinada.
-   **elemento1 elemento2**  : Elementos que se encuentran anidados dentro de otro elemento.
-   **elemento1 > element2**  : Elementos que son hijos directos de un elemento dado.
-   **elemento1 + elemento2**  : Hermanos contiguos. El elemento2 sigue al elemento 1.
-   **elemento1 ~ elemento2**  : Hermanos aunque no sean adyacentes.
-   **Selectores de atributos**  con todas las combinaciones posibles [attr][attr=”value”] (o usando | ~ ^ etc..)

Si queremos conocer más selectores os recomiendo este enlace:

[https://developer.mozilla.org/es/docs/Web/CSS/Selectores_CSS](https://developer.mozilla.org/es/docs/Web/CSS/Selectores_CSS)

### Selectores que devuelven más de un elemento

Es importante destacar que cuando seleccionamos elementos el selector nos puede devolver uno o varios elementos.

En algunos casos podemos querer escoger un único elemento de entre todos los seleccionados. Eso se hace con la función  **.eq(index)**  aplicada después del selector. Con  _index_  especificaremos la posición del elemento (empezando en la posición 0) que queremos seleccionar entre todos los devueltos por el selector.

Un ejemplo práctico podría ser el siguiente:

```
$(function() {
  //Ocultamos el tercer elemento de lista encontrado
  $("li")
    .eq(2)
    .hide();
});

```

Esa concatenación de funciones después de la selección se llama  **CHAINING**  y veremos que lo usaremos mucho en jQuery (y de manera general en javascript).

En capítulos posteriores veremos como filtrar y encontrar elementos usando otras funciones.

Además de los vistos en el apartado anterior otros selectores CSS (pseudoselectores o pseudoelementos en este caso) que son muy usados son los siguientes:

-   **:hover**  : Para seleccionar el elemento sobre el cual paso el cursor del ratón.
-   **:visited**  : Para seleccionar los enlaces visitados.
-   **:first-of-type o :first-child**: Para seleccionar el elemento de un tipo determinado que es el primero de ese tipo dentro del padre o para seleccionar el elemento determinado que es el primer hijo de un padre determinado.
-   **:last-of-type o :last-child**: Análogo al anterior pero haciendo referencia al último y no al primero.
-   **:nth-child(pos) o :nth-of-type(pos)**  : Análogo a los anteriores pero especificando la posición en la que se encuentra el elemento o el hijo como parámetro (pos).
-   **:required**  : Para seleccionar cualquier elemento de un formulario que sea requerido.
-   **::after**  : Usado para añadir algo (con la propiedad content) después de algún elemento determinado.
-   **::before**  : Usado para añadir algo (con la propiedad content) antes de algún elemento determinado.

Recordad que este tipo de selectores, a los que se llama  _pseudoselectores_  o  _pseudoelementos_  son añadidos a los selectores que hemos visto en el apartado anterior. Por ejemplo para  **:hover**  podríamos usarlo de la siguiente manera:

```
    ...
    //Al pasar el ratón por la etiqueta h1
    $("h1:hover")...
    ...
```

### Selectores Propios de jQuery

Como ya hablamos en capítulos anteriores, a la hora de seleccionar elementos usando  **jQuery**  podemos usar los selectores CSS3 o también una serie de selectores propios.

De igual manera que CSS con sus selectores,  **jQuery**  tiene bastantes selectores propios (pseudoselectores en su mayoría, en realidad). En este y en el próximo capítulo únicamente vamos a ver los más comunes o destacados.

Entre ellos:

-   **:eq(index)**  : Para seleccionar el elemento que está en la posición  _index_  de entre todos los seleccionados con el selector del que es sufijo. Actualmente está depreciado y se usa la función  _.eq()_  que ya ha sido tratada previamente.
-   **:has(“…)**  : Para elementos que contienen dentro al menos un elemento del selector que le paso como parámetro.
-   **:contains()**  : Todos los elementos que contienen un texto en concreto.
-   **:even o :odd**  : Para elementos que dentro del padre están en la posición para o impar. Son selectores depreciados pero siguen siendo muy usados.
-   **:input**  : Para seleccionar cualquier elemento de un formulario, ya sea un  _input_,  _textarea_,_select_  o  _button_.
-   **:gt(index) o :lt(index)**: Para seleccionar elementos cuya posición entre los elementos seleccionados es mayor(gt) o menor(lt) que la posición expresada en index.
-   **:first o :last**  : Para seleccionar el primero o el último de los elementos seleccionados por el sufijo selector. Están también depreciadas y en su lugar se usan las funciones  _.first()_  o  _.last()_  haciendo  **chaining**.

Recordad también dos conceptos que habíamos destacado:

-   La  _iteración Selección-Acción o Selección-Captura de evento_  que será nuestra formá típica de trabajar cuando estemos dando vida a nuestra página web con  _jQuery_.
-   El concepto de  **CHAINING**.

Además de los vistos en el apartado anterior otros selectores (pseudoselectores en realidad)  **jQuery**  que son muy usados son los siguientes:

-   **:button, :file, :radio, :reset**  : Para seleccionar cualquier tipo de botón (_\_

En ocasiones con los elementos seleccionados queremos hacer cosas muy similares pero con ligeras diferencias.

Un enfoque posible para eso sería algo así:

```
    $(function() {
        ...
        $("some_selector").eq(0).accion0..
        $("some_selector").eq(1).accion1..
        $("some_selector").eq(2).accion2..
        ...
        $("some_selector").eq(n).accionn..

    });

```

Una aproximación de este tipo presenta principalmente dos problemas.

-   Es muy  **ineficiente**, sobre todo si tenemos dentro de las acciones partes que se repiten.
-   Tenemos que ir seleccionando  **uno por uno**  los elementos que nos ha devuelto el selector. Y, en ocasiones, sobre todo si la página se genera automáticamente a partir de fuentes de datos externas, no podemos saber cuántos elementos nos va a devolver el selector.

Para dar solución a este tipo de situaciones  **jQuery**  pone a nuestra disposición el método  _**.each()**_  y el objeto  _**$(this)**_.

Lo que expresamos en el ejemplo lo podremos expresar, de un manera más eficiente y sin saber el número de elemento que nos va a devolver el selector, de la siguiente manera:

```
    $(function() {

        $("some_selector").each(funcion(index) {
            //Acción que dependerá del elemento
            $(this).accion_particular...
        });
    });

```

En este ejemplo destacamos:

-   **.each(..)**  recibe como parámetro una función que se ejecutará una vez para cada una de los elementos que nos devuelva el selector.
-   **index**  es un parámetro opcional de la función. Indica la posición que ocupa cada elemento dentro del conjunto de elementos devueltos (empezando en cero).
-   **$(this)**  hace referencia cada vez que se ejecuta la función. Al objeto que se está tratando actualmente de entre los devueltos por la selección.

Podemos concretar esto con un ejemplo concreto.

```
$(function() {
    ...
    $(“li”).each(function(index) {
        console.log("El elemento  "+index+"contiene "+$(this).text());
        $(this).text("HOLA");
    }
}

```

En este ejemplo la función se ejecutará tantas veces como etiquetas \

## CSS: Atributos y estilos

Una de las grande ventajas de  **jQuery**  es la facilidad que nos da tanto para  **obtener**  como para  **modificar**  los  **estilos**  de los diferentes elementos de nuestra web.

### La función .css(..)

La función principal de  **jQuery**  para trabajar con estilos es  **_.css()_**  y cuando trabajemos con ella podemos diferenciar principalmente dos situaciones:

-   Cuando trabajemos con  **una única propiedad**  CSS para obtener o establecer.
-   Cuando trabajemos para establecer u obtener el valor de  **más de una propiedad**  CSS.

Para una propiedad:

```

//Obtener el valor de una sola propiedad
//MUY IMPORTANTE: La propiedad se obtiene del PRIMER ELEMENTO que nos devuelve el selector.
var valor =  $("some_selector").css("propiedad");

//Ejemplo
var color = $("li").css("color");

//Establecer el valor de una propiedad para todos los elementos que nos devuelve el selector
$("some_selector").css("propiedad","valor");

//Ejemplo (Incremento en 50px el valor actual)
$("img").css("width","+=50");


//Pasando una funcíon que recibe como parámetros la posición dentro de los seleccionado y el antiguo valor
$("some_selector").css("propiedad",function(index, valor))  {
    //$(this) hará referencia el elemento actual
});

```

Para varias propiedades:

```

//Si queremos obtener varias propiedades CSS del PRIMER ELEMENTO que nos devuelva el selector
//Devuelve una ARRAY
var props = $("some_selector").css([ "prop1","prop2",....."propn"]);

//Ejemplo 
var colores = $("li").css(["color","background-color"]);

//Para establecer el valor de varias propiedades en los elementos seleccionados 
$("some_selector").css( {
    prop1: valor1, //o expresión/función
    prop2: valor2, //o expresión/función
    ....
    propN: valorn //o expresión / función
});

//Ejemplo
$("li").css({
    color: #FFF,
    background-color: #000
});

```

### Funciones adicionales

Además de la función  **_.css()_**  tenemos a nuestra disposición dos funciones más para trabajar con la anchura y la altura de los elementos:

-   La función  **.width()**.
-   La función  **.height()**.

Lo que podemos hacer con estas funciones también podemos hacerlo con la función  **.css()**  y de igual manera no sirven para obtener o establecer la altura y la anchura.

```

//Obtener el valor de las propiedades del primer elemento de entre los seleccionados
var altura = $("some_selector").height();
var anchura = $("some_selector").width();


//Para modificar la altura o anchura de todos los elementos seleccionados
$("some_selector").height("(valor");
$("some_selector").width("(valor");
```

Si ya tenemos nuestra hoja de estilos perfectamente definida podemos usar las clases de esa hoja de estilos para , con funciones  **jQuery**, cambiar la apariencia de los elementos de mi página web.

Las funciones más comunes para este tipo de acciones son:

-   **_.addClass()_**: Para añadir clases CSS a los elementos seleccionados.
-   **_.removeClass()_**: Para eleminar clases CSS de los elementos seleccionados.
-   **_.toggleClass()_**: Para alternar que una clase esté o no esté en los elementos seleccionados.
-   **_.hasClass()_**: Para saber si una clase está en  **CUALQUIERA**  de los elementos seleccionados.

### .addClass()

Esta función de  **jQuery**  nos permite añadir una o varias clases a los elementos seleccionados.

Tenemos varias posibilidades:

```

//Le pasamos uno o varios nombre de clases a añadir a los elementos seleccionados
$("some_selector").addClass("clase1 clase2 ...claseN");

//Le pasamos una función que se aplica a cada elemento seleccionado.
// Disponemos de la posición del elemento (index) y de $(this) para hacer referencia al elemento tratado
// El valor devuelto será el nombre de la clase que se va añadir al elementos en concreto
$("some_selector").addClass(function(index) {
    ...
    return "some_className";
    ...
});

```

Un ejemplo para cada uno de estos casos:

```

    //Añade las clases btn y btn-error a todos los elementos <button>
    $("button").addClass("btn btn-error");

    //Le añade a cada elemento <section> la clase section-X (según su posición en el conjunto de los elementos seleccionados)
    $("selection").addClass(funcion(index) {
        return "section-"+index;
    });

```

### .removeClass()

Esta función de  **jQuery**  nos permite borrar una o varias clases de los elementos seleccionados. Evidentemente es necesario que los elementos tengan esa clase o clases para poder eliminarlas.

Tenemos varias posibilidades:

```

    //Le pasamos uno o varios nombres de clases a borrar
    $("some_selector").removeClass("clase1, clase2,...,claseN");

    //Le pasamos una función que se aplica a cada elemento de entre los elementos seleccionados
    // y cuyo valor devuelto será la clase que se pretende borrar en cada elemento. 
    //Le pasamos la posición y tendremos disponible $(this).
    $("some_selector").removeClass(function(index) {
        ...
        return "someClassName";        

    });

```

Un ejemplo para cada uno de estos casos:

```

    //Borra las clases btn y btn-error de los elementos <button> en caso de que las tengan
    $("button").removeClass("btn btn-error");

    //Borra de cada elemento section la clase "section-index" en caso de que la tengan. Index es la posición que ocupan dentro del conjunto de elementos que devuelve el selector.
    $("button").removeClass(function(index) {
        return "section-"+index;
    });

```

### .toggleClass()

Esta función sirve para añadir o quitar clases dependiendo de si esas clases están presentes o no o dependiendo de parámetros que se le pasan.

Tenemos varias posibilidades:

```

    //Le pasamos el nombre de las clases de las que queremos alternar el estado. Es decir se añaden si no están o se quitan si están
    $("some_selector").toggleClass("clase1 clase2 ...claseN");

    //Igual que el anterior pero con un parámetro boleano (que puede ser el resultado de una función) que nos dice si hay que añadirla (true) si no está o quitarla si está (false)
    $("some_selector").toggleClass("clase1 clase2 ..claseN",booleano);

    //Pasándole una función cuyo valor de retorno será el nombre de la clase cuyo estado queremos alternar. Esa función recibe como parámetros la posición de cada elemento dentro del conjunto de elementos seleccionados.Tengo acceso a $(this).
    $("some_selecto").toggleClass(funcion(index) {
        ...
    });

    //Análoga a la anterior pero con un parámetro booleano adicional que indica si hay que añadirla (true) si no está o quitarla si está (false). Tengo acceso a $(this).
    $("some_selecto").toggleClass(funcion(index) {

    },booleano);

```

Algunos ejemplos para estos casos:

```

    //Quita las clases si están en los elementos seleccionados o las añade si no están.
    $(“button”).toggleClass(“btn btn-error”);

    //Quita las clases en los elementos seleccionados si no están.
    $(“button”).toggleClass(“btn btn-error”,false);

    //Quita las clases "section-1...section-2..." en los elementos seleccionados si están o las añade si no están.
    $(“section”).toggleClass(function(index) {
        return “section-”+index;
    });

```

### .hasClass()

Esta función de  **jQuery**  devuelve  _TRUE_  si  **CUALQUIERA**  de los elementos seleccionado tiene esa clase y  _FALSE_  en caso de que ninguno de ellos la tenga.

```

    $(“some_selector”).hasClass(“clase1”);

    //Ejemplo
    $(“.btn”).hassClass(“btn-error”);
```

Continuando con el capítulo,  **jQuery**  también nos proporciona una serie de funciones que nos van a permitir modificar atributos y propiedades de los distintos elementos de mi página web.

### Atributos vs Propiedades

Antes continuar examinando la diferentes funciones hay que aclarar las diferencias que hay entre un atributo y una propiedad.

Los  **atributos**  nos dan información adicional sobre un elemento o etiqueta que está incluida en el HTML. Cuando lo obtenemos o modificamos hacemos referencia al  **valor o estado original**.

**LOS ATRIBUTOS ESTÁN EN EL HTML**

En relación a la  **propiedades**, son características de una instancia concreta de esa etiqueta en el DOM. Al obtenerlas o modificarlas estamos haciendo referencia al  **valor o estado actual**.

**NO ES NECESARIO QUE LAS PROPIEDADES ESTÉN EL HTML**  ya que los objetos al ser instanciados en el DOM tienen una serie de propiedades por defecto.

Para poder aclarar esto de una mejor manera vamos a ver un ejemplo:

```

    //Si tenemos el siguiente elemento en la página
    // <input id="ej" type="text" value="Pepe">

    console.log($("#ej").attr("value"));
    //Salida -> Pepe

    console.log($("#ej").prop("value"));
    //Salida -> Pepe

    console.log($("#ej").attr("disable"));
    //Salida -> undefined -> No está en el HTML

    console.log($("#ej").attr("disable"));
    //Salida -> false . No está pero es una propiedad del DOM

    //Modificamos el valo del elemento del DOM
    $("#ej").val("Manuel");

    console.log($("#ej").attr("value"));
    //Salida -> Pepe, el valor que tengo en el HTML

    console.log($("#ej").prop("value"));
    //Salida -> Manuel, el valor actual de la propiedad

```

En conclusión y para que no tengamos problemas:

-   No usar versiones anteriores a jQuery 1.6.
-   Usar siempre que sea posible las funciones que hacen referencia a propiedades. Aunque muchas veces nos vayan a dar resultados iguales.
-   Usar .attr() únicamente cuando sean atributos  _custom_, es decir que no van a tener propiedades asociadas.
-   Tener en cuenta que en los atributos siempre tenemos cadenas de caracteres pero que en las propiedades podemos tener otro tipo de datos.

Una vez ha quedado claro vamos a ver ejemplos de uso de las funciones más comunes en jQuery para trabajar con atributos y propiedades.

### .attr()

Esta función de  **jQuery**  sirve para obtener o establecer el valor de uno o varios atributos.

Vamos a ilustrar su uso con varios ejemplos.

```

    //Obtengo la dirección del PRIMER ENLACE
    //Obtengo el valor del atributo href
    var url = $("a").attr("href");

    //Todos los enlaces se abrirán en una nueva ventana
    //Establezco ese atributo para TODOS LOS enlaces
    $("a").attr("target","_blank");

    //Establezco dos atributos a la vez para 
    //el elemento con ese id (el selector podría devolver más elementos)
    $("#miprofile").attr({
        alt:"Foto de mi cara",
        title:"Foto hecha por mí")
    });

```

### .removeAttr()

Esta función de  **jQuery**  sirve para borrar atributos de los elementos seleccionados (en caso de que existan en los elementos)

Su sintaxis y un ejemplo:

```
    //Eliminar un atributo dado de los los elementos seleccionados
    $("some_selector").removeAttr("some_attribute");

    //Ejemplo
    //Quita el atributo required de todos los inputs (si es que lo tenían)
    $("input").removeAttr("required");

```

### .prop()

Esta función de  **jQuery**  sirve para obtener o modificar el valor de una o varias propiedades.

Su es uso es análogo a  _.attr()_  y lo podemos ver en el siguiente ejemplo:

```
    //Obtengo propiedad href del primer enlace
    var url = $("a").prop("href");

    //Todos los enlaces se abrirán en una nueva ventana
    //Pongo ese valor a la propiedad
    $("a").prop("target","_blank");

    //Establezco dos propiedades a la vez para una imagen que tiene un id
    $("#miprofile").prop({
        alt:"Foto de mi cara",
        title:"Foto hecha por mí")
    });

```

### .removeProp()

Esta función de  **jQuery**  sirve para eliminar propiedades de los elementos seleccionados.

Su uso es análogo a  _.removeAttr()_  y lo podemos ver en el siguiente ejemplo:

```
    //Eliminar una propiedad dada de los los elementos seleccionados
    $("some_selector").removeProp("some_attribute");

    //Ejemplo
    $("input").removeProp("required");
```

En los capítulos anteriores hemos  _respetado_  el árbol HTML y no hemos tocado el DOM. Nos hemos limitado a modificar estilos y atributos.

Pero…en ocasiones querremos modificar esa estructura añadiendo, borrando o modificando elementos del árbol o su contenido.

Afortunadamente  **jQuery**  nos proporciona muchas funciones para eso.

Estas funciones las vamos a agrupar en:

-   .empty(), .html() y .text()
-   .append(), .prepend(), .appendTo() , .prependTo()
-   .wrap(), .unwrap() , .wrapAll() , .wrapInner()
-   .val(). Luego hablaré de los motivos por los que he metido esta función aquí.

### .empty(), .html() y .text()

La función  **.empty()**  borra todos los nodos hijos(y su contenido) de los elementos seleccionados.

Un ejemplo sería el siguiente:

```

    $("ul").empty();

```

De tal manera que si tenemos esta estructura HTML inicial:

```
    <ul>
        <li>UNO</li>
        <li>DOS</li>
        <li>TRES</li>
    </ul>

```

La estructura resultante sería:

```
    <ul></ul>

```

La función  **.html()**  puede ser usada para obtener el  **contenido**  del  **primer elemento**  de los seleccionados. Esto quiere decir que obtendremos todo lo que va entre la apertura y el cierre de ese elemento.

Por ejemplo:

```
    //content contienen todo lo que va dentro de esa <li>. Posible etiquetas incluidas
    var content = $("li").html();

```

Además de para obtener el contenido, con esta función podemos modificar el contenido de  **TODOS**  los elementos seleccionados.

Vamos a ilustrar las diferentes posibilidades con ejemplos:

```

    //Hacer que el contenido de todas las listas sea un único elemento
    //Sustituye el contenido que tuviera
    $("ul").html("<li>UNO</li>);

    //Lo mismo pero usando una función que pone a nuestra disposición la posición dentro de los elementos seleccionados y el texto anterior.
    $("ul").html(function(index,oldText) {
        return "<li>"+index+"</li>";
    });

```

El uso de la función  **.text()**  es totalmente análogo a .html() pero con la diferencia de que trata todo como  **TEXTO**  y  **obvia las etiquetas**  quedándose únicamente con el contenido textual de los elementos.

### .append() / .prepend() / .appendTo() / .prependTo()

las funciones  **.append()**  y  **.prepend()**  son análogas en su funcionamiento. Ambas sirven para añadir nuevos elementos HTML a nuestro DOM.

La diferencia principal es que:

-   **.append(“contenido”)**  añade ese contenido justo al principio de los elementos seleccionados.
-   **.prepend(“contenido”)**  añade ese contenido justo al final de los elementos seleccionados.

Y cuando nos referimos al principio o al final nos referimos a justo después de la etiqueta de inicio de los elementos seleccionados o a justo antes de la etiqueta de cierre de los elementos seleccionados.

Se entiende mejor con esta imagen.

![](https://dc722jrlp2zu8.cloudfront.net/media/uploads/2020/02/06/appendyprepend.png)

Las funciones  **.appendTo()**  y  **.prependTo()**  funcionan de manera muy similar a las dos anteriores pero tenemos un par de cambios:

-   Donde antes estaba el contenido está el selector de los elementos en los cuales vamos a añadir contenido.
-   Donde antes estaba el selector tengo el contenido.

Se entiende mejor con una imagen análoga a la anterior pero usando estas funciones:

![](https://dc722jrlp2zu8.cloudfront.net/media/uploads/2020/02/06/appendtopreprendto.png)

### .wrap() / .unwrap() / .wrapAll() / .wrapInner()

La función  **.wrap()**  añade cierta estructura HTML alrededor de todos y cada uno de los elementos seleccionados.

Tiene varias posibilidades:

```

    //Envuelve todos los article con una estructura
    $("article").wrap("<div class="article_outer"></div>");

    //O usando una función que pone a nuestra disposición la posición dentro de los elementos seleccionados
    $("article").wrap(funcion(index) {
        return "<div class='article-"+index+"'></div>";
    });

```

Podemos entenderlo mejor con esta imagen:

![](https://dc722jrlp2zu8.cloudfront.net/media/uploads/2020/02/06/wrap.png)

La función  **.unwrap()**  hace justo lo contrario que .wrap().Elimina el padre y saca el hijo a la altura del árbol que estaba el padre.

Por lo tanto:

```
    //Deshacer el cambio anterior hecho con WRAP
    $("article").unwrap(); 
    //Si queremos comprobar que el padre cumple condiciones
    $("article").unwrap(".article_outer");

```

En relación a las otras dos funciones:

-   **wrapAll()**  es análogo a .wrap() pero sólo añade un elemento envolvente que cubre a todos los seleccionados. Debemos tener cuidado si hay elementos  _intrusos_  o diferentes entre ellos.
-   **wrapInner()**  es análogo a .wrap() pero el elemento envolvente se añade no como padre sino al contenido de los seleccionados.

Vamos a entenderlo mejor con las siguientes imágenes:

![](https://dc722jrlp2zu8.cloudfront.net/media/uploads/2020/02/06/wrapall.png)

![](https://dc722jrlp2zu8.cloudfront.net/media/uploads/2020/02/06/wrapinner.png)

### .val()

He decidido meter aquí la función  **.val()**  aquí porque aunque no modifica el DOM si que modifica en cierta manera el contenido de la página al cambiar el valor de los elementos, normalmente de los elementos de los formularios.

Usando  **.val()**  podremos obtener y fijar el valor de los distintos campos de los formularios.

Para ilustrar ambas posibilidades vamos a ver la síntaxis general y ejemplos:

```
    //Para obtener el valor de un campo de formulario. El PRIMERO de los seleccionados
    var valor = $("some_selector").val();

    //Para fijar el valor para TODOS los campos seleccionados
    $("some_selector").val("some_value");

    //O usando una función. La posición, el valor actual y $(this) disponibles
    //El valor de retorno será el valor del elemento seleccionado
    $("some_selector").val(funcion(index,valor) {
    ….
    });

```

Un ejemplo para cada uno de estos casos:

```
    //Obtengo el valor del primer input de tipo texto
    var valor = $("input[type=text]).val();

    //Todos los input de tipo text van a mostrar "Insert Value"
    $("input[type=text).val("Insert Value");


    //Voy a añadir al valor que tenían -> y la posición de entre los selecciondos.
    $("input[type=text).val(funcion(index,valor) {
        $(this).val(valor+"->"+index);
    });
```

## Eventos jQuery

Ahora empieza lo bueno de este curso. Hasta ahora hemos visto muchas cosas, pero a partir de ahora vamos a  **reaccionar**  a lo que sucede en mi página para dar vida a la misma haciéndola  **dinámica**.

Para conseguir esta interactividad lo que haremos es usar  **jQuery**  para  **CAPTURAR**  eventos y  **RESPONDER**  a los mismos, entendiendo como  **EVENTO**  cualquier cosa que sucede en nuestra página web.

Para este trabajo con eventos  **jQuery**  nos ofrece muchísimas posibilidades y además de ser numerosas son muy flexibles y tienen muchas opciones. Por este motivo en este curso vamos a ver una primera aproximación centrándonos en las más usadas.

### Event Bubbling

Para realizar esa  _captura_  y  _respuesta_  a los eventos antes debemos entender cómo funcionan, de manera general, los eventos en una página web.

Los eventos siguen lo que se llama  **“event bubbling”**, y se van propagando desde el elemento en el que se han producido hacia arriba del DOM hasta que encuentran (en caso de que haya) un manejador o handler.

Si se encuentran con ese handler, lo ejecutan y siguen su camino hacia arriba hasta que llegan arriba del DOM.

Esto proceso se puede ilustrar con una imagen de ejemplo:

![](https://dc722jrlp2zu8.cloudfront.net/media/uploads/2020/02/06/event_bubbling.png)

Paso a paso lo que sucede es (de manera simplificada):

1.  Hacemos click en un li. Al tener manejador se ejecuta.
2.  El evento se propaga al ul, al no tener manejador el evento sigue hacia arriba.
3.  El evento llega al body que tiene un manejador para el evento click. Este se ejecuta.
4.  El evento sigue subiendo pero no vuelve a encontrar ningún manejador.

### Captura de eventos

Una vez hemos entendido cómo funcionan los eventos vamos a ver que tenemos dos posibilidades para capturarlos y reaccionar a los mismos.

1.  Utilizando funciones de carácter general.
2.  Utilizando funciones específicas para cada evento que tienen el nombre propio del evento.

#### Funciones general para la captura de eventos

Son principalmente dos, las funciones  **.on()**  y  **.one()**. Ambas son funciones análogas y la diferencia es que  **.one()**  ejecuta el handler como mucho una vez y luego lo desactiva.

En ambas indico el nombre del evento que quiero capturar y puedo tener una  **ASOCIACIÓN DIRECTA**  del handler al evento o una  **ASOCIACIÓN DELEGADA**. Vamos a proceder a ilustrar su funcionamiento más general (hay más opciones pero para este curso es suficiente):

```

//ASOCIACIÓN DIRECTA: Se ejecuta el handler cuando sucede el evento en el elemento o en sus hijos.
//event es opcional

$("some_selector").on("event1 event2 eventN", function(event) {
  //Tengo acceso a $(this) (El elemento donde sucedió el evento )
});

//ASOCIACIÓN DELEGADA. Se añade un parámetro y se ejecutará el handler si el evento sucede en algunos de los hijos del elemento que cumple con el selector2

$("some_selector").on("event1 event2 eventN", "selector2",function(event) {
  //Tengo acceso a $(this) (El elemento donde sucedió el evento )
});

//Análogo a on() pero se ejecuta el handler como mucho una vez
//Luego se ELIMINA EL HANDLER. Puedo tener tambié asociación directa e indirecta.
$("some_selector").one("event1 event2….eventN", function(event) {
  //Tengo acceso a $this (elemento donde ocurrió el evento)
});

//Un ejemplo de este uso de handlers
//Un li que muestra cuántas veces hemos hecho click en él o hemos pasado por
//encima con el ratón.

//ASOCIACIÓN DIRECTA
var numVeces = 0;
$("li#ejemplo").on("click mouseenter", function(event) {
  $(this).html("Número de clicks:" + ++numVeces);
});

//ASOCIACIÓN DELEGADA
var numVeces = 0;
$("ul").on("click mouseenter","li#ejemplo", function(event) {
  $(this).html("Número de clicks:" + ++numVeces);
});

```

### Eventos con nombre

El funcionamiento es análogo a la captura con  **.on()**  o  **.one()**  pero los eventos “importantes” tienen funciones propias dedicadas. Este tipo de captura  **NO**  me permite  **ASOCIACIÓN DELEGADA**.

De manera general tienen esta sintaxis:

```

    $("some_selector").nombreEvento(funcion(event) {
        ....
    });

    //El mismo ejemplo con un selector con nombre
    var numVeces = 0;
    $("li#ejemplo").click(funcion(event) {
            $(this).html("Número de clicks:"+(++numVeces));
    });

```

Entre los eventos con nombre más destacados tenemos:

.change()

.hover()

.mouseenter()

.resize()

.click()

.keypress()

.mouseleave()

.scroll()

.dblclick()

.keydown()

.mousemove()

.select()

.focus()

.keyup()

.mouseout()

.submit()

.focusout()

.mousedown()

.mouseover()

Aunque algunos necesitan una explicación algo más detallada la verdad es que casi todos son autoexplicativos, dado su nombre.

Veremos algunos con más detalle en capítulos posteriores.

## El objeto EVENT

Si, como hemos hecho hasta ahora, ponemos a disposición del handler el objeto  **EVENT**  este objeto puede proporcionarnos muchas  **información adicional**  sobre el evento,  **parar el event bubbling**,  **evitar comportamientos por defecto**  y muchas más cosas.

Tiene muchas propiedades y métodos pero las más comúnmente usadas son:

e.currentTarget

e.stopPropagation()

e.delegatedTarget

e.Target

e.pageX

e.timeStamp

e.metaKey

e.pageY

e.type

e.preventDefault()

e.which

Aunque algunos necesitan una explicación algo más detallada la verdad es que casi todos son autoexplicativos, dado su nombre.

Veremos algunos con más detalle en capítulos posteriores.
Los eventos de ratón y teclado son los más comunes en la mayoría de las páginas. En este apartado vamos aprender a diferenciarlos, ya que hay algunos que pueden llevar a confusión, y vamos a conocer algunas propiedades interesantes del objeto evento que debemos de tener en cuenta en relación a estos eventos.

### Eventos de teclado

Son principalmente tres:

-   **.keydown():**  Evento que se dispara cuando presiono una tecla estando dentro de un elemento.
-   **.keyup():**  Evento que se dispara cuando libero la tecla presionada.
-   **.keypress():**  Evento que se dispara cuando presiono una tecla estando dentro de un elemento.

**IMPORTANTE:**  Aunque pueden .keydown() y .keypress() pueden parecer lo mismo no son del todo iguales.

Para comprender un poquito mejor las diferencias entre ambas:

.keydown()

.keyup()

Incluye “special keys”

No incluye “special keys

Case Insensitive

Case sensitive

### Eventos de ratón

En relación a los eventos de ratón tenemos bastantes más:

-   **.mousedown():**  Al presionar el ratón estando dentro de un elemento.
-   **.mouseup():**  Cuando libero el ratón tras hacer click en alguno de sus botones.
-   **.mousenter():**  Cuando el ratón entra en un elemento.
-   **.mouseleave():**  Cuando el ratón sale de un elemento.
-   **.mousemove():**  Cuando muevo el ratón dentro de un elemento.
-   **.mouseover():**  Cuando el ratón entra en un elemento.
-   **.mouseout():**  Cuando el ratón sale de un elemento.
-   **.click():**  Cuando hago click sencillo de ratón dentro de un elemento.
-   **.dblclick():**  Cuando hago doble click de ratón detro de un elemento.

Puede parecer que  **.mouseenter()**  y  **.mouseleave()**  son similares a  **.mouseover()**  y  **.mouseout()**  pero los dos primeros son simulaciones de eventos propios de Internet Explorer que  **jQuery**  incluye para que puedan ser utilizado independientemente del navegador. Adicionalmente hay otras diferencias:

.mouseover()

.mouseenter()

El elemento y sus hijos

Sólo el elemento

.mouseout()

.mouseleave()

Del elemento y sus hijos

Salgo del elemento

Esto se puede apreciar claramente en el ejmplo incluido en este mismo capítulo.

### Propiedades de Event

En relación a estos eventos hay varias propiedades del objeto event que pueden resultar interesantes:

-   **e.pageX:**  Posición del ratón con respecto a la izquierda del documento.
-   **epageY:**  Posición del ratón con respecto a la zona superior del documento.
-   **e.which:**  Contiene el código de la tecla o del botón del ratón (1-izquierda,2-central,3-derecha).
-   **e.type:**  Nombre del evento que se ha producido. Especialmente útil si nuestro manejador es para más de un evento y queremos hacer cosas diferentes.
-   **e.metaKey:**  Es true si hemos presionado la tecla de Windows en Windows y la tecla de comando en Mac.

Además de las operaciones que hemos visto anteriormente, que me permiten capturar eventos y darles respuesta,  **jQuery**  nos permite una serie de operaciones avanzadas con eventos:

-   El control de la propagación de los eventos.
-   Conectar y desconectar manejadores de eventos.
-   Simular la ocurrencia de eventos.
-   Crear mis propios eventos.

### Control de propagación de eventos

Una vez capturado un evento, y desde el objeto  **event**  que recibe la función del handler podemos controlar, con algunos de sus métodos, la propagación de dicho evento.

La funciones más importantes son las siguientes:

```
    //Evita el comportamiento por defecto
    event.prevenDefault();

    //Para los propagación hacia arriba
    event.stopPropagation();

    //Para el resto de los handlers y la propagación hacia arriba
    event.stopImmediatePropagation();

```

Un ejemplo del uso de estas funciones sería el siguiente:

```
    $("a").click(function (event) {
        event.preventDefault();
        alert("No me voy a ningún sitio");
        //Si algún padre tuviera algún handler no se ejecutaría
        event.stopImmediatePropagation();
    });

```

### Conectar y desconectar Handlers

La conexión de handlers a elementos ya la habíamos visto en capítulos anteriores usando métodos como  **.on()**  y los métodos con nombre de eventos.

Para desconectar esos Handler  **jQuery**  nos proporciona principalmente la función  **.off()**  que se puede usar de varias maneras y hace el efecto contrario a  **.on()**. Puede usarse de varias maneras y algunas de las más comunes vamos a ilustrarlas a continuación:

```

    //Borra todos los handlers asociados a un selector
    $("some_selector").off();

    //Borra una serie de handlers asociados a un selector
    $("some_selector").off("event1 event2...eventN");

    //Borra una serie de handlers asociados a un selector
    //por asociación delegada.
    //Tiene que tener las misma definición que cuando habíamos hecho
    //un .on() delegado.
    //Tercer parámetro opcional “**” borra sólo los delegados 
    $("some_selector").off("event1 event2...eventN","selector2");

```

Un  **PROBLEMA**  con los  **handlers**  asociados con  ***.on()**  tal y como los habíamos usado hasta ahora es que no se asocian con elementos nuevos que se hayan añadido al DOM después de cargar la página.

En versiones antiguas de  **jQuery**  esto se solucionaba con los métodos o funciones  **.live()**  y  **.die()**  que conectaban o desconectaban handlers para todos los elementos seleccionados ahora o en un futuro.

En versiones actuales de  **jQuery**  este problema se soluciona usando una  **ASIGNACIÓN DELEGADA**  de la captura de eventos al padre. Vamos a verlo con un ejemplo:

```
    //Handler únicamente para los elementos que ya EXISTEN (ASIGNACIÓN //DIRECTA)
    $("p").on("click", function (event) {
        alert("Click en párrafo");
        event.stopImmediatePropagation();
    });

    //Handler para los nuevos y los que voy a seguir creando
    //ASIGNACIÓN DELEGADA
    $("div.output").on("click", "p", function (event) {
        alert("Click en párrafo- DELEGADA");
        event.stopImmediatePropagation();
    });

```

### Disparando eventos

En ocasiones puede ser necesario  **SIMULAR**  que se ha producido un evento  **LANZÁNDOLO**  de manera artificial cuando me interesa.

Eso se consigue con las funciones  **.trigger()**  y  **.triggerHandler()**  cuyo uso más frecuente es el siguiente:

```
    //Simulo que se ha producido un eventos en los elementos del selector
    $("some_selector").trigger("some_event");

    //El argumento puede ser un objeto Evento. Pasa toda la información
    $("some_selector").trigger(event);

    //Ejecuto todos los handlers asociados evento
    $("some_selector").triggerHandler("some_event");

    //Ejecuto todos los handlers asociados a un objeto del tipo evento
    $("some_selector").triggerHandler(event);

```

Aunque puede parece que el uso de ambos es idéntico hay varias diferencias importantes:

-   Si uso  **.trigger()**  el comportamiento por defecto se sigue manteniendo y hay propagación.
-   Si uso  **.triggerHandler()**  no se ejecuta el comportamiento por defecto del elemento, debo tener obligatoriamente un handler asociado para el evento concreto y no hay propagación del evento.

En ambos si uso handlers y quiero que se simule de manera efectiva debo pasar el objeto evento que lleva todas la información.

### Creando mis propios eventos

Para crear mis propios eventos usaré las funciones  **.on()**  y  **.trigger() / .triggerHandler()**.

Algo así:

```
    //Uso el nombre de “mi evento”
    $("some_selector").on("mi_evento"..........);

    //Lo utilizo con trigger
    $("........").trigger("mievento");
    $("........").triggerHandler("mievento");
```

## Moviéndonos por el árbol

**jQuery**  me proporciona una serie de funciones que me van a permitir moverme fácilmente por el árbol DOM a partir de los elementos seleccionados. Es lo que en inglés se llama  **Traversing**.

Para poder trabajar con esto debemos empezar recordando que todas las páginas tienen forma de árbol.

![](https://dc722jrlp2zu8.cloudfront.net/media/uploads/2020/02/06/arbol.png)

Y dentro de este árbol existen relaciones de parentesco y precedencia que podemos ilustrar con la siguiente imagen:

![](https://dc722jrlp2zu8.cloudfront.net/media/uploads/2020/02/06/relaciones.png)

De manera resumida tendremos:

-   **Padre:**  El nodo inmediatamente superior.
-   **Hijos:**  Todos los nodos que se encuentran debajo justo un nivel de un elemento.
-   **Antecesores:**  El padre del padre, el padre del padre del padre etc…
-   **Sucesores:**  Los hijos, los hijos de los hijos etc…
-   **Hermanos:**  Todos los nodos que tienen el mismo padre.

Y además, según la posición tendremos hermanos anteriores y hermanos posteriores a un nodo determinado.

### Funciones para el recorrido del árbol

Para recorrer el árbol  **jQuery**  nos da muchas funciones entre las que destacamos las siguientes:

-   **.children()**
-   **.next() / .nextAll() / .nextUntil()**
-   **.prev() / .prevAll() / .prevUntil()**
-   **.parent() / .parents() / .parentUntil()**
-   **.closest()**
-   **.siblings()**

Hay más funciones pero el propio nombre de cada una de ellas indica, si sabes un poco de inglés, lo que hacen. Además cada una de ellas tiene varia formas de usarse pero para no complicar en exceso y no alargarnos mucho podemos decir que todas (casi todas) se usan de manera general de la siguiente manera:

```
//Sin filtro. Selecciona todos los elementos
$("some_selector").funcion_de_la_lista();

//El color del texto de todos los hijos de los ul (los li) será rojo
$("ul")
  .children()
  .css("color", "red");

//Tenemos un filtro que le pasamos
$("some_selector").funcion_de_la_lista("otro_selector");

//Lo mismo qu antes pero sólo para los primeros hijos
$("ul")
  .children("li:nth-child(1)")
  .css("color", "red");
```

Cuando los selectores me devuelven muchos elementos puedo estar interesado en filtralos para ajustar mi acción posterior a ciertas condiciones.

**jQuery**, al igual que otras muchas cosas, nos proporciona funciones para realizar filtrados. Algunas ya las hemos ido viendo pero para profundizar en este apartado nos vamos a centrar en:

-   **.find()**
-   **.filter()**
-   **.slice()**

Iremos viendo las aplicaciones generales para cada una, y además un ejemplo:

```

    //.find() Descendientes (hijos, nietos etc..) que encajan con el segundo selector
    $("some_selector").find("otro_selector");

    //Todos los descencientes con esas clase (td/td/….)
    $("table").find(".celda_verde");

    //.filter() Reduce los seleccionados a los
    //que encajan con el segundo selector
    $("some_selector").filter("otro_selector");

    //Todos los descencientes con esas clase (td/td/….)
    $("ul").filter(".lista_menu");

    //Con una función para cada uno de los resultantes del filtro
    //Tengo el índice dentro de los seleccionado y $(this)
    //Modifico si la función es TRUE
    $("some_selector").filter(function(index) {
    })...

    $("li").filter(function(index) {
        return index ===9
    }).text("SOY YO");

    //.slice() Selecciono un rango de entre los elegiods 0-based()
    $("some_selector").slice(inicio);
    $("some_selector").slice(inicio,fin);

    //De la primera fila la segunda y la tercera
    $("table tr").children().slice(1,3).text("");
```

En capítulos anteriores hemos hablado de varias funcionesd de  **jQuery**  que nos permitían añadir contenidos. Pues bien, hay aún más funciones para ello, incluso algunas que nos permiten mover elementos.

Destacaremos las siguientes:

-   **.after() y .before()**
-   **.insertAfter() e .insertBefore()**
-   **.clone()**

### .after() y .before()

Son funciones que me permiten insertar contenido (uno o varios) justo antes (before) o después (after) de los elementos seleccionados. Ambas tienen el mismo uso. Únicamente cambia el nombre.

La forma más sencilla de usarlas sería la siguiente:

```

    $("some_selector").after(content1,.....,contentN);
    $("some_selector").before(content1,.....,contentN);

```

Es importante destacar que ese contenido puede ser:

-   HTML.
-   Texto.
-   Un objeto jQuery, lo que provoca que ese objeto se desplace por el DOM.
-   Un array de varios elementos de los anteriormente citados.

También pueden usarse de otras maneras:

```

    //Con función cuyo valor devuelto es lo que se añade.
    //Tengo disponible posición y $(this)
    $("some_selector").after(function(index) {
        ...
    });

    //Igual pero con el HTML del elemento disponible
    $("some_selector"”).after(function(index,html) {
        ...
    });

```

A continuación ejemplos de estas posibilidades:

```
//Añado una fila más después de la última fila
$("tr")
  .last()
  .after("<tr><td>F</td></tr>");

//Muevo la primera fila al final
$("tr")
  .last()
  .after($("tr").first());

//Duplico las filas
$("tr").after(function(index, html) {
  return html;
});

```

### .insertAfter() e .insertBefore()

Son funciones similares a las anteriores pero en este caso lo seleccionado es lo que se añade a lo que se selecciona después como parámetro (el objetivo) antes (before) o después (after). Al revés que antes:

La sintaxis general es la siguiente:

```
$("origin").insertAfter(target);

```

Ese  _target_  puede ser:

-   Un selector.
-   HTML.
-   Objeto jQuery ( se desplazará).
-   Un array de los anteriores.

Por ejemplo:

```

    //Añado una fila más después de la última fila
    $("<tr><td>F</td></tr>").inserAfter("tr:last");

    //Muevo la primera fila al final
    $("tr:fist").insertAfter($("tr"”).last());

```

Todo esto sería igual para  **.insertBefore()**

### .clone()

Crea una copia profunda(con descendientes) de los elementos seleccionados. Y le puedo pasar como parámetros si quiero conservar sus handlers y los de sus descendientes.

```

    //De manera general
    $("selector").clone(withEvents);
    $("selector").clone(withEvents,whithDeepEvents);

    //Clono la primera fila y la añado al final
    $("tr").first().clone(false).appendTo(“table”);
```

Para acabar con este capítulo….más funciones de  **jQuery**, esta vez para borrar elementos del DOM y para reemplazar nodos del mismo.

Para el borrado de nodos destacamos las siguientes funciones:

-   **.remove() y .detach()**

Para reemplazar nodos destacamos:

-   **.replaceAll() y .replaceWith()**

### Borrando nodos con .remove() y .detach()

Ls funciones o métodos  _.remove() y .detach()_  tienen comportamientos similares. Ambos sirven para borrar elementos seleccionados del DOM. La diferencia entre ambos es que usando  _.detach()_  puedo guardarme esos elementos (con eventos incluidos) para reponerlos luego.

La síntaxis general es:

```
//Borra del DOM los elementos seleccionados
$("some_selector").remove();
//Aplicando un filtro a los seleccionados
$("some_selector").remove("filter_selector");

//Guardando lo borrado
var result = $("some_selector").detach();
//Guardando y filtrando"
var result = $("some_selector").detach("filter_selector");

```

Y podemos poner varios ejemplos:

```
//Borra todas las imágenes
$("img").remove();

//Borra todas las imágenes de la clase logo
$("img").remove(".logo");

//Borra todas las imágenes y las recupera
var imagenes = $("img").remove();
$("body").append(imagenes);

```

### Reemplazando nodos con .replaceAll() y .replaceWidth()

Ambas son muy similares, sirven para reemplazar elementos. La primera reemplaza el objetivo con el conjunto de los elementos seleccionados y la segunda funciona al revés.

La sintaxis y un ejemplo para cada una de ellas las podemos ver en el siguiente cuadro de código:

```
//Reemplaza el elemento objetivo con el conjunto de los seleccionado
$("some_selector").replaceAll(target);

//Se sustituyen todas las celdas td por celdas td que contienen X
$("<td>X</td>").replaceAll("td");

//Igual que el anterior pero el origen y el objetivo están al revés
$(target).replaceWith("some_selector");
//Se sustituyen todas las celdas td por celdas td que contienen X
$("td").replaceWith("<td>X</td>");
```

## Efectos y animaciones

**jQuery**  nos proporciona por defecto una serie de métodos o funciones que nos permiten aplicar efectos comunes de manera sencilla y rápida.

### Tipos de efectos

Podemos ver la clasificación de los mismos en la siguiente tabla:

![](https://dc722jrlp2zu8.cloudfront.net/media/uploads/2020/02/06/tipos_efectos.png)

El nombre de la función es un claro de indicativo de lo que hacen (si sabemos un poquito de inglés).

### Uso de las funciones de efectos

Todas las funciones que hemos visto anteriormente son muy flexibles y presentan múltiples posibilidades de uso. Nos vamos a centrar en los usos más frecuentes que, además, son comunes a casi todas ellas.

Estos usos más comunes son los siguientes:

-   Aplicación del efecto con las opciones por defecto (duración de 400ms).
-   Aplicación del efecto cambiando la duración del mismo.
-   Aplicación del efecto especificando una función que se va a ejecutar al finalizar el efecto.
-   Aplicación del efecto pasándole un objeto de opciones. Este es un poco más complejo ya que son muchas opciones.
-   …..algún uso más.

Nos centraremos en los tres primeros usos que son los más frecuentes y los más fáciles.

```
    //Aplicación del efecto con las opciones por defecto a los elementos seleccionados
    $("some_select").nombre_funcion();

    //Ejemplos Oculta las tablas
    $("table").hide();

    //Especificando una duración concreta para el efecto (en milisegundos).
    $("some_selector").nombre_funcion(num_milisegundos);

    //Ejemplo - Las listas se desvanecen en 5 milisegundos.
    $("ul").fadeOut(5000);

    //Ejecutando una función al acabar el efecto
    //Sin duración
    $("some_selector").nombre_funcion(function() {.....});
    //Con duración
    $("some_selector").nombre_funcion(num_milisegundos,function() {.....});

    //Muestro mensaje al acabar de hacer el efecto "cortinilla" en el formulario
    $("form").slideUp(2000,function() {
        alert("Formulario oculto")
    });

```

De todas las funciones señaladas en el capítulo anterior únicamente  **.fadeTo()**  tiene un comportamiento algo diferente ya que le pasaremos el grado de opacidad destino.

Sería algo así:

```

    //Opacidad a la mitad en 2 segundos. 
    //El parámetro de la función es opcional.
    $("table").fadeTo(2000,0.5,function() {
        console.log("HOLA);
    });

```

### La cola de efectos (o animaciones)

Para tener un control de los efectos y animaciones debemos de tener cierto control de la cola de efectos ( y animaciones) ya que si le aplico varios efectos y animaciones a un mismo elemento a la vez estas se van colocando en una cola y cuando finaliza una de ellas, se pasa a las siguientes.

**jQuery**  tiene funciones para controlar esta cola.

-   **.stop():**  Finaliza la aplicación el efecto o animación en curso en los elementos seleccionados.
-   **.finish():**  Finaliza la aplicación el efecto o animación en curso y elimina las que están esperando en cola finalizándolas (en los elementos seleccionados).
-   **.queue(‘fx’):**  Obtiene información de la cola de efectos y animaciones (en los elementos seleccionados).
-   **.clearQueue():**  Elimina de la cola todos los efectos o animaciones pendientes (en los elementos seleccionados).
-   **.delay():**  Establece un retraso para la ejecución de los restantes elementos de la cola de efectos y animaciones (en los elementos seleccionados).
Si, aparte de lo que nos proporciona  **jQuery**, queremos montar nuestras propias animaciones y efectos, disponemos de una función para ello, la función  **.animate()**.

### ¿ Qué es una animación?

Antes de empezar a usar la función  **.animate()**  debemos de tener muy claro qué es lo que significa  _animar_  desde el punto de vista Web.

De una manera simplificada podemos decir que:

```
Animar: Modificiación de propiedades CSS de los elementos de una página Web a lo largo de un periodo de tiempo especificado.

```

### Propiedades “animables”

Pero no todas las propiedades CSS son animables con  **jQuery**.

De manera general podemos decir que una propiedad CSS será animable con jQuery si puede representarse como un valor numérico (unidades incluidas).

En la siguiente tabla podemos ver una pequeña lista de las propiedades que pueden ser animadas y las que no:

![](https://dc722jrlp2zu8.cloudfront.net/media/uploads/2020/02/06/propiedades_animables.png)

Es importante destacar que para propiedades compuestas (como por ejemplo font-size)  **jQuery**  les cambia el nombre para usar una notación camelCase (fontSize). Además, no se permiten propiedades  _atajo_  que me permitan especificar varios valores a la vez.

Si queremos una lista completa y ejemplos podemos encontrarla  [aquí](https://www.w3schools.com/jquery/eff_animate.asp).

### La función .animate()

Como muchas de las funciones  **jQuery**  esta función es muy flexible y tiene muchas posibilidades. En este curso nos centraremos, como hemos venido haciendo hasta ahora, en los usos más frecuentes.

```
    //Especificando los propiedades
    // Valores especiales ‘show’, ‘hide’ ‘toggle’
    // Incremento con respecto al valor actual += y -=
    $("some_selector").animate({
        prop1 : valor1,
        prop2: valor2,
        …
        proprN : valorN
    });

    //Especificando los propiedades  y duración
    $(“some_selector”).animate({
        prop1 : valor1,
        prop2: valor2,
        …
        proprN : valorN
    }, duración_milisegundos);

```

Podemos ilustrarlo con varios ejemplos:

```
//Animo el tamaño de las letra de los td
//En dos segundos
$("td").animate(
  {
    fontSize: "3rem"
  },
  2000
);

//Incremento el alto y ancho de las imágenes en 3 segundos
$("img").animate(
  {
    height: "+=50px", //50 pixels más
    width: "+=50px" //50 pixels menos
  },
  3000
);

//Efecto de desaparecer de las imágenes
//Cortinilla horizontal
$("img").animate(
  {
    opacity: 0,
    width: "hide"
  },
  5000
);
```

## AJAX Fácil usando jQuery

Si recordamos la definición de MDN (Mozilla Develper Network):

```

JavaScript Asíncrono + XML (AJAX)....conjuntamente con varias tecnologías existentes 
(HTML o XHTML,CSS,JavaScript, DOM, XML,XSLT, y el objeto XMLHttRequest)
...aplicaciones web capaces de actualizarse continuamente sin tener
que volver a cargar la página completa

```

**NOTA**:Extracto de la definición que podemos encontrar  [aquí](https://developer.mozilla.org/es/docs/Web/Guide/AJAX)

### Funcionamiento AJAX

Podemos ver el esquema de funcionamiento de las peticiones Http Ajax frente a las peticiones Http tradicionales en la siguiente imagen:

![](https://dc722jrlp2zu8.cloudfront.net/media/uploads/2020/02/06/ajax.png)

**NOTA:**  DanielSHaischt, via Wikimedia Commons  [CC BY-SA](https://creativecommons.org/)

En este esquema pode ver como:

-   A la izquierda tenemos la forma tradicional de trabajar de la web. Cada petición al servidor se traduce en que el servidor devuelve HTML+CSS y esa respuesta hace que el navegador la cargue en nuestra pantalla.
-   Sin embargo, en el esquema AJAX efectuamos una petición asíncrona al servidor a través del motor AJAX de javascript. Esta petición llega al servidor que devuelve el tipo de datos que sea (XML, HTML o JSON…) al motor Ajax. Este motor AJAX se encarga de actualizar únicamente la zona de la página que se ha indicado sin tener que volver a  _pintar_  la página completa.

### Tecnologías relacionadas

Dos tecnologías importantes relacionadas con este tipo de llamadas son XML y JSON que sirven para representar la información que nos devuelve el servidor.

Posteriormente somos nosotros los que debemos  _pintar_  en HTML la información recibida.

Un ejemplo de ambos se puede ver en la imagen de abajo:

![](https://dc722jrlp2zu8.cloudfront.net/media/uploads/2020/02/06/json_xml.png)

**NOTA:**  en este curso nos vamos a centrar en la tecnología  **JSON**.

### Ajax y jQuery

**jQuery**  hace que las llamadas AJAX sean mucho más fácil con la utilización, principalmente, de las siguientes funciones:

-   **$.ajax() o $jQuery.ajax():**  Es la función principal y la más versátil. Es la que vamos a utilizar en este curso.
-   **$.ajaxgetJSON() o $jQuery.getJSON():**  Si queremos recibir JSON del servidor mediante una petición GET.
-   **$.ajaxSetup o $jQuery.ajaxSetup():**  Para establecer la configuración por defecto para llamadas Ajax.
-   **$.ajaxget() o $jQuery.ajaxget():**  Para realizar llamadas HTTP GET.
-   **$.ajaxpost() o $jQuery.post():**  Para realizar llamadas HTTP POST.

Usando la primera de las funciones la estructura general simplificada es la siguiente:

```
    $(function() {

        //Estructura general SIMPLIFICADA
    $.ajax(url[,settings]);

    });

```

Es ese esquema general  _**settings**_  es un objeto JSON que tiene multitud de propiedades y funciones que se ejecutarán o no dependiendo del valor de retorno de la petición o de si la petición ha podido realizarse.

Algunos de los miembros más importantes de ese objeto son:

-   **async: true**  Es la opción por defecto e indica que la petición será asíncrona.
-   **contentType: ‘application/x-www-form-urlencoded; charset=UTF-8’**, tipo para enviar los datos al servidor. Este es el valor por defecto que nos va a valer.
-   **data:**  Argumentos que voy a mandar para la petición. Equivalentes a la URL query. Expresado en JSON.
-   **dataType: ‘xml’ / ‘html’ / ‘json’**  Tipo de datos que nos va a devolver el servidor.
-   **error : function (jqXHR,textStatus, error)**  Función que se ejecutará si la llamada ha sido errónea. Puede recibir esos parámetros opcionalmente.
-   **header:**  Argumento de la cabecera. Expresado en JSON.
-   **method: ‘get’ (or ‘post’)**.
-   **statusCode:**  lista de funciones dependiendo del estado (objeto json).
-   **success: function(data, textStatus, jqXHR)**  Función que se ejecutará si la llamada es exitosa. Opcionalmente puede recibir esos parámetros.
-   **complete: function(jqXHR)**  Función que se ejecutará al acabar la llamada, tanto si es exitosa como si no.

**NOTA:**  No tienen por qué aparecer todos en el objeto Settings. Y recordad, hay muchas más opciones.

En el próximo capítulo empezaremos a usar AJAX con jQuery.

## jQuery UI

![](https://dc722jrlp2zu8.cloudfront.net/media/uploads/2020/02/06/jqueryui.jpg)

Si atendemos a la definición que nos dan los propios desarrolladores:

> **jQuery UI**  es un conjunto seleccionado de efectos, componentes y temas construidos sobre jQuery.

Y esa definición junto con la situación de  **jQuery UI**  en la siguiente pila de tecnologías:

![](https://dc722jrlp2zu8.cloudfront.net/media/uploads/2020/02/06/stack.png)

Nos lleva da decir que:

> **jQuery UI**  es una tecnología  **construida sobre jQuery**  que nos va a permitir dotar de  **interactividad compleja**  a mi página web de manera más  **fácil**  ya que  **añade**  numerosas características nuevas a lo que ya conocemos de  **jQuery**.

Podemos instalar jQuery de varias maneras:

-   Mediante el uso de la librería por defecto, ya sea porque las descargamos o porque enlazamos a un CDN (Hosted Libraries).
-   Seleccionando los componentes que queremos.
-   Seleccionando el tema que queremos.

### Elemento de jQuery UI

Los principales elementos de jQuery UI, que trataremos en capítulos posteriores son:

-   **Componentes o Widgets**.
-   **Efectos**.
-   **Interacciones**.
-   Repositorio del Curso de jQuery por @pekechis para @OpenWebinars

**jQuery UI**  nos proporciona muchos componentes pero antes de conocerlos y de empezar a trabajar con ellos vamos a definir qué es un componente:

### Definición de componente

> **Componente:**  son elementos web que son  **comunes**  y que constan de una  **estructura**  HTML, de unos  **estilos**  CSS y de un  **comportamiento**  normalmente definido mediante javaScript. Además, están bien documentados y preparados para ser reutilizados. En definitiva son  **“plantillas”**  de elementos web.

### Lista de componentes de jQuery UI.

La lista de componentes de jQuery es la siguiente:

-   Acordeón. <—-
-   Autocompletado.
-   Botones. <—-
-   Checkboxradio. <—-
-   Controlgroup.
-   DatePicker.
-   Dialog.<—-
-   Menú.<—-
-   ProgressBar.
-   SelectMenu.
-   Slider.
-   Spinner.
-   Tabs.<—-
-   Tooltips.

Todos estos componentes tienen un montón de opciones, un montón de métodos y un montón de eventos propios. Podríamos dedicar un curso completo a  **jQeuryUI**  pero en este apartado vamos a ver únicamente algunas de las opciones (las más básicas) y algunos de los componentes (los que están señalados más arriba).

### Algunos ejemplos de componentes:

En todos los casos el flujo de trabajo que vamos a utilizar será similar al siguiente:

1.  Seleccionaremos el componente que queremos usar.
2.  Iremos a la opción por defecto del componente.
3.  Veremos la fuente del ejemplo (View Source), copiaremos y pegaremos el HTML del ejemplo y lo retocaremos para adaptarlo a nuestras necesidades.
4.  En caso de necesitar algo más revisaremos las opciones del API de cada componente.

Pretendemos obtener un resultado similar al siguiente:

![](https://dc722jrlp2zu8.cloudfront.net/media/uploads/2020/02/06/componentes.png)


**jQuery UI**  en relación de los efectos, y comparándolo con  **jQuery**:

-   Añade más  _funcionalidades_  o tipos de efectos.
-   Soporta la animación de colores,
-   Permite las transiciones entre distintas clases CSS interpolando el valor de las propiedades entre ambas.
-   Te da la posibilidad de usar nuevas curvas de animación.

### Funciones de efectos en jQuery UI

Para conseguir todo lo descrito anteriormente jQuery UI nos proporciona las siguientes funciones de efectos.

-   **.addClass()**. <—-
-   Animación de colores con  **.animate()**.<—-
-   **.effect():**  Es la función general con la que podemos lograr lo mismo que con las demás.
-   **.removeClass()**<—-
-   **.show()**<—-
-   **.switchClass():**  Es como .addClass() y .removeClass() juntas.
-   **.hide():**<—-
-   **.toggle()**<—
-   **.toggleClass()**<—-
-   **.easing():**  Para aplicar una función matemática que describa la evolución del efecto.

Usaremos los señaladas que además, como podéis ver son los mismos métodos que usamos en  **jQuery**  normal pero, esta vez, tendrán más parámetros indicando duración, tipo de efecto, opciones etc…

El método de trabajo será similar al que hemos explicado para los componentes y de igual maneras vamos a ver los usos más básicos y fáciles.

En este misma carpeta tenéis un código de ejemplo donde se puede ver la aplicación.

Para acabar este capítulo y para acabar el curso vamos a hablar de las interacciones que nos proporciona  **jQuery UI**.

Pero antes empezar a trabajar con ellas vamos a definir el concepto.

### ¿Qué es una interacción?

Las  **interacciones**  son  _eventos avanzados_  que son realizados por los usuarios de manera frecuente.

**jQuery UI**  no permite realizar de manera fácil una serie de interacciones que serían muy difíciles de programar desde cero.

### Lista de interacciones jQuery UI

Son las siguientes:

-   **Draggable:**  Permite mover los elementos por la página de manera libre. <—-
-   **Droppable:**  Permite que elementos sean receptores de los elementos que hemos indicado como  _draggables_.<—-
-   **Resizable:**  Permite redimensionar los elementos.<—-
-   **Selectable:**  Permite seleccionar uno o varios elementos.
-   **Sortable:**  Permite reordenar los elementos.

De igual manera que antes con los componentes y con los efectos, las interacciones son muy flexibles y nos ofrecen muchas posibilidades. Para hacer su presentación nos vamos a limitar a las interacciones indicadas, los usos más generales y a un conjunto pequeño de opciones.

Todo esto lo podemos ver en el ejemplo que está en esta misma carpeta.

Desde mi punto de vista personal los que más valor añadido aportan son  **Draggable**,  **Droppable**  y  **Sortable**.

**NOTA:**  Las interacciones a veces pueden entrar en conflicto entre ellas. Hay que leer la documentación con cuidado en ese caso.