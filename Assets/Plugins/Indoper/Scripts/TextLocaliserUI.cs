using Sirenix.OdinInspector;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(TextMeshProUGUI))]
public class TextLocaliserUI : MonoBehaviour
{
    TextMeshProUGUI textField;

    [HideLabel]
    public LocalisedString localisedString;

    [FoldoutGroup("Search")]
    [VerticalGroup("Search/Vertical")]
    [OnValueChanged("GetSearchDictionary")]
    public string keyword;

    [VerticalGroup("Search/Vertical")]
    [DictionaryDrawerSettings, ReadOnly]
    public StringStringDictionary dictionary;

    private StringStringDictionary wholeDictionary;

    public void GetSearchDictionary()
    {
        var value = keyword.ToLower();
        if (value == "")
        {
            dictionary = wholeDictionary;
            return;
        }

        dictionary = new StringStringDictionary();

        foreach (KeyValuePair<string, string> element in wholeDictionary)
        {
            if (element.Key.ToLower().Contains(value.ToLower()) || element.Value.ToLower().Contains(value.ToLower()))
            {
                dictionary.Add(element.Key, element.Value);
            }
        }
        if (dictionary.Count == 0) dictionary = wholeDictionary;
    }

    [Button(ButtonSizes.Large,Name = "Add")]
    public void OpenAddWorddictDrawer()
    {

    }

    private void OnEnable()
    {
        wholeDictionary = LocalisationSystem.GetDictionaryForEditor();
        dictionary = wholeDictionary;
    }

    private void Start()
    {
        textField = GetComponent<TextMeshProUGUI>();
        string value = localisedString.value;
        textField.text = value;
    }

    private void OpenPopup(LocalisedString key)
    {

    }
}
