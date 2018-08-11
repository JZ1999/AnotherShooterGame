# Prototipo

## Bases del juego

>* **_Género_**: Top-down shooter, Action, Multiplayer
>* **_Temática e historia_**:
>* **_Plataformas_**: Windows, Linux
>* **_Modelo Comercial_**:
>* **_Público Objetivo_**:
* **_Version de Juego_**: 0.1.1.1


	El juego consiste en poder usar de una selección de naves; el cual cada nave contiene sus diferencias ya sea en velocidad, velocidad de disparar, habilidad y otras cosas. Podrás escojer una selección de niveles donde puedes escojer jugar **__solo__** o **__multijugador online__**. Cada nave va tener su niche, y tal podrá ser beneficio en algunos niveles mas que en otros y tambien se podrá crear sinergía usando una combinación de naves al jugar multijugador para poder crear estrategias para pasar los niveles. El juego esta basado en el game design y modelos de los siguientes juegos:
	1. ![Referencia #1](https://image.winudf.com/v2/image/Y29tLmxpYmVyc29mdC5nYWxhZ2Ffc2NyZWVuXzZfMTUxODczNzc1OV8wNTg/screen-6.jpg?h=355&fakeurl=1&type=.jpg)
	2. ![Referencia #2](https://static.giantbomb.com/uploads/original/1/19947/1659365-aspaceshooterfor2bucks__preview2.jpg)
	3. ![Referencia #3](http://romhustler.net/img/screenshots/n64/ingame/4fe4994dca8bf.jpg)

## Links
**[Repositorio en github](https://github.com/JZ1999/Galaga3D)**
```sh
git clone http://github.com/JZ1999/Galaga3D.git
```
**[Descarga de Juego]()**

## Controles

* Movimiento: A izquierda, D derecha
* Ataque: Barra de espacio
* Habilidad: Q
* Pausa: Esc
* Cambiar De Camara: F


## Estandar de Versiones

* **_Versión de Unity_**: 2018.1.8
***
[**_Número de compilación principal_**].[**_Número de compilación menor_**].[**_Revisión_**].[**_Paquete_**]
 
*Ejemplo*: 2.15.1.3


* **_Número de compilación principal_**: Esto indica un hito importante en el juego, incremente esto cuando vaya de versión beta a versión de producción, desde versión de producción hasta actualizaciones importantes.

* **_Número de compilación menor_**: Se usa para actualizaciones de funciones, correcciones de errores grandes, etc.

* **_Revisión_**: Pequeñas modificaciones en las características existentes, pequeñas correcciones de errores, etc.

* **_Paquete_**: Su código permanece igual, cambios en la biblioteca externa o actualización de archivos de activos.
***

## Estándares de codigo y workflow de programación

Muchos de los estándares vienen del libro [**Clean Code: A Handbook of Agile Software Craftsmanship: Robert C**](https://www.amazon.es/Clean-Code-Handbook-Software-Craftsmanship/dp/0132350882).
[*¡Dale click aquí. Practicas a seguir!*](https://codingwithspike.wordpress.com/2012/09/17/clean-code-cheat-sheet/)

> 1. Utilizar el preproceso [#region](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/preprocessor-directives/preprocessor-region) para funciones de Unity y para las Variables

> 2. Utilizar barra baja para variables que no sean de las clases de Unity *Ejemplo*: private int _var;

> 3. Evitar clases mas grandes que 100 lineas

> 4. Evitar lineas mas de 80 columnas

> 5. Evitar funciones con mas de 6 lineas

> 6. Usar nombres de funciones descriptivos, que hagan exclusivamente lo que dicen

> 7. Escribir nombre de variables descriptivos

> 8. Escribir nombre de clases descriptivos

> 9. **Nunca** dejar codigo comentado al hacer un git commit

> 10. Hacer [git commits](https://git-scm.com/docs/git-commit) frecuentes con mensajes semi detallados ejemplo: "Actualizar ataque de nave basica y editar el README"

> 11. Evitar cantidad excesiva de comentarios, el codigo debe hablar por si mismo

> 12. Todo codigo debe ser en __*español*__ y nombre de archivos

> 13. Evitar hacer un git commit con bugs del codigo que editaste, o que buguee el codigo de alguien mas

> 14. Por modularización, no hacer variables publicos (Hay excepciones), utilize el directivo [[Serializable]](https://docs.unity3d.com/ScriptReference/Serializable.html) en vez

> 15. Poner el codigo en sus carpetas respectivas (Scripts de objetos, de manejo y de informacion). Los de objetos son los que tienen una relacion directa con objetos.
>Los de manejo son los que controlan la escena como los objetos Managers. De ultimo, los de información guardan cosas como la información de las naves para poder tener acceso
>a esa información estatica.

> 16. Todas las clases que sean pronombres y que la primer letra sea mayúscula

> 17. Las funciones deben ser verbos y ser camel-case con la primer letra minúscula

> 18. Evitar el uso del try catch y no devolver codigos de errores. Devuelva un objeto descriptivo del error.

> 19. Usar formato [CRLF](https://es.wikipedia.org/wiki/CRLF)

> 20. los if, switch, for, while y funciones deben estar formateados con sus corchetes de tal manera:
>```c#
>if(booleano)
>{
> var++;
>}
>```

> 21. Hacer [git pull](https://git-scm.com/docs/git-pull) lo mas posible

> 22. Utilizar el [TODO](http://wordaligned.org/docs/todo/todo/what_does_todo_mean_.html) como en el siguiente codigo para un indicador de "sin terminar" o cosas que hacer en ese script:
>```c#
>//TODO:
>//Cosa que hacer
>```

> 23. Para los objetos [AudioSource](https://docs.unity3d.com/ScriptReference/AudioSource.html) al final del variable poner **SND**, para los de [texto](https://docs.unity3d.com/ScriptReference/UI.Text.html) poner **TXT** y los [transform](https://docs.unity3d.com/ScriptReference/Transform.html) poner **TR**.

> 24. En caso de codigo ambiguo, comentar de forma correcta.

> 25. Mantener encima de cada script (Al menos de que sea excepción), el atributo [[DisallowMultipleComponent]](https://docs.unity3d.com/ScriptReference/DisallowMultipleComponent.html) para no poner mas que uno del mismo script.

> 26. Utilizar Atributos de Unity en todo momento que se pueda aplicar como el [[Tooltip()]](https://docs.unity3d.com/ScriptReference/TooltipAttribute.html), [[Space]](https://docs.unity3d.com/ScriptReference/SpaceAttribute.html), [[Range()]](https://docs.unity3d.com/ScriptReference/SocialPlatforms.Range.html), etc.

> 27. No usar ningún caracter que no sea de [ASCII](https://www.asciitable.com/). Utilizar doble **n** en vez de **ñ**


## Desarrollo Scrum

Usamos el modelo de [Scrum](https://es.wikipedia.org/wiki/Scrum_(desarrollo_de_software)) con unas alteraciones para desarrollar este juego.

[![Video de Scrum](http://img.youtube.com/vi/a33xOe9d_Dk/0.jpg)](http://www.youtube.com/watch?v=a33xOe9d_DkE)

Se hacen sprints de 3 semanas, en el cual cada sprint va estar conformado por estas 4 etapas:

1. **Planear**
2. **Crear**
3. **Testing**
4. **Revisión**

Aplicaremos el sprint usando esta pagina web [**scrumblr.ca/prototipounity**](http://scrumblr.ca/prototipounity).
**En esa pagina los que tengan puntos rojos son los mas importantes**.

Se usa este modelo:

|[Backlog](https://programacionymas.com/blog/scrum-product-backlog)|Pendiente|Comenzando|[Testing](https://unity3d.com/es/learn/tutorials/topics/production/unity-test-tools)|Revision|Completo|
| ------------- |:-------------:| -----:|
| | | | | | |
| | | | | | |
| | | | | | |
| | | | | | |
| | | | | | |
| | | | | | |

En vez de hacer reuniones todo los dias como se hace en scrum,
se harán reuniones cada fin de semana para hablar sobre modificaciones,
 implementaciones y arreglo de bugs, problemas que a tenido, aportes para el juego,
opiniones del juego y workflow, y tener una conversacion sobre cosas de ese tipo.
Cada reunion que tengamos vamos a ir aportando al backlog.

Usando los valores y principios de [Agile](https://es.wikipedia.org/wiki/Desarrollo_%C3%A1gil_de_software) debemos tener bastante comunicacion para tener resultados deseables.

**Cada sprint es importante tener un producto usable y potencialmente listo para que sea un build**

#### Scrumblr

***
[Scrumblr](http://www.scrumblr.com/prototipounity) ademas de usar los marcadores rojos para
enseñar cuales tiquetes son los mas importantes, sino tambien se usará lo siguiente:


<p style="color:red"><b>■ Tiquete importante</b></p>
<p style="color:blue"><b>■ Tiquete de Joseph</b></p>
<p style="color:yellow"><b>■ Tiquete de Ricardo</b></p>
<p style="color:green"><b>■ Tiquete de Alejandro</b></p>
<p style="color:orange"><b>■ Tiquete en espera(Se usa cuando un tiquete no se a podido completar en ese momento)</b></p>

## Creditos

#### Ricardo
[LinkedIn](https://www.linkedin.com/in/joseph-david-zamora-murillo-3645a7148/)
[Github](https://www.github.com/JZ1999)
***
#### Joseph David Zamora Murillo
[LinkedIn](https://www.linkedin.com/in/joseph-david-zamora-murillo-3645a7148/)
[Github](https://www.github.com/JZ1999)
***
#### Sharon 
[LinkedIn](https://www.linkedin.com/in/joseph-david-zamora-murillo-3645a7148/)

***
#### Alejandro
[LinkedIn](https://www.linkedin.com/in/joseph-david-zamora-murillo-3645a7148/)
[Github](https://www.github.com/JZ1999)
***


#### Gustavo
[LinkedIn](https://www.linkedin.com/in/joseph-david-zamora-murillo-3645a7148/)
***


#### Gilberto
[LinkedIn](https://www.linkedin.com/in/joseph-david-zamora-murillo-3645a7148/)
***