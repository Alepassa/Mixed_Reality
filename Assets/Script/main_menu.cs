using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main_menu : MonoBehaviour
{
    public void ClickToStart(){
        Debug.Log("Start game");
        SceneManager.LoadScene("SampleScene");
    }


    public void ClickToQuit(){
        Debug.Log("Quit game");
        Application.Quit();
    }
}
