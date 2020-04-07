using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextLocaliserUI : MonoBehaviour
{
    TextMeshProUGUI textField;

    public LocalisedString localisedString;

    private void Start()
    {
        textField = GetComponent<TextMeshProUGUI>();
        string value = localisedString.value;
        textField.text = value;
    }
}
