<article>
    <h1>Aplicación Walk With Me</h1>
    <img src="./src/assets/imgs/logo-kaplan.png" alt="100px">
    <h2>Descarga e instalacion</h2>
    
    <p>La aplicación está construida desde el entorno de 
        Ionic en su versión 3.9.2 la que permite crear
        una aplicación web uniendo las capacidades nativas 
        que nos ofrecen los smartphones.</p>
    <p>Para ejecutar la aplicación existen 2 métodos efectivos:</p>
    
    <h3>Método 1: Instalación desde APK</h3>
    
    <p>En la carpeta <a href="https://github.com/GonzaloUNAB2018/WalkWithMe/tree/master/apk">apk</a> 
        de github se cargan constantemente todas
        las actualizaciones importantes que se realizan a la aplicación.
        Solo debe descargarlas a un dispositivo <b>Android</b> versión 5.1 o 
        superior y ejecutarlo.</p>
    <p>Recuerde dar permisos para instalar desde fuentes desconocidas a su dispositivo</p>

    <h3>Método 2: Descarga del código y ejecución con entorno de desarrollador</h3>

    <p>Éste método es mas complejo ya que es principalmente para quienes puedan ejecutar usando
        un entorno de desarrollo.
    </p>
    <p>Las herramientas necesarias son las siguientes:
    </p>

    <ol>
        <li><a href="https://developer.android.com/studio">Android Studio</a></li>
        <li><a href="https://git-scm.com/downloads">Git</a></li>
        <li><a href="https://nodejs.org/es/download/">Node</a></li>
    </ol>

    <p>Una vez estén todas las aplicaciones instaladas, ejecutamos una aplicación de consola
        (yo uso Powershell) desde una carpeta a la que se destine el proyecto, por ejemplo
        "C:\Proyectos", desde donse se ejecuta los siguiente:
    </p>

    <h4>Instala Ionic v 3.9.2</h4>
    <code>npm install -g ionic@3.9.2 cordova@7.1.0</code>

    <h4>Descarga desde Github</h4>
    <code>git clone https://github.com/GonzaloUNAB2018/WalkWithMe</code>

    <h4>Ingresa a carpeta WalkWithMe</h4>
    <code>cd WalkWithMe</code>

    <h4>Descarga componentes con NPM</h4>
    <code>npm -i</code>

    <h4>Instala plataforma Android</h4>
    <code>ionic cordova platform add android@6.3</code>

    <h4>Prepara el entorno Android</h4>
    <code>ionic cordova prepare android</code>

    <p>En éste punto ya debes tener tu smartphone conectado al pc
        con los permisos de traspaso de datos correspondientes.
    </p>

    <h4>Instala la aplicación en el dispositivo</h4>
    <code>ionic cordova run android</code>
    
</article>
