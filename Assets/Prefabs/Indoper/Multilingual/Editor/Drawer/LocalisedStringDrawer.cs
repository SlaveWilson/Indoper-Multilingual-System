using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(LocalisedString))]
public class LocalisedStringDrawer : PropertyDrawer
{
    bool dropdown;

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        int lineCount = 3;
        return EditorGUIUtility.singleLineHeight * lineCount + EditorGUIUtility.standardVerticalSpacing * (lineCount - 1);
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        string key = property.FindPropertyRelative("key").stringValue;
        string value = LocalisationSystem.GetLocalisedValue(key);

        Rect rect = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        rect.width -= 40;
        rect.height = 18;

        key = EditorGUI.TextField(rect, key);

        rect.x += rect.width + 2;
        rect.width = 18;

        Texture searchIcon = (Texture)Resources.Load("search");
        GUIContent searchContent = new GUIContent(searchIcon);

        if (GUI.Button(rect, searchContent))
        {
            TextLocaliserSearchWindow.Open();
        }

        rect.x += rect.width + 2;

        Texture storeIcon = (Texture)Resources.Load("store");
        GUIContent storeContent = new GUIContent(storeIcon);

        if (GUI.Button(rect, storeContent))
        {
            TextLocalisedEditWindow.Open(key);
        }

        rect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight, EditorGUIUtility.currentViewWidth, EditorGUIUtility.singleLineHeight);
        EditorGUI.LabelField(rect, "Current Language", LocalisationSystem.language.ToString());
        
        rect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight * 2, EditorGUIUtility.currentViewWidth, EditorGUIUtility.singleLineHeight);
        EditorGUI.LabelField(rect, "Value", value);


        EditorGUI.EndProperty();
    }
}
