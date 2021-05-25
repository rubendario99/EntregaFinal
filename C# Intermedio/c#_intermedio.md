# C# Intermedio

## Creando una App de WinForms

### Diseñador

Para el diseño de las pantallas, tenemos un diseñador que nos permite crear las pantallas con un editor visual bastante sencillo.

Durante este video, daremos nuestros primeros pasos y como poder trabajar con él.

### Toolbox (Herramientas)

Donde vamos a encontrar todos los elementos que podemos incluir dentro de la pantalla.

### Properties (Propiedades)

Veremos la ventana de propiedades con los distintos elementos.

### Controles básicos

### Button

Un control que permite interactuar con los usuarios.

### Label

Un texto de solo lectura, para introducir información dentro de la pantalla.

### TextBox

Creamos un cuadro de texto para que el usuario pueda introducir texto.

### CheckBox

Introduce un casillero para añadir opciones.

### PictureBox

Nos permite introducir las imágenes.

### Controles Avanzados

### ListBox

Nos permite mostrar elementos listados

### DateTimePicker

Un control capaz de seleccionar las distintas fechas

### ProgressBar

Un elemento para mostrar el progreso del contenido.

### RichTextBox

Un cuadro de texto que permite introducir texto enriquecido.

### Controles Personalizados

Podemos crear controles propios para añadir funcionalidad extra dentro de Windows Forms.

Durante este video veremos como crear User Control (controles de usuario) y su uso.

### Añadir controles

Lo más frecuente cuando se crean controles de usuario es añadir controles básicos para generar controles compuestos con mayor funcionalidad.

### Añadir funcionalidad

Dentro del control usuario, se puede añadir funcionalidad adicional. Al introducir propiedades, también se incluyen dentro de la ventana de propiedades  
cuando usamos el control de usuario.

### Funcionalidad de los controles personalizados

Continuamos con los controles personalizados. Respecto a su uso y también otra manera de poder crear controles

### Consumir controles

Siempre que recompilemos nuestra aplicación, dentro del cuadro de herramientas, tendremos el nuevo control para poder usarlo desde el diseñador.

### Creación desde hererencia

Podemos crear una clase nueva y esta heredar desde el control que necesitemos.

## Creando una app con WPF

Con la creación de  **WPF**, se creo a su vez un lenguaje de marcas llamado XAML que nos permite diseñar pantallas.

Tiene un gran parecido, a otros lenguajes de marcas para el diseño, como puede ser HTML o AXML de Android.

Aunque existe un diseñador como ocurre con  **Windows Forms**  es más recomendable programar XAML, la posición dentro de  **WPF**  es relativa.

