## Maquetación Bootstrap 4

### ¿Qué es responsive?

El diseño web responsive o adaptativo es una **técnica de diseño web que busca la correcta visualización de una misma página en distintos dispositivos.** Desde ordenadores de escritorio a tablets y móviles.

- **Viewport** : nos permite indicar cómo se verá un proyecto web en los dispositivos móviles
```html
<meta name="viewport" content="width=device-width, initial-scale=1">
```
- **Breakpoints** : puntos o medidas de anchura donde se pueden crear saltos en el diseño Responsive, llamados comúnmente breakpoints, a partir de donde aplicar las media queries necesarias

	- **col-sm** : ≥ 576px
	- **col-md** : ≥768px
	- **col-lg** : ≥992px
	- **col-xl** : ≥1200px

- **Media querys** : regla o conjunto de reglas que se introducen en una hoja de estilo CSS con el objetivo de definir propiedades específicas para distintos tipos de medios

### ¿Por  qué bootstrap?

- Es **rápido** (más aún las nuevas versiones)
- Es **sencillo**
- Ampliamente **documentado**

### Novedades

- Flex integrado
- SAAS como preprocesador
- REM en lugar de EM
- 30% más ligero
- Nuevos componentes

### Instalación

- A través de scripts CDN
- Referencias entre archivos locales

### Contenedor bootstrap

- La clase container centra sus elementos y deja márgenes laterales

```html
<div class="container">
  <!-- Content here -->
</div>
```

- Container-fluid sin embargo coge todo el ancho de pantalla disponible

```html
<div class="container-fluid">
  <!-- Content here -->
</div>
```

### Bootstrap Grid

Es un componente que, como su nombre indica, nos permite representar cuadriculas o rejillas de dos dimensiones.

Se basa **obligatoriamente** en un contenedor (class container) que a su vez contiene filas (class row) y por último éstas tienen columnas (class col). 

**El máximo número de columnas de una fila es 12, y a partir de esas 12 divisiones podemos ir definiendo columnas que se compongan de varias de ellas.**

```html
<div class="container">
  <div class="row">
    <div class="col-sm">
      One of three columns
    </div>
    <div class="col-sm">
      One of three columns
    </div>
    <div class="col-sm">
      One of three columns
    </div>
  </div>
</div>
```

### Saltos de línea

Si queremos forzar una columna a saltar a la siguiente línea deberemos aplicar la clase "w-100"

```html
<div class="row">
  <div class="col-6 col-sm-3">.col-6 .col-sm-3</div>
  <div class="col-6 col-sm-3">.col-6 .col-sm-3</div>

  <!-- Force next columns to break to new line -->
  <div class="w-100"></div>

  <div class="col-6 col-sm-3">.col-6 .col-sm-3</div>
  <div class="col-6 col-sm-3">.col-6 .col-sm-3</div>
</div>
```

## Gutters

Los gutters son el espacio entre columnas usado para crear diseños responsive y alinear el contenido.

Si quisiéramos eliminar estos gutters debemos usar la clase "no-gutters"

```html
<!-- Las siguientes columnas no tendrán padding -->
<div class="row no-gutters">
  <div class="col-12 col-sm-6 col-md-8">.col-12 .col-sm-6 .col-md-8</div>
  <div class="col-6 col-md-4">.col-6 .col-md-4</div>
</div>
```

### Desplazamiento columnas

La clase **offset** nos permite desplazar cualquier columna a su derecha

```html
<div class="row">
  <div class="col-md-4">.col-md-4</div>
  <div class="col-md-4 offset-md-4">.col-md-4 .offset-md-4</div>
</div>
<div class="row">
  <div class="col-md-3 offset-md-3">.col-md-3 .offset-md-3</div>
  <div class="col-md-3 offset-md-3">.col-md-3 .offset-md-3</div>
</div>
<div class="row">
  <div class="col-md-6 offset-md-3">.col-md-6 .offset-md-3</div>
</div>
```

### Alinear filas

Podemos alinear las filas verticalmente con la clase **align**

```html
<span class="align-baseline">baseline</span>
<span class="align-top">top</span>
<span class="align-middle">middle</span>
<span class="align-bottom">bottom</span>
<span class="align-text-top">text-top</span>
<span class="align-text-bottom">text-bottom</span>
```
Y para alinear horizontalmente, usaríamos la clase **justify**

```html
<div class="justify-content-start">...</div>
<div class="justify-content-end">...</div>
<div class="justify-content-center">...</div>
<div class="justify-content-between">...</div>
<div class="justify-content-around">...</div>
```

### Ordenando columnas

Podemos controlar el orden en el que se representa el contenido, incluso para diferentes tipos de pantalla,
usando la clase **order**

