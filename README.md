# Proyecto #2 SO

## Referencia API

#### Traducir palabra

```http
  GET /api/traductor?param1=value1&param2=value2&param3=value3
```

| Parámetro | Tipo     | Descripción  | Opciones|
| :-------- | :------- | :---------   |:---------|
| `origen`  | `string` | **Requerido**. Idioma de la palabra ingresada |en, es, fr|
| `palabra` | `string` | **Requerido**. Palabra por traducir |Ver sección de documentación|
| `destino` | `string` | **Requerido**. Idioma de destino |en, es, fr|


#### Obtener archivo log

```http
  GET /files/log.txt
```

## Documentación


| Idioma | Palabras disponibles     | 
| :----  | :------- |
| `es`   | oso, castor, toro, camello, gato, puma, vaca, venado, perro, elefante |
| `en`   | bear, beaver, bull, camel, cat, cougar, cow, deer, dog, elephant|
| `fr`   | ourse, castor, taureau, chameau, chat, puma, vache, cerf, chien, l'éléphant| 

#### Puerto: `5024` 
## Ejemplos

`http://HOST/api/traductor?origen=en&palabra=cougar&destino=es`

`http://HOST/api/traductor?origen=es&palabra=gato&destino=en`
## Instalación

Instalar utilizando docker

```bash
  docker pull jeanka143/proyecto_so
```
    
## 🔗 Links
[![Docker](https://img.shields.io/badge/Docker_image-2496ed?style=for-the-badge&logo=docker&logoColor=white)](https://hub.docker.com/r/jeanka143/proyecto_so)
