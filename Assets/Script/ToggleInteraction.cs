using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Per cambiare scena

public class ToggleInteraction : MonoBehaviour
{
    public Toggle startToggle;
    public Toggle creditToggle;
    public Toggle quitToggle;

    public GameObject buttonsPanel;  // Pannello che contiene i pulsanti (Start, Credit, Quit)
    public GameObject creditPanel;  // Pannello che contiene le immagini e il testo dei crediti

    void Start()
    {
        // Associa i listener agli eventi di cambio di stato dei toggle
        if (startToggle != null)
            startToggle.onValueChanged.AddListener(delegate { OnToggleClicked("Start"); });

        if (creditToggle != null)
            creditToggle.onValueChanged.AddListener(delegate { OnToggleClicked("Credit"); });

        if (quitToggle != null)
            quitToggle.onValueChanged.AddListener(delegate { OnToggleClicked("Quit"); });

        // Assicurati che il pannello dei crediti sia nascosto all'inizio
        if (creditPanel != null)
            creditPanel.SetActive(false);

        // Assicurati che il pannello dei pulsanti sia visibile all'inizio
        if (buttonsPanel != null)
            buttonsPanel.SetActive(true);
    }

    void OnToggleClicked(string toggleName)
    {
        Debug.Log($"Ho toccato {toggleName}");

        if (toggleName == "Start")
        {
            Debug.Log("Cambio scena a 'SampleScene'");
            SceneManager.LoadScene("SampleScene"); // Cambia alla scena chiamata "SampleScene"
        }
        else if (toggleName == "Quit")
        {
            Debug.Log("Esco dall'applicazione");
            Application.Quit(); // Esce dall'applicazione
        }
        else if (toggleName == "Credit")
        {
            Debug.Log("Mostro il pannello dei crediti");

            // Nascondi il pannello dei pulsanti e mostra il pannello dei crediti
            if (buttonsPanel != null)
                buttonsPanel.SetActive(false);

            if (creditPanel != null)
                creditPanel.SetActive(true);
        }
    }

    private void OnDestroy()
    {
        // Rimuovi i listener per evitare problemi di memoria
        if (startToggle != null)
            startToggle.onValueChanged.RemoveAllListeners();

        if (creditToggle != null)
            creditToggle.onValueChanged.RemoveAllListeners();

        if (quitToggle != null)
            quitToggle.onValueChanged.RemoveAllListeners();
    }
}
