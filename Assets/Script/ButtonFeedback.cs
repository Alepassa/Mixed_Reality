using UnityEngine;
using TMPro;

public class ButtonFeedback : MonoBehaviour
{
    public TextMeshProUGUI feedbackText; // Campo per il messaggio di feedback

    public void OnButtonPressed()
    {
        // Mostra il messaggio "è premuto"
        feedbackText.text = "è premuto";
        Debug.Log("Bottone premuto!");
    }
}
