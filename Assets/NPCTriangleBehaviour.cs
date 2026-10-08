
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.MPE;
using UnityEngine;

public class NPCTriangleBehavior : MonoBehaviour
{
//Utilizamos region Attributes y end region con el fin de definir nuestras variables principales

//Estas serán

//Nuesttra VelocidadMovmiento, para que se desplaze el objeto
//Nuestro moverTemporizador, la utilizaremos para hacer comparaciones matemáticas y el signo del mayor con el fin de utilizarlo como cálculo a traves
// de que nos permitirá asimismo, poder desplazar nuestro  objeto,  asimismo nuestra variable moverTemporizador, estará en cero, porque he asumido 
//que será asimismo la variable a través la cual, haré una transición de 0 a 2 segundos, para definir la variación del tiempo, entre dos intervalos a partir
// del cual, se desplazará nuestro triaungulo, 
//Nuestra FaseDuración, esta necesariamente estará en 2f, porque he pensado que para este proyecto, sería idoneo, hacer comparaciones con el >= entre el 
//moverTemporizador y la FaseDuración, para hacer que al llegar a cierto valor (de 0 a  dos segundos) se efectue nuestro cambio de transición a una nueva 
//FasedelMovimiento
//FasedelMovimiento, esta variable será crucial a la hora de determinar cuando el triángulo efectará un distinto desplazamiento, he pensado que 
//partiré de primero definir, mi mover temprizador >= Time.deltaTie, seguido de luego definir a la dirección que mi triángulo, se desplazará con el uso
//del transform.Translate, por último procederé a a comparar mi variable moverTemporizador con FaseDuración, con el if (moverTemporizador) >= Fase Duración porque una vez
//que moverTemporizador sea igual a FaseDuración, puesto que previamente defini que moverTemporizador >= Time.deltaTime, en esa transición de tiempo de 
//0 a 2, CUANDO llegue a 2, entonces, procederé a parar mi moverTemporizador igualándolo a 0, para una vez luego, cambiar mi valor de FasedelMovimiento hacia
//un número arbitrario, con el fin de definir una nueva forma de desplazamiento a partir de la cual se efectuará un distinto movimiento.
#region Attributes
public float VelocidadMovimiento = 10f;  
public float moverTemporizador = 0f;
public float FaseDuración = 2f;
private int FasedelMovimiento = 0;

private SpriteRenderer spriteRenderer;
#endregion 

private void Awake()
{
    spriteRenderer = GetComponent<SpriteRenderer>();
}

void Start()
{
        
}


void Update()
{
   moverTemporizador += Time.deltaTime; //Suma el tiempo a cada frame
    
    if (FasedelMovimiento == 0)
{
    //Movemos hacia la derecha
    transform.Translate(Vector3.right * VelocidadMovimiento * Time.deltaTime);

    
    //Si nuestro temporizador es mayor a la fase de duración nos movemos a la izquierda
    if (moverTemporizador >= FaseDuración)
    {
        moverTemporizador = 0f;
        FasedelMovimiento = 1; 
    }
}

else if (FasedelMovimiento == 1)
{
    // Movemos hacia la izquierda
    transform.Translate(Vector3.left * VelocidadMovimiento * Time.deltaTime);

    // Cuando pase el tiempo, cambaimos despues a la duración final
    if (moverTemporizador >= FaseDuración)
     {
        //Puesto que el temporizador parará en 0, transisiosaremos a la FasedelMovimiento 2
        //,haciendo que una vez que el movertemporizador se aproxime mediante >+ a la variable FaseDuración meadiante  Time.deltaTime, 
        // y por ello cambiará a la siguiente fase en la cual el triángulo se desplazará hacia la derecha
        moverTemporizador = 0f;
        FasedelMovimiento = 2;
      }
}
else if (FasedelMovimiento == 2)
        {
        //Movemos hacia la derecha
        transform.Translate(Vector3.right * VelocidadMovimiento * Time.deltaTime);

         //Puesto que el temporizador parará en 0, transisiosaremos a la FasedelMovimiento 3
        //,haciendo que una vez que el movertemporizador se aproxime mediante >+ a la variable FaseDuración meadiante  Time.deltaTime, 
        // y por ello cambiará a la siguiente fase en la cual el triángulo se desplazará hacia la izquierda nuevamente
         if (moverTemporizador >= FaseDuración)
             {
             moverTemporizador = 0f;
             FasedelMovimiento = 3; 
             }

        
        }
else if (FasedelMovimiento == 3)
        {
            //Movemos hacia la izquierda
            transform.Translate(Vector3.left * VelocidadMovimiento * Time.deltaTime);

            //Puesto que el temporizador parará en 0, transisiosaremos a la FasedelMovimiento 4
            //,haciendo que una vez que el movertemporizador se aproxime mediante >+ a la variable FaseDuración meadiante  Time.deltaTime, 
             // y por ello cambiará a la siguiente fase en la cual el triángulo se desplazará hacia la derecha nuevamente
            if (moverTemporizador >= FaseDuración)
            {
            moverTemporizador = 0f;
            FasedelMovimiento = 4;
            }
        }

else if (FasedelMovimiento == 4)
        {
            //Movemos hacia la derecha
            transform.Translate(Vector3.right * VelocidadMovimiento * Time.deltaTime);

            //Puesto que el temporizador parará en 0, transisiosaremos a la FasedelMovimiento 5
            //,haciendo que una vez que el movertemporizador se aproxime mediante >+ a la variable FaseDuración meadiante  Time.deltaTime, 
             // y por ello cambiará a la siguiente fase en la cual el triángulo se desplazará hacia la izquierda nuevamente
            if(moverTemporizador >= FaseDuración)
            {
                moverTemporizador = 0;
                FasedelMovimiento = 5;
            }
        }

else if (FasedelMovimiento == 5)
        {
            //Movemos hacia la izquierda
            transform.Translate(Vector3.left * VelocidadMovimiento * Time.deltaTime);

            //Puesto que el temporizador parará en 0, transisiosaremos a la FasedelMovimiento 6
            //,haciendo que una vez que el movertemporizador se aproxime mediante >+ a la variable FaseDuración meadiante  Time.deltaTime, 
             // y por ello cambiará a la siguiente fase en la cual el triángulo volverá hacia su valor de retorno inicial
            if (moverTemporizador >= FaseDuración)
            {
                moverTemporizador = 0;
                FasedelMovimiento = 6;
            }
        }
else if (FasedelMovimiento == 6)
        {
            //Movemos hacia Arriba
            transform.Translate(Vector3.up * VelocidadMovimiento * Time.deltaTime);
             //Puesto que el temporizador parará en 0, transisiosaremos a la FasedelMovimiento 7
            //,haciendo que una vez que el movertemporizador se aproxime mediante >+ a la variable FaseDuración meadiante  Time.deltaTime, 
             // y por ello cambiará a la siguiente fase en la cual el triángulo volverá hacia su valor de retorno inicial
            if (moverTemporizador >= FaseDuración)
            {
                moverTemporizador = 0;
                FasedelMovimiento = 7;
            }

        }

else if (FasedelMovimiento == 7)
        {
            //Movemos hacia la Derecha
            transform.Translate(Vector3.right * VelocidadMovimiento * Time.deltaTime);
            //Puesto que el temporizador parará en 0, transisiosaremos a la FasedelMovimiento 8
            //,haciendo que una vez que el movertemporizador se aproxime mediante >+ a la variable FaseDuración meadiante  Time.deltaTime, 
             // y por ello cambiará a la siguiente fase en la cual el triángulo volverá hacia su valor de retorno inicial
            if (moverTemporizador >= FaseDuración)
            {
                moverTemporizador = 0;
                FasedelMovimiento = 8;
            }
        }

else if (FasedelMovimiento == 8)
        {
          //Movemos hacia Arriba
          transform.Translate(Vector3.up * VelocidadMovimiento * Time.deltaTime);
          //Puesto que el temporizador parará en 0, transisiosaremos a la FasedelMovimiento 9
            //,haciendo que una vez que el movertemporizador se aproxime mediante >+ a la variable FaseDuración meadiante  Time.deltaTime, 
             // y por ello cambiará a la siguiente fase en la cual el triángulo volverá hacia su valor de retorno inicial
          if (moverTemporizador >= FaseDuración)
            {
                moverTemporizador = 0;
                FasedelMovimiento = 9;
            }
        }

else if (FasedelMovimiento == 9)
        {
            //Movemos hacia la Izquierda
            transform.Translate(Vector3.left * VelocidadMovimiento * Time.deltaTime);
            //Puesto que el temporizador parará en 0, transisiosaremos a la FasedelMovimiento 10
            //,haciendo que una vez que el movertemporizador se aproxime mediante >+ a la variable FaseDuración meadiante  Time.deltaTime, 
             // y por ello cambiará a la siguiente fase en la cual el triángulo volverá hacia su valor de retorno inicial
            if (moverTemporizador >= FaseDuración)
            {
                moverTemporizador = 0;
                FasedelMovimiento = 10;
            }

           
            
        }
else if (FasedelMovimiento == 10)
        {
            //Al igualar moverTemporizador y la FasedelMovimiento, el triánuglo parará, puesto que carece de un tranform, que varie la dirección.

           if (moverTemporizador == FaseDuración)
            {
                moverTemporizador = 0;
                FasedelMovimiento = 0;
            }
        }
 

}

}