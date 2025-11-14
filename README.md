# PPS_Ruleta_Solucion
Este proyecto simula una calculadora en C#. Este proyecto se centra sobre todo en la creación de los tests.

## Autores
- Adrián Vera
- Iván Barguilla
- Santiago Francés

## Tests
Aquí se listan todas las pruebas realizadas (marcadas con una X):
- [X] Pruebas unitarias - Se encuentran [aqui](./Calculator.Tests/UnitTests.cs)
- [X] Pruebas de integración - Se encuentran [aqui](./Calculator.Tests/IntegrationTests.cs)
- [X] Pruebas de sistemas (E2E) - Se encuentran [aqui](./Calculator.Tests/SystemTests.cs)
- [X] Pruebas de humo - Se encuentran [aqui](./Calculator.Tests/SmokeTests.cs)

## Ejecución
El proyecto se compila, testea y activa gracias al [MakeFile](makefile) creado. Opciones disponibles:
- 'clean' -> Limpia el proyecto de archivos generados por .NET
- 'run' -> Ejecuta el programa
- 'test' -> Ejecuta los test(s)