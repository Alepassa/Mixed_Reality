using UnityEngine;
using System.IO; // Libreria necessaria per la gestione di file

public class hand_tracking : MonoBehaviour
{
    public GameObject left_hand_parent;
    public GameObject right_hand_parent;

    // Start is called once before the first execution of Update after the MonoBehaviour is enabled
    void Start()
    {
        foreach (Transform child in left_hand_parent.GetComponentsInChildren<Transform>())
        { 
            if (child.Find("TrackingSphere") == null) 
            {
                GameObject redSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                redSphere.name = "TrackingSphere";
                redSphere.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
                redSphere.GetComponent<Renderer>().material.color = Color.red;
                redSphere.transform.parent = child;
                redSphere.transform.localPosition = Vector3.zero;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        string path = "hand_positions.txt";
        using (StreamWriter writer = new StreamWriter(path, true)) // Append to the file instead of overwriting
        {
            foreach (Transform child in left_hand_parent.GetComponentsInChildren<Transform>())
            {
                if (child.gameObject.GetComponent<Renderer>() == null) // Exclude the sphere
                {
                    writer.WriteLine($"{child.name}: {child.position}");
                }
            }
            foreach (Transform child in right_hand_parent.GetComponentsInChildren<Transform>())
            {
                if (child.gameObject.GetComponent<Renderer>() == null) // Exclude the sphere
                {
                    writer.WriteLine($"{child.name}: {child.position}");
                }
            }
        }
    }

    private void IsHandClose()
    {
        // Supponiamo che il tuo oggetto pollice sia b_l_index1 e che il pollice su sia rappresentato da una certa posizione e rotazione
        Transform finger = null;
        foreach (Transform child in left_hand_parent.GetComponentsInChildren<Transform>())
        {
            if (child.name == "l_index_finger_tip_marker")
            {
                finger = child;
                break;
            }
        }

        // Controlliamo la posizione e la rotazione del pollice per rilevare il gesto
        if (finger != null)
        {
            Vector3 relativePosition = left_hand_parent.transform.InverseTransformPoint(finger.transform.position);
            //Debug.Log(relativePosition);
            if (relativePosition.x > -0.08f && relativePosition.x < -0.06f &&
                relativePosition.y > 0.02f && relativePosition.y < 0.04f &&
                relativePosition.z > -0.03f && relativePosition.z < -0.01f)
            {
                Debug.Log("Mano chiusa rilevata!");
            }
        }
    }

}
