# dotnet CLI 🚀  
 Para restaurar todos los paquetes instalados
 ```
dotnet restore
```
### Configurar dotnet user-secrets

  Inicializamos
 ```
dotnet user-secrets init
```

Seteamos los secretos

* Recuerden que SqlDbSettings hace referencia al objeto de 
appsettings.json 
* Password es la propiedad que tendrá ese objeto
* tucontraseña es el valor de esa propiedad

```
dotnet user-secrets set SqlDbSettings:Password tucontraseña
```

### Configurar base de datos (HACER ESTO SI NO HAS CONFIGURADO TU CADENA DE CONEXIÓN DESDE EL APPSETTINGS.JSON)

Como ya existe una migración solo tienen que poner esto en su CataloDemoDbContext 

```
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    if (!optionsBuilder.IsConfigured)
    {
        // Este es un ejemplo de cadena sin credentiales
        // $"Data Source=localhost; Initial Catalog=CatalogDemo; Integrated Security=true"
        // aqui su cadena de conexión
        //Pon la que se ajuste a ti
        
        optionsBuilder.UseSqlServer( $"Data source=TuServer; Initial Catalog=CatalogDemo; User Id=TuUsuario; Password=tucontraseña; TrustServerCertificate=True");
    }
}

```

Esto les creará una base de datos en SqlServer
```
dotnet ef database update
```

Con eso ya podrían correr el proyecto

 Para construir la solución 
 ```
dotnet build
```
 Para arrancar el proyecto
 ```
dotnet run
```

