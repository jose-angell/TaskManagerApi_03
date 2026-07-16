# TaskManagerApi_03

Breve API REST para gestionar tareas (Task Manager) desarrollada en .NET 10.

Estado
------
Proyecto listo para desarrollo local y despliegue. Target framework: .NET 10.

Requisitos
----------
- .NET 10 SDK (https://dotnet.microsoft.com/)
- Visual Studio 2022/2026 o VS Code (recomendado Visual Studio Community 2026 según el entorno del desarrollador)
- Git

Instalación y ejecución
-----------------------
1. Clona el repositorio:

   git clone https://github.com/jose-angell/TaskManagerApi_03.git

2. Restaurar paquetes y compilar:

   dotnet restore
   dotnet build

3. Ejecutar la API localmente:

   dotnet run --project TaskManagerApi_03

La API quedará disponible en http://localhost:5000 o en el puerto configurado por Kestrel/launchSettings.

Endpoints principales
--------------------
Las rutas expuestas siguen la convención REST típica para recursos "tasks" (ajustar según la implementación actual):

- GET    /api/tasks           -> Listar todas las tareas
- GET    /api/tasks/{id}      -> Obtener una tarea por id
- POST   /api/tasks           -> Crear una nueva tarea (enviar JSON)
- PUT    /api/tasks/{id}      -> Actualizar una tarea existente
- DELETE /api/tasks/{id}      -> Eliminar una tarea

Ejemplo de petición para crear una tarea (curl):

```powershell
curl -X POST http://localhost:5000/api/tasks -H "Content-Type: application/json" -d '{"title":"Comprar leche","description":"Ir al supermercado","dueDate":"2026-07-20"}'
```

Configuración
-------------
Revisa el archivo appsettings.json y launchSettings.json para puertos y opciones de entorno. Añade cadenas de conexión u otras variables en appsettings.* o mediante variables de entorno según necesites.

Pruebas
------
Si el repositorio contiene proyectos de pruebas, se pueden ejecutar con:

   dotnet test

Contribuir
---------
1. Crea un fork y una rama para tu cambio.
2. Envía un pull request describiendo el cambio.

Licencia
--------
Revisa el archivo LICENSE si existe. Si no, contacta con el propietario del repositorio para aclarar términos de uso.

Contacto
-------
Repositorio: https://github.com/jose-angell/TaskManagerApi_03

