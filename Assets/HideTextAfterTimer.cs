using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class HideTextAfterTimer : MonoBehaviour
{
    public float hideTime = 1.0f;
    public float showTime = 1.0f;// The delay in seconds before hiding the text
    public TextMeshProUGUI tmpText; // Reference to the TMP text component

    void Start()
    {
      //  tmpText = GetComponent<GameObject>(); // Get the TMP text component on start
        tmpText.enabled = false;
        Invoke("HideTMPText", hideTime); // Call the HideTMPText method after the delay
        Invoke("ShowTMPText", showTime);
    }

    void HideTMPText()
    {
        tmpText.enabled = false; // Disable the TMP text component
    }

    void ShowTMPText()
    {
        tmpText.enabled = true; // Disable the TMP text component
    }
}