# Rest api para sistema de ventas

## Descripción:

El proyecto lo estoy construyendo con el fin de practicar __Domain Driven Design(DDD)__, __Clean Architecture__, __Mediator Pattern__, __CQRS Pattern__, etc. y su aplicación en un proyecto api de __ASP.NET Core__.

## Funciones a incluir:

* Autenticación mediante JWT Bearer.
* Protección de endpoints mediante roles.
* Registro de categorias, productos, usuarios, clientes,proveedores.
* Registro de ventas a usuarios registrados y no registrados.
* Registro de ventas a crédito para usuarios registrados.
* Registro de pagos para las ventas.
* Registro de compras.
* Actualización del stock en base a las ventas y compras registradas.

### Tecnologías:

* .NET.
* ASP.NET CORE.
* Entity Framework.
* SQL Server.
* JWT.
* MediatR.

#### Nota: el proyecto se encuentra en fase de desarrollo, por lo que no se encuentra desplegado en ningún hosting; si desea probar las funcionalidades incluidas entonces siga los siguientes pasos.

### Pasos para correr el proyecto de manera local:

* Tener el ID Visual Studio installado.
* Tener SQL Server instalado o tener el contenedor de docker de SQL Server corriendo.
* Dentro del proyecto API renombrar archivo appsettings.template.json a appsettings.Development.json y en la variable DefaultConnection agregar su cadena de conexión a la base de datos SQL Server.
	Ejemplo: ```"ConnectionStrings": {
    "DefaultConnection": "Data Source=localhost;Initial Catalog=GroceryStoreDb;User Id=sa;password=@MyStrongPassword92;TrustServerCertificate=True;"
  }```
* Click derecho en el proyecto API y seleccionar la opción de "establecer como proyecto de inicio"(set as startup project)
* Ahora solo tiene que hacer click en el botón de ejecutar para correr el servidor y se le abrirá una ventana de swagger en el navegador, en la cual podra ver los endpoints disponibles y hacer peticiones a los mismos.