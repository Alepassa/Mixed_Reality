using UnityEngine;
using UnityEngine.UI;

public class ToggleInteraction : MonoBehaviour
{
    public Toggle startToggle;
    public Toggle creditToggle;
    public Toggle quitToggle;

    void Start()
    {
        // Associa i listener agli eventi di cambio di stato dei toggle
        if (startToggle != null)
            startToggle.onValueChanged.AddListener(delegate { OnToggleClicked("Start"); });

        if (creditToggle != null)
            creditToggle.onValueChanged.AddListener(delegate { OnToggleClicked("Credit"); });

        if (quitToggle != null)
            quitToggle.onValueChanged.AddListener(delegate { OnToggleClicked("Quit"); });
    }

    void OnToggleClicked(string toggleName)
    {
        Debug.Log($"Ho toccato {toggleName}");
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