Al igual que ocurría con Windows Forms existen un listado de controles bastante extenso por lo que mostramos un listado  [aquí](https://msdn.microsoft.com/en-us/library/windows/apps/mt185406.aspx)

Vamos a explicar los más comunes aquí

### Contenedores

Los contenedores dentro de  **WPF**  cobra más valor que en el caso de  **Windows Forms**  para posicionar los contenidos. Aunque hay varios contenedores,  
vamos a explicar los más comunes aquí.

#### Grid

Permite crear una grilla, con distintos tamaños, ya sean relativos o absolutos. Se usan las propiedades RowDefinitions o ColumnDefinitions.  
Siendo RowDefinitions para las filas y ColumnDefinitions para las columnas.

#### StackPanel

Con este contenedor posicionamos el contenido en pilas, usando la propiedad  _Orientation_  podemos posicionar esos elementos de manera horizontal o vertical.

### Controles comunes

Marcamos los controles comunes, como ocurre con  _Windows Forms_

1.  Button
2.  Label
3.  TextBox
4.  CheckBox
5.  Image

Uno de los aspectos más interesantes dentro de  **WPF**  con  **XAML**  son los controles que contienen la propiedad ItemTemplate.

Estos son principalmente ListBox y ControlBox. Permitiendo crear un diseño personalizado de las celdas.

### ListBox ItemTemplate

Usando ItemTemplate, podemos integrar un contenido en XAML, que se repetirá en cada una de las celdas.

Como ocurre con  **Windows Forms**  podemos crear nuestros propios controles. Se puede hacer creando también un  _User control_  o heredar de un control  
en cuestión.

### DependencyProperty

Uno de los aspectos diferenciadores con Windows Forms es el uso del tipo DependencyProperty lo que permite enlazar esas propiedades con el XAML.  
Su sintaxis es compleja aunque al ser repetitiva, es sencillo de replicar.

Dentro de  **WPF**  podemos introducir estilos dentro de los controles para mantener el mismo estilo en todos.

Estos pueden tener un ambito local (sobre la pantalla) o global (sobre la aplicación)

Si aplicamos un valor sobre un control que tenga un estilo aplicado que modifica la misma propiedad está se sobrescribirá.

Dentro de los ficheros de recursos se pueden incluir: Colores, estilos y DataTemplate

### Ejemplo

```

<Style TargetType="NombreDelTipoControl" x:Key="NombreDelEstilo">
    <Setter Property="NombrePropiedad" Value="ValorDeLaPropiedad"/>
    <!-- Podemos añadir más propiedades -->
</Style>

```

### Integración

```

<Button Style="{StaticResource NombreDelEstilo}"/>

```

Debemos usar la palabra reservada  _StaticResource_  para convocar los estilos de los controles.

A diferencia  **Windows Forms**,  **WPF**  nos da una mayor capacidad visual. Una de las herramientas que tenemos para mejorar esta calidad visual  
es el uso de las animaciones.

### Ejemplo

Creamos la animación desde el código:

```
DoubleAnimation fadeAnimation = new DoubleAnimation();
fadeAnimation.From = 0.0;
fadeAnimation.To = 1.0;

```

Para consumirlo solo necesitamos llamarlo desde el código con el método BeginAnimation de la siguiente manera:

```
controlConAnimacion.BeginAnimation(BindablePropertySobreLaQueLanzamos, fadeAnimation);

```

## MVVM 

 Se trata de un patrón de arquitectura de Software, su máxima es desacoplar lo máximo posible la interfaz de usuario de la lógica de la aplicación.

Durante el año 2004 mientras se desarrollaba WPF, en Microsoft idearon esta arquitectura.

Se basa en las siguientes partes:

#### Modelo

Representa la capa de datos, solo contiene la información pero nunca las acciones que manipulan.

#### Vista

Representa la información con los elementos visuales que lo componen

#### Vista Modelo

Es un actor intermediario entre modelo y vista comportándose como una abstracción de la interfaz.

Todo esto es gracias, principalmente, a la interfaz  **INotifyPropertyChanged**

Aunque existen distintos frameworks que ayudan a implementar este patrón de arquitectura. Vamos a crear nuestra primera aplicación, implementando una  
capa básica de MVVM para mostrar como se implementa y así entender mejor el desarrollo.

#### Inicio

Creamos un proyecto WPF básico y creamos cuatro carpetas para poder dividir el código:  _Model_,  _View_,  _ViewModel_,  _Services_. A su vez crearemos  
una carpeta  _Base_  dentro de la carpeta  _ViewModel_

#### BaseViewModel

Creamos una nueva clase abstracta llamada BaseViewModel dentro de la carpeta  _Base_  que hemos creado previamente. Implementamos  **INotifyPropertyChanged**  
para que obtenga la capacidad de poder notificar a la vista los cambios del ViewModel*

#### Diseñamos una pequeña Vista

Creando un login e introduciendo dos cuadros de texto y un botón para el login.

#### Desarrollamos el ViewModel

A su vez creamos un  _LoginViewModel_  que albergará dos propiedades:  _User_  y  _Password_  que en su método Set lanzarán el método  _RaisePropertyChanged_  
que hemos implementado previamente en el  _BaseViewModel_

#### DataContext

Es la propiedad que contienen todas las vistas de  _WPF_  para asociar el ViewModel

#### Añadimos los Binding

Incluimos los Binding en cada uno de los elementos de la vista

#### Implementamos Command

Creamos también una implementación de Command que será el interactuador con nuestros botones y otros controles que implementen la propiedad Command.

Ya hemos creado nuestra base de aplicación usando MVVM. Hemos visto los puntos de Vista y VistaModelo. Pero aún nos faltan los Servicios y el Modelo.

Para una mejor implementación de los servicios, necesitamos un agente externo que es un Inyector de dependencias, este en su fondo nos permite tener  
recogidos todos los servicios, que normalmente pretendemos tener únicamente una instancia de los mismos.

Todos los frameworks de MVVM tienen su propio inyector de dependencias, aunque vamos a crear el nuestro propio, sencillo para saber como se implementan  
realmente.

#### Crearemos nuestro servicio de Login

Primero vamos a crear un servicio de login. Cualquier servicio esta compuesto de Interfaz e Implementación del mismo. Se procede de esta manera, para  
poder crear nuevas implementaciones, tanto para poder testear ese código, para otros propositos.

#### Creamos el contenedor de dependencias

Que es algo similar a lo siguiente:

```

public static class CustomDependencyService
    {
        private static Dictionary<Type, object> instances = new Dictionary<Type, object>();

        public static void Register(Type type)
        {
            var instance = Activator.CreateInstance(type);
            var implementationType = type.GetInterfaces().FirstOrDefault();

            if(instances.ContainsKey(implementationType))
            {
                instances[implementationType] = instance;
            }
            else
            {
                instances.Add(implementationType, instance);
            }
        }

        public static void Register(Type type, Type typeImplementation)
        {
            var instance = Activator.CreateInstance(typeImplementation);

            if(instances.ContainsKey(typeImplementation))
            {
                instances[type] = instance;
            }
            else
            {
                instances.Add(type, instance);
            }
        }

        public static void Register<T>()
        {
            Register(typeof(T));
        }

        public static void Register<T, TI>()
        {
            Register(typeof(T), typeof(TI));
        }


        public static T Get<T>()
        {           
            var implementationType = typeof(T).GetInterfaces().FirstOrDefault();

            if(typeof(T).IsInterface)
            {
                implementationType = typeof(T);
            }

            if (instances.ContainsKey(implementationType))
            {
                return (T)instances[implementationType];
            }
            else
            {
                return default(T);
            }
        }
    }

```

Como podemos comprobar tenemos un diccionario que integra tipos e implementaciones.

También tenemos 2 métodos:  _Register_,  _Get_  Mientras el primero nos permite incluir servicios dentro del contenedor, el segundo nos permitirá recuperarlos.

#### Consumimos

Tras crear este servicio de dependencias, vamos a introducir el servicio anteriomente creado dentro de nuestro contenedor, para poder trabajar activamente  
con él.

Como ya hemos comentado en los anteriores vídeos, existen muchos Frameworks de MVVM que facilitan el trabajo a desarrollar. Vamos a mencionar los  
más importantes para que puedas conocerlos y trabajar con ellos

### Prism

[Prism](https://github.com/PrismLibrary/Prism)  es uno de los Frameworks más antiguos y que han sabido sobrevivir a los distintos cambios en la tecnología  
una de las características principales de  **Prism**  es que podemos integrar el contenedor de inyección de dependencias que nos resulte más comodo trabajar

Puedes dar tus primeros pasos con este usando este  [tutorial](https://www.c-sharpcorner.com/article/getting-started-mvvm-pattern-using-prism-library-in-wpf/)

### MVVMLight

Al igual que  **Prism**  [MVVMLight](http://www.mvvmlight.net/)  es uno de los más antiguos y más comunes en su uso. Desde la misma página del creador  
puedes acceder a distintos tutoriales para su uso.

### MVVMCross

Aunque  [MVVMCross](https://www.mvvmcross.com/)  se creo principalmente para ser utilizado para Xamarin, se ha extendido a distintas plataformas y es  
uno de los frameworks de MVVM más completos que se pueden encontrar en la red.

Tiene una comunidad extensa de colaboradores y suele estar a la última en las tendencias, principalmente de Xamarin. Desde la misma página del frameworks  
puedes conocer todas sus particularidades y ver como empezar con la misma.

### ReactiveUI

Aunque no es un framework de MVVM tan completo como los anteriores,  [ReactiveUI](https://reactiveui.net/)  nos plantea una nueva manera  
de poder gestionar nuestro código con un patrón Reactivo. Durante las proximas clases veremos más de este framework y como poder usarlo.

Como ya hemos mencionado antes  [ReactiveUI](https://reactiveui.net/)  es un framework MVVM que nos plantea una nueva perspectiva reactiva. Si quieres  
descubrir más de que plantea este paradigma, recomiendo que leas el  [ReactiveManifesto](https://www.reactivemanifesto.org/)

Vamos a realizar el ejercicio que vimos durante la sesión de introducción de MVVM pero con este Framework.

### Agregar ReactiveUI

Para agregar ReactiveUI dentro de nuestro proyecto WPF, necesitamos agregar la libreria Nuget del mismo.

### ReactiveObject

Cuando marcamos un objeto con esta clase, le añadimos propiedades similares a las que implementamos con el BaseViewModel en el ejemplo anterior.  
No obstante, ese objeto pasa a ser reactivo.

### ReactiveCommand

Al igual del  _Command_  que usamos. En esta ocasión, vamos a usar  _ReactiveCommand_  que es el comando implementado por parte de ReactiveUI.

ReactiveUI tiene ciertas funcionalidades que carecen otros Frameworks de MVVM gracias a tratarse de una programación Reactiva. En este vídeo vamos a  
ver algunas de esas funcionalidades que hacen que nuestra programación resulte más cómoda en el día a día.

### FromEventPattern

Podemos crear Observables, que nos permitan sincronizarnos con Eventos. Estos eventos están libres inicialmente de  _leaks_  de memoria. Además de que  
pueden añadirse condiciones de disparado usando los operadores de  **Linq**  otorgados por el espacio de nombres  _System.Reactive.Linq_  (No confundir con Linq per se)

### WhenAnyValue

Podemos controlar si el valor de las distintas propiedades varío, subscribiendonos a ellos. Esto nos permite actuar diferente en nuestro código, pero  
que resulta realmente útil.

## Trabajando con datos

Conectar nuestra aplicación con el sistema de ficheros suele ser una tarea de lo más común. Necesitamos estar conectado con diferentes archivos que ya  
sean de nuestra aplicación (configuración, datos, etc.) Como que no pertenezcan a nuestra aplicación directamente (imagenes, importaciones/exportaciones)

Por lo que conocer las herramientas necesarias para trabajar con estos es completamente necesario.

#### File

Esta clase estática nos da todas las operaciones comunes que podemos hacer con cualquier fichero de nuestro sistema, desde abrirlo, hasta poder comprobar  
parte de sus metadatos.

#### Directory

Al igual que  **File**  la clase Directory, nos provee de operaciones para poder trabajar con directorios satisfactoriamente.

#### FileInfo / DirectoryInfo

Estas clases contienen toda la información necesaria de ficheros o carpetas, al igual que podemos obtenerla dentro de File.

Dentro de nuestra aplicación podemos trabajar tanto con ficheros de texto, como con ficheros binarios. La manera de trabajar con ellos es muy similar la diferencia principal es con que clase trabajaremos.

#### Stream

La clase base que usaremos para tratar con ficheros será Stream, está clase es la responsable de tratar con cualquier flujo de datos con el que estemos  
trabajando. Ya sea dentro de ficheros, como cuando recibamos datos desde una web, etc.

A su vez, esta clase tiene diferentes herencias que permiten trabajar más correctamente con la misma.

Alguno de los ejemplos son:  _MemoryStream_,  _StreamWriter_,  _StreamReader_,  _FileStream_

#### Liberar el recurso

Un detalle importante cuando trabajamos con ficheros es que estamos bloqueando un recurso (el fichero) para otros. Por lo que es esencial, tras tomar  
la información necesaria desbloquear el mismo. Es por ello muy interesante poner especial atención al usar los métodos  **Open**  cuando instanciamosy  
un Stream y con  **Close**

#### Serialización de datos

Este proceso permite convertir un objeto que al final es una secuencia de bytes hacia otro medio, ya sea un fichero, una base de datos, etc.

Su proposito es poder almacenar el estado del mismo.

A su vez, todas las propiedades que queramos guardar su estado deben tener un  _getter_  y un  _setter_  publico para que el proceso de serialización pueda  
acceder al mismo.

Existen diferentes tipos de Serialización:  _Binaria_,  _XML_,  _Json_  la única diferencia entre ellas es el fichero que generará.

Es un conjunto de componentes para acceder a datos y sus servicios. Es parte del .NET Framework. Parte de dos partes diferenciadas.

### Data Provider

Cada una de las bases de datos que tengan un conector ADO.Net contendrán lo especificado ahora, con la diferencia que poseerá un prefijo previo.

#### Connection

Proporciona la conexión con la base de datos. Además de actuar como constructor de los command.

#### Command

Usado para hacer alguna acción en la fuente de datos.

#### Transaction

Permite abrir un estado seguro con nuestra base de datos y las operaciones con commands que vayamos a hacer para no tener incongruencia en los datos

#### Parameter

Es un parametro para el command, un ejemplo de parametro puede ser una variable para un Where en una consulta SQL

#### DataAdapter

Es el objeto que permite transferir los datos hacía un  _DataSet_

#### DataReader

Trata como un cursor entre nuestra base de datos, procesando un dato a la vez. Lo veremos más detenidamente en el apartado de base de datos conectada.

### DataSets

Es un grupo de objetos que simulan en datos una base de datos relacional misma. Veremos más profundamente este objeto en el apartado de base de datos desconectada

### ADO.NET DESCONECTADO

Cuando trabajamos con la base de datos tomando una instantanea del momento al que fuimos a realizar la consulta, tomaremos un ambiente desconectado

Trabajaremos con el objeto  _DataSet_  anteriormente mencionado y posteriormente actualizaremos cuando tengamos de nuevo conexión.

Aunque puede resultar interesante en algunos escenarios, este método para operar con la base de datos suele ser menos eficiente que tomar una posibilidad  
de ADO.NET Conectado.

### DataSet

Es un grupo de clases que describen una base de datos relacional.

Un  **Dataset**  está compuesto de tablas con la clase  **DataTable**  y esta a su vez compuesta de filas con clase  **DataRow**

Uno de los valores interesantes dentro del DataSet es que también descargamos cualquier tipo de relación que pudiese haber dentro de la base de datos  
y cualquier tipo de  **Constraint**. Además de todo el esquema de la misma.

Usando está metodología, siempre abriremos una conexión con nuestra base de datos que nos permitirá tomar los datos más reciente que poseemos, este  
suele ser el método más común, tanto en cuanto, es más eficiente y porque no tenemos unos datos que pueden encontrarse obsoletos.

### DataReader

Esta clase es la que nos va a permitir trabajar con nuestros datos de manera conectada. Abriremos una conexión directa con la base de datos recorriendo  
cada uno de los registros que nos ha facilitado la consulta.

Dentro de nuestras aplicaciones tendremos ajustes propios del usuario, hay muchas maneras de poder trabajar en nuestros proyectos, con los ajustes.

Vamos a comentar las dos maneras más comunes.

### Fichero

Podemos crear un fichero de configuración con el que trabajamos como queramos y lo guardaremos dentro de nuestra carpeta de aplicación o guardarlo  
en una carpeta de usuario.

### Settings

Podemos trabajar con un sistema que nos provee .NET Framework para trabajar con las settings, este sistema es más comodo para nosotros, porque es el  
Framework el encargado de trabajar directamente con nuestra configuración y nosotros solo nos vamos a tener que preocupar en almacenar esa información  
correctamente.