using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Game : MonoBehaviour
{
    public Dificultad[] bancoDePreguntas;

    public Text enunciado;

    public Text[] respuesta;

    public int nivelPregunta;

    protected int preguntaAlAzar;

    // Start is called before the first frame update
    void Start()
    {
     
        nivelPregunta = 0;
        SeleccionarPregunta();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void Respuesta(int respuestaJugador)
    {
        Debug.Log("Ha seleccionado la opcion"+ respuestaJugador.ToString());
        EvaluarPregunta(respuestaJugador);
    }

    public void SeleccionarPregunta()
    {
        preguntaAlAzar = Random.Range(0,bancoDePreguntas[nivelPregunta].preguntas.Length);
       //Sacamos el texto del banco de preguntas y lo ponemos en el UI donde se despliega el enunciado.
        enunciado.text = bancoDePreguntas[nivelPregunta].preguntas[preguntaAlAzar].enunciado;

        //cargar los textos de cada boton del UI
        for (int i = 0; i < respuesta.Length; i++) 
        {
            respuesta[i].text = bancoDePreguntas[nivelPregunta].preguntas[preguntaAlAzar].respuestas[i].texto;
        }
    }

    public bool EvaluarPregunta(int respuestaJugador)
    {
        if (respuestaJugador == bancoDePreguntas[nivelPregunta].preguntas[preguntaAlAzar].respuestaCorrecta)
        {
            //reinicio de problema con mayor dificultad
            nivelPregunta++;
         

            if (nivelPregunta == bancoDePreguntas.Length)
            {
                // Desplegar la pantalla de fin de juego ganado!
                SceneManager.LoadScene("Gane");
            }
            else
            {
                SeleccionarPregunta();
                //subir nivel

            }

            return true;
        }
        else
        {
            SceneManager.LoadScene("Perder");
            return false;
        }
       
    }
}
