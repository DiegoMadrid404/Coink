  
El presente proyecto esta construido mediante una arquitectura a capas: 

1. Servicios 
1. Negocio 
1. Datos 
1. Interfaces Comunes y DTO 

La arquitectura propuesta incluye una implementación de un repositorio para la entidad utilizando Entity Framework Core y Dapper para interactuar con la base de datos, de forma tal que permite utilizar en paralelo procedimientos almacenados o Entity Framework y posteriormente manipularse con LinQ. 

Las tablas paramétricas usan LinQ y la tabla usuario tiene toda su crud y consulta multitabla mediante procedimientos almacenados. 
 
