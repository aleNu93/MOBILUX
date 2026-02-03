# 📱 Mobilux

Mobilux es una aplicación móvil desarrollada como proyecto académico, orientada al **control financiero de compras de mobiliario de alto valor adquiridas mediante financiamiento**. La aplicación permite a un cliente individual llevar un seguimiento claro y estructurado de cuánto debe por cada mueble, los abonos realizados y el estado general de sus compras.

El proyecto simula un entorno real de financiamiento comercial, utilizando condiciones reales de mercado como primas mínimas, plazos definidos y tasas de interés, con un enfoque práctico y profesional.

---

## 🎯 Objetivo del proyecto

Brindar una herramienta móvil que permita a los usuarios:

- Registrar compras de muebles financiados  
- Definir condiciones financieras reales por compra  
- Registrar abonos realizados  
- Consultar saldos pendientes y estados de pago  
- Visualizar reportes generales de compras activas  
- Recibir notificaciones automáticas por correo electrónico  

Todo esto sin depender directamente de la información proporcionada por la casa comercial.

---

## 🧩 Funcionalidades principales

- **Autenticación de usuario**
  - Acceso protegido mediante credenciales

- **Gestión de compras financiadas**
  - Registro de muebles adquiridos
  - Definición de precio, prima inicial, plazo y tasa de interés
  - Asociación con proveedor y categoría del mueble

- **Registro de abonos**
  - Ingreso de pagos realizados por compra
  - Actualización del saldo pendiente

- **Consultas financieras**
  - Saldo pendiente
  - Cantidad de abonos realizados
  - Fecha estimada de finalización
  - Detalle individual por compra
  - Separación clara entre múltiples compras

- **Reporte general**
  - Resumen de todas las compras activas del cliente

- **Gestión de correos**
  - Configuración de correo primario
  - Correo secundario opcional para notificaciones

- **Notificaciones automáticas**
  - Envío de correos al registrar compras y abonos

---

## 🗂️ Arquitectura

Mobilux está diseñado bajo una **arquitectura por capas**, compuesta por:

- **Base de datos transaccional**
  - Diseño propio
  - Normalizada
  - Reglas de integridad mediante claves y restricciones

- **Aplicación móvil**
  - Desarrollada en **C# con .NET MAUI**
  - Compatible con **Android e iOS**

- **Web Service**
  - Opcional, según la arquitectura final definida por el equipo

---

## 🖥️ Pantallas del sistema

El sistema contempla las siguientes pantallas:

1. Pantalla de bienvenida / Login  
2. Menú principal / Dashboard  
3. Listado de compras  
4. Detalle de compra  
5. Registro de compra  
6. Registro de abono  
7. Reporte general  
8. Gestión de correos  
9. Perfil del cliente  
10. Ayuda / Acerca de  

---

## 🎨 Diseño visual

- Interfaz personalizada
- Colores y fondos definidos
- Botones personalizados
- No se utilizan componentes visuales estándar ni fondos blancos
- Diseño orientado a sobriedad, claridad y usabilidad

---

## 🛠️ Tecnologías utilizadas

- **Lenguaje:** C#  
- **Framework:** .NET MAUI  
- **Base de datos:** SQL Server  
- **Plataformas objetivo:** Android / iOS  

---

## 📚 Contexto académico

Este proyecto forma parte del curso de **Desarrollo de Aplicaciones Móviles** y tiene fines **exclusivamente académicos**.  
Las marcas comerciales utilizadas se emplean únicamente como referencia visual para simular escenarios reales de financiamiento.

---

## 👥 Autores

Proyecto desarrollado por estudiantes como parte de la evaluación académica del curso.
