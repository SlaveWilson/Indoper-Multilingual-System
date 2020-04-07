using TMPro;
using UnityEngine;

[ExecuteInEditMode]
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
