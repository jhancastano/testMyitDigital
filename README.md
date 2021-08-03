# testMyitDigital

PRUEBA TECNICA DESARROLLADOR .NET
| item | valor |
| ------------- | ------------- |
| VERSIÓN | 2.0 |
| FECHA |29/07/2021 |
# 1.3 Sección Teórica

## ¿Qué son y para qué sirven los servicios web?
son tecnologias que utilizan un conjunto de protocolos y estandares para intercambiar datos entre aplicaciones

## Explique la diferencia entre un API Rest y un servicio SOAP.
la mayor diferencia es el formato en que se envian los mensajes de los servicios,en  SOAP se utiliza XML para todos los mensajes, en cambio rest puede usar difretes formatos de mensajes mas pequeños como son texto plano,HTML,XML,JSON.

## Mencione al menos 3 formatos en los cuáles una API Rest entrega información por medio de HTTP.
1. texto plano
2. html
3. json

## Se solicita construir un método en el cual se reciba como parámetro una cadena y retorne si dicha cadena es palíndroma o no, recordar que una palabra “palíndromo” es aquella que se lee igual de izquierda a derecha o de derecha a izquierda. Par este punto puede utilizar el lenguaje de programación deseado, incluso pseudocódigo.

```javascript
function isPalindrome(str){
    const strReversed = str.split("").reverse.join("")
    return str === strReversed ? "Es Palindromo": "No es palindromo"
 }
console.log( isPalindrome("anitalavalatina") )
```
# 1.4 Sección Práctica
 Se solicita crear una API Rest .Net con lenguaje VB que implemente el consumo de un endpoint y devuelva como respuesta un Json con la información que a continuación se explica:
 Url del endpoint:  
https://min-api.cryptocompare.com/data/top/mktcapfull?limit=10&tsym=COP
 Valores para extraer: Precio del día (PRICE), valor más alto del día (HIGHDAY), valor más bajo del día (LOWDAY) y la variación de las últimas 24 horas (CHANGEPCT24HOUR) Los Atributos anteriormente solicitados debe ser extraídos solo de las criptomonedas: BITCOIN y THETER




## Configurar Web.config CREAR BASE DE DATOS sql server 
--------------------------
## Crear tabla en sql server
```sql
CREATE TABLE criptoHistoric
(Id INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
Nombre VARCHAR(100),
PRICE FLOAT(53),
HIGHDAY FLOAT(53),
LOWDAY FLOAT(53),
CHANGEPCT24HOUR FLOAT(53),
DATEOPERATION DATETIME ,
HOUROPERATION TIME 
);
```

## Acceder a la api rest mediante la peticion get a la ruta :
```
/api/cripto
```