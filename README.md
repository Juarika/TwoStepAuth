# Autenticación en Dos Factores (2FA)

Este proyecto se centra en la implementación de la autenticación en dos factores (2FA) para mejorar la seguridad de la autenticación de los usuarios. Proporciona una forma adicional de verificar la identidad del usuario, además de la contraseña, antes de permitir el acceso a una aplicación.

## Tabla de Contenidos

- [Descripción](#descripción)
- [Características](#características)
- [Instalación](#instalación)
- [Video](https://youtu.be/gJ3Wdb8qoU4?si=-yhyfhnjM3zqMLPx)

## Descripción

La autenticación en dos factores (2FA) es un método de seguridad que requiere que los usuarios proporcionen dos formas diferentes de autenticación antes de acceder a sus cuentas. Este proyecto proporciona una implementación básica de 2FA y se puede personalizar para integrarse con aplicaciones web, servicios o sistemas existentes.

## Características

- Autenticación de dos factores (2FA) mediante el uso de SMS.
- Registro de usuarios con información básica (nombre de usuario, contraseña, correo electrónico, etc.).
- Generación de códigos de seguridad aleatorios para cada usuario.
- Verificación de códigos de seguridad al iniciar sesión.
- Registro de actividad y errores en un archivo de registro (log).

## Instalación

Para utilizar este proyecto, sigue estos pasos:

1. Clona el repositorio:

```bash
git clone https://github.com/Juarika/TwoStepAuth.git
```

2. Creacion de base de datos:

```bash
cd TwoStepAuth/API &&
dotnet ef database update --project ./Persistence/ --startup-project ./API/
```

3. Creacion de cuenta twilio:
   -Igresa al link https://www.twilio.com/try-twilio y crea tu cuenta.  
   -En el panel de la izquierda ingresamos a Phone Numbers/Mange/Buy a Number (Twilio obsequia $15 para pruebas).  
   -Verifica que tu numero esta verificado en Phone Numbers/Mange/Verified Caller IDs.  
   -En la parte superior izquierda nos dirigimos al panel de la consola, alli encontraras tu Account Info (Account SID, Auth Token, My Twilio phone number).  

4. En el proyecto ingresamos a API/Helpers/SMSSettings.cs, y ingresamos los datos requeridos (Twilio_Account_SID = Account SID, Twilio_Auth_TOKEN = Auth Token, Twilio_Phone_Number = My Twilio phone number).

5. Poner en funcionamiento la base de datos (Desde API):

```bash
dotnet run
```

6. En el proyecto ingresamos a Views/Login.html y abrimos en el navegador.

7. Para empezar ingresamos en la opcion [Sign up] y creamos un usuario (recuerda que el phone sera el numero verificado en twilio).

8. En la opcion [Log in] nos loguearemos con el UserName y el Password ingresados, y nos llegara unn mensaje al telefono, ese mensaje debe ingresarse en el espacio correspondiente.
