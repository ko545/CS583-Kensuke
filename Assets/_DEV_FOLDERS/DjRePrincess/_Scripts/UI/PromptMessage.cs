using UnityEngine;
using TMPro;

public class PromptMessage : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI prompText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void UpdateText(string promptMessage)
    {
        prompText.text = promptMessage;
    }
}