```html
<div class="container">
  <div class="row">
    <div class="col">
      Primero, sin ordenar
    </div>
    <div class="col order-sm-12 order-md-2">
      Último para tamaños sm
      Segundo para tamaños md
    </div>
    <div class="col order-1">
      Tercero, pero primero
    </div>
  </div>
</div>
```


### Márgenes entre columnas

Podemos elegir los márgenes entre columnas con las clases:

- **m-N** : margin
- **mr-N** : margin rigth
- **ml-N** : margin left
- **mt-N** : margin top
- **mb-N** : margin bottom

Donde N es un número de 0 a 5 con el margen correspondiente

Además de la clase **m**, también tendríamos la clase **p** con mismo funcionamiento pero para paddings

```html
<div class="container">
<h3 class="p-3 text-primary">The demo of padding classes</h3>
<p class="p-5 bg-info text-warning">p-5</p>
<p class="p-4 bg-success text-warning">p-4</p>
<p class="p-3 bg-primary text-warning">p-3</p>
<p class="p-2 bg-secondary text-warning">p-2</p>
<p class="p-1 bg-danger text-white">p-1</p>
<p class="p-0 bg-primary text-warning">p-0</p>
</div>
```

### Otros elementos y clases

Posicionar todos los elementos de una lista en una sola línea, clase **list-inline**

```html
<ul class="list-inline">
  <li>...</li>
</ul>
```
Crear citas, con la clase **blockquote**

```html
<blockquote>
  <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere erat a ante.</p>
</blockquote>
```

Acortar automáticamente textos que no quepan, con **text-truncate**

```html
<!-- Block level -->
<div class="row">
  <div class="col-2 text-truncate">
    Praeterea iter est quasdam res quas ex communi.
  </div>
</div>

<!-- Inline level -->
<span class="d-inline-block text-truncate" style="max-width: 150px;">
  Praeterea iter est quasdam res quas ex communi.
</span>
```

### Imágenes y figuras

Podemos hacer que las imágenes de nuestra web también sean responsive con **img-fluid**

```html
<img src="..." class="img-fluid" alt="Responsive image">
```

Agregar textos responsivos a las imágenes con **figure-caption**

```html
<figure class="figure">
  <img src="..." class="figure-img img-fluid rounded" alt="A generic square placeholder image with rounded corners in a figure.">
  <figcaption class="figure-caption">A caption for the above image.</figcaption>
</figure>
```

### Tablas

Podemos crear tablas responsivas con la clase **table-responsive**

```html
<div class="table-responsive-sm">
  <table class="table">
    Datos
  </table>
</div>

```

### Formularios

A la hora de crear formularios tenemos una serie de elementos que nos facilitan el trabajo
- **Form-group** : usado de forma general en formularios

```html
<form>
  <div class="form-group">
    <label for="exampleInputEmail1">Email address</label>
    <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter email">
  </div>
  <div class="form-group">
    <label for="exampleInputPassword1">Password</label>
    <input type="password" class="form-control" id="exampleInputPassword1" placeholder="Password">
  </div>
  <button type="submit" class="btn btn-primary">Submit</button>
</form>
```
- **Form-check** : usado cuando queremos darle una apariencia estándar a los checkboxes y radios

```html
<form>
  <div class="form-group">
	  <div class="form-check">
	    <input type="checkbox" class="form-check-input" id="exampleCheck1">
	    <label class="form-check-label" for="exampleCheck1">Check me out</label>
	  </div>
	<button type="submit" class="btn btn-primary">Submit</button>
  </div>
</form>
```

### Elementos multimedia

- **Objeto media** : nos permite crear diseños donde los media son posicionados en contenido que no lo envuelve
	- **img**
	- **media-body**

```html
<div class="media">
  <img class="mr-3" src="..." alt="Generic placeholder image">
  <div class="media-body">
    <h5 class="mt-0">Media heading</h5>
    Cras sit amet nibh libero, in gravida nulla. Nulla vel metus scelerisque ante sollicitudin. Cras purus odio, vestibulum in vulputate at, tempus viverra turpis. Fusce condimentum nunc ac nisi vulputate fringilla. Donec lacinia congue felis in faucibus.
  </div>
</div>
```
#### Elementos incrustados

Podemos hasta hacer responsivos el contenido que embebamos de otras fuentes, por ejemplo un vídeo de youtube con **embed-responsive**

```html
<div class="embed-responsive embed-responsive-16by9">
  <iframe class="embed-responsive-item" src="https://www.youtube.com/embed/zpOULjyy-n8?rel=0" allowfullscreen></iframe>
</div>
```
