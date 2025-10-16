# 🎯 Objetivo del proyecto

Desarrollar una aplicación para gestionar reservas en el restaurant Tucson del Hipódromo de Palermo, exclusivo para socios del club FUN. El sistema debe permitir:

- Registrar reservas para el turno “Noche” en 40 mesas (18 de 2 cubiertos, 15 de 4, 7 de 6).
- Validar anticipación de reserva según categoría del socio:
  - Classic: hasta 48 horas antes
  - Gold: hasta 72 horas antes
  - Platinum: hasta 96 horas antes
  - Diamond: sin restricción
- Asignar automáticamente una mesa disponible o agregar al cliente a la lista de espera.
- Reasignar mesas liberadas a clientes en espera según prioridad de categoría.
- Listar reservas y clientes en espera.
- Eliminar reservas y liberar mesas.

---

# 🧭 Directivas para Copilot Chat en TurneroTucson

## 🧱 Arquitectura
- Seguir estrictamente los principios de **Clean Architecture** y **Domain-Driven Design (DDD)**.
- Mantener la separación de responsabilidades entre capas.
- No mezclar lógica de infraestructura, presentación o persistencia dentro del dominio.

## 🗂️ Estructura de proyectos
Mantener la siguiente relación entre proyectos:

| Proyecto             | Puede referenciar a...                     |
|----------------------|--------------------------------------------|
| API                  | Domain, Infrastructure.IoC                |
| Application          | Domain                                     |
| Domain               | Ningún otro proyecto                       |
| Infrastructure.Data  | Domain                                     |
| Infrastructure.IoC   | Todos excepto API                          |

## 🧠 Reglas de diseño
- El proyecto **Domain** debe contener:
  - Entidades, Value Objects, Enumeraciones
  - Interfaces de servicios y repositorios
  - Excepciones de negocio
  - Todas las clases deben ser **clases mutables**, no `record`
  - Todos los nombres de clases y propiedades deben estar en **español**
- El proyecto **Application** debe contener:
  - Servicios de aplicación que implementan interfaces del dominio
  - Métodos en inglés, clases y propiedades en español
- El proyecto **API** debe contener:
  - Controllers, Requests, Responses
  - Clases y propiedades en español, métodos y endpoints en inglés
- El proyecto **Infrastructure.Data** debe contener:
  - Implementaciones de repositorios
  - Mappers y configuración de EF Core
  - Uso exclusivo de **InMemoryDatabase**
  - Las entidades deben tener el sufijo `Entity` (ej. `ReservaEntity`)
- El proyecto **Infrastructure.IoC** debe contener:
  - Configuración de dependencias
  - Registro de servicios, repositorios y contexto

## 🧪 Pruebas
- Las pruebas unitarias deben estar en `Application.Tests`
- Usar solo **xUnit** y **EF Core InMemoryDatabase** para testear

## 🧼 Convenciones
- Usar `record` solo para objetos inmutables como requests/responses
- Usar `DateOnly` para fechas sin hora
- Usar `Guid` como identificador único
- Evitar el uso de librerías externas salvo EF Core
- Los objetos de request/response deben tener nombres como `CreateReservaRequest`, `SearchReservaRequest`, `ReservaResponse`, etc.

## 🚫 Restricciones
- No usar AutoMapper, MediatR, FluentValidation ni ninguna otra librería externa
- No usar lógica condicional en los controllers
- No acceder directamente a `DbContext` fuera de los repositorios

## ✅ Buenas prácticas
- Validar reglas de negocio en servicios de aplicación
- Usar constantes para datos fijos como mesas, clientes y categorías
- Priorizar claridad y mantenibilidad sobre complejidad técnica
