using UnityEngine;
using UnityEditor;

public class TextLocalisedEditWindow : EditorWindow
{
    public static void Open(string key)
    {
        TextLocalisedEditWindow window = CreateInstance<TextLocalisedEditWindow>();
        window.titleContent = new GUIContent("Localiser Window");
        window.ShowUtility();
        window.key = key;
        window.language = LocalisationSystem.language;
        window.value = LocalisationSystem.GetLocalisedValue(key);
    }

    public string key;
    public LocalisationSystem.Language language;
    public string value;

    public void OnGUI()
    {
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Language : " + language.ToString());
        EditorGUILayout.EndHorizontal();

        key = EditorGUILayout.TextField("Key :", key);
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Value:", GUILayout.MaxWidth(50));

        EditorStyles.textArea.wordWrap = true;
        value = EditorGUILayout.TextArea(value, EditorStyles.textArea, GUILayout.Height(100), GUILayout.Width(400));
        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Add"))
        {
            if(LocalisationSystem.GetLocalisedValue(key) != string.Empty)
            {
                LocalisationSystem.Replace(key, value);
            }
            else
            {
                LocalisationSystem.Add(key, value);
            }
        }

        minSize = new Vector2(460, 250);
        maxSize = minSize;
    }
}
