# SCCAD.Web

### Puesta en marcha

Una vez descargado el proyecto de github lo primero que se debe hacer es copiar el archivo **wwwroot/env.example.js** y renombrarlo a **wwwroot/env.js**
###### No debe eliminar el archivo de ejemplo

Ahora en el archivo **wwwroot/env.js** se debe cambiar la url de la api por la correcta en su servidor.

Por ejemplo:
```C#
    ...
    function envProvider () {
            
        this.apiUrl = 'http://localhost:55460/';

        ...
    }
    ...
```

Ahora debe estar listo para iniciar el proyecto.

#### Dependencias

Para descargar las dependencias solamente debe dar click a 'Restaurar paquetes' sobre la carpeta (virtual) de dependencias

![Captura de pantalla](http://i.imgur.com/oFsPOnj.png?1)