# Proyecto: Pipeline CI/CD Básico para Aplicación de Creación de Empleados y Cálculo de Sueldo

## Objetivo
Este proyecto implementa un pipeline CI/CD básico utilizando GitHub Actions para una aplicación de escritorio en **.NET Framework**. 
La aplicación permite crear empleados y calcular el sueldo ganado en el mes según las horas trabajadas.

El pipeline automatiza el proceso de pruebas, construcción y despliegue de la aplicación, lo que permite una integración continua (CI) 
y entrega continua (CD) eficiente.

## URL del Repositorio
Puedes acceder al repositorio del proyecto en el siguiente enlace:
[https://github.com/VictorGalvez1203/Practica_3_Electiva.git](https://github.com/VictorGalvez1203/Practica_3_Electiva.git)

## El enlace al Historial de Action:
[Historial de Actions](https://github.com/VictorGalvez1203/Practica_3_Electiva/actions)

## Requisitos
- Cuenta de GitHub
- Conocimientos básicos de Git y GitHub Actions
- Editor de código (Visual Studio)
- .NET Framework instalado localmente

## Estructura del Proyecto
El repositorio contiene:
1. **Código de la aplicación**: Implementación de la funcionalidad para gestionar empleados y calcular sueldos.
2. **Pruebas unitarias e integradas**: Pruebas básicas para garantizar que la lógica funcione correctamente.
3. **Pipeline CI/CD**: Implementación de un workflow de GitHub Actions para automatizar el build, las pruebas y el despliegue a GitHub Pages.

## Pasos Realizados
1. **Configuración Inicial**  
   - Creación de un repositorio en GitHub.
   - Configuración de la estructura básica del proyecto.
   - Implementación de la aplicación para gestionar empleados y calcular el sueldo.

2. **Implementación de Pruebas**
   - Configuración de pruebas unitarias e integradas.
   - Pruebas básicas para verificar la correcta implementación de la funcionalidad.

3. **Configuración del Pipeline CI/CD**
   - Configuración del workflow en GitHub Actions para automatizar las pruebas, construcción y despliegue.
   - Despliegue a GitHub Pages.

## Problemas encontrados
Tuve problema con la integración del msbuild para .NET framework, pero logre solucionarlo implementando los siguientes archivo de configuración de GitHub Actions
- 1. Setup MSBuild
   - name: Setup MSBuild
     uses: microsoft/setup-msbuild@v2
     
- 2. Setup NuGet
     - name: Setup NuGet
       uses: NuGet/setup-nuget@v2.0.0
       
-3. Resumen
Setup MSBuild: Prepara MSBuild para que puedas compilar tu proyecto de .NET Framework.
Setup NuGet: Prepara NuGet para que puedas gestionar las dependencias del proyecto
  
### Configuración del Pipeline

El archivo `ci-cd-pipeline.yml` de GitHub Actions contiene la configuración del pipeline. El pipeline se activa en cada `push` a la rama `master` y realiza las siguientes etapas:

```yaml
name: CI/CD Pipeline

on:
  push:
    branches: [ master ]
  pull_request:
    branches: [ master ]

jobs:
  build:
    runs-on: windows-latest
    
    steps:
      - name: Checkout code
        uses: actions/checkout@v2
        
      - name: Setup MSBuild
        uses: microsoft/setup-msbuild@v2

      - name: Setup NuGet
        uses: NuGet/setup-nuget@v2.0.0
         
      - name: Restore dependencies
        run: nuget restore creacion_de_empleados.sln

      - name: Build project
        run: msbuild creacion_de_empleados.sln

      - name: Run tests
        run: |
          cd TestFundionalidades
          dotnet test TestFundionalidades.csproj --no-build --verbosity normal
