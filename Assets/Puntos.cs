using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntos : MonoBehaviour
{
    int puntos = 0;
    public Text puntaje;
    // Start is called before the first frame update
    void Start()
    {
        if (puntaje == null)
        {
            puntaje = GameObject.Find("Canvas").GetComponent<Text>();
        }
        texto();   
    }

   public void Contador(int sumarpuntos)
    {
        puntos += sumarpuntos;
        Debug.Log("puntaje actualizado: " + puntos);
        texto();
    }
    void texto()
    {
        if (puntaje != null)
        {
            puntaje.text = "Puntos: " + puntos;
        }
        else
        {
            Debug.LogWarning("El componente de texto no está asignado.");
        }
    }
}
