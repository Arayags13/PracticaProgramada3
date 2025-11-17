Grupo C.

1. Integrantes finales del grupo. A los que se les asignará la nota del proyecto 

1.Felipe Mora Quesada
2.Sebastián Araya Gómez
3.Johnson Abarca Chaves
4.Fabián Araya Marchena

2. Enlace del repositorio si lo subió en GitHub o en algún otro. 

https://github.com/Arayags13/PracticaProgramada3.git

3. Especificación básica del proyecto:
a. Arquitectura del proyecto (tipos de proyectos que utilizo y contiene el 
programa) 

1. PracticaProgramada3 (Capa de Presentación / API – ASP.NET Core Web API)

Es el proyecto principal encargado de exponer los endpoints y manejar las solicitudes HTTP.
Contiene:

-Controllers que reciben las peticiones del cliente y delegan la lógica a la BLL.
-Configuración de Swagger.

2. PracticaProgramada3BLL (Business Logic Layer)

Es la capa donde vive la lógica de negocio del sistema.
Contiene:

-Dtos o modelos intermedios utilizados para transportar información sin exponer entidades internas.
-Mapeos configurados con AutoMapper, permitiendo convertir entidades ↔ DTOs fácilmente.
-Reglas y validaciones que aplican antes de enviar los datos a la DAL o responder a la API.

3. PracticaProgramada3DAL (Data Access Layer)

Es la capa responsable del acceso a datos mediante Entity Framework Core.
Contiene entidades que representan las tablas de la base de datos.


b. Libraries o paquetes de nuget utilizados

Paquetes de NuGet utilizados:
AutoMapper (15.0.1) Utilizado para mapear entidades a DTOs y simplificar la transferencia de datos entre capas.

c. Principios de SOLID y patrones de diseño utilizados 

SRP – Single Responsibility Principle:
OCP – Open/Closed Principle:
LSP – Liskov Substitution Principle:
ISP – Interface Segregation Principle:
DIP – Dependency Inversion Principle:

Patrones de diseño utilizados:

Repository (implícito mediante Entity Framework Core):
DTO + AutoMapper:
Para transferir datos entre capas sin exponer entidades internas.
Dependency Injection:
Arquitectura en Capas (Layered Architecture):
API, BLL, DAL, separadas.
MVC (en el sentido API + lógica + datos):

















