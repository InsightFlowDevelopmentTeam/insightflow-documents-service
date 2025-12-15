# Insightflow - Documents Service

Es el servicio central de colaboración, encargado de la creación, visualización, actualización y eliminación de documentos dentro de un espacio de trabajo.Además, permite la administración del ciclo de vida de los documentos mediante identificadores únicos y eliminación lógica para mantener la trazabilidad.

---

### Patrones de Diseño Implementados

1. *Repository Pattern:* Separa acceso a datos
2. *Dependency Injection:* Desacopla dependencias del servicio
3. *DTO Pattern:* Transferencia segura entre capas
5. *Controller separation:* Controllers independientes

## Tecnologías Utilizadas

- *Framework:* ASP.NET Core 9.0
- *Despliegue:* Render
- *Comunicación Síncrona:* Http
- *Contenedores:* Docker
- *Versionado:* Git + Conventional Commits
- *CI/CD:* Github Actions

## Instalación y Configuración Local

### Requisitos Previos

- *.NET 9 SDK*: [Download](https://dotnet.microsoft.com/download/dotnet/9.0)
- *Visual Studio Code*: [Download](https://code.visualstudio.com/)

### 1. Clonar el Repositorio

bash
git clone https://github.com/InsightFlowDevelopmentTeam/insightflow-documents-service.git

cd DocumentsService


### 2. Instalar Dependencias

bash
dotnet restore


### 3. Compilar el Proyecto

bash
dotnet build


### 4. Ejecutar el Proyecto

bash
dotnet run


## Servicio desplegado

*API*: https://taller3-doc-backend.onrender.com 
