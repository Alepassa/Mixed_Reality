using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_color : MonoBehaviour
{


    
    public Renderer cubeRenderer;


    public void ChangeCubeToGreen()
    {
        if (cubeRenderer != null)
        {
            // Cambia il colore del cubo in verde
            cubeRenderer.material.color = Color.green;
            Debug.Log("Il cubo è stato cambiato in verde.");
        }
        else
        {
            Debug.LogError("Il Renderer del cubo non è assegnato!");
        }
    }

}
