using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject menuPanel; // Pannello del menu
    public GameObject creditPanel; // Pannello dei crediti
    public GameObject dialog; // Riferimento al dialog

    // Mostra il pannello dei crediti
    public void ShowCredits()
    {
        menuPanel.SetActive(false);
        creditPanel.SetActive(true);
    }

    // Torna al menu principale
    public void BackToMenu()
    {
        creditPanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    // Mostra il dialog di conferma
    public void ShowQuitDialog()
    {
        dialog.SetActive(true); // Attiva il dialog
    }

    // Nasconde il dialog di conferma
    public void HideQuitDialog()
    {
        dialog.SetActive(false); // Disattiva il dialog
    }

    // Esce dall'applicazione
    public void QuitApplication()
    {
        Application.Quit(); // Esce dall'app
        Debug.Log("Application Quit"); // Messaggio per il test in editor
    }
}
