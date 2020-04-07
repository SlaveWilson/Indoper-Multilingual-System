using UnityEditor;
using UnityEngine;

public class LocalisedStringDrawer : PropertyDrawer
{
    bool dropdown;
    float height;

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return height + 25;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
        position.width -= 34;
        position.height = 18;

        SerializedProperty key = property.FindPropertyRelative("key");
        key.stringValue = EditorGUI.TextField(position, key.stringValue);

        position.x += position.width + 2;
        position.width = 17;
        position.height = 17;

        Texture searchIcon = (Texture)Resources.Load("search");
        GUIContent searchContent = new GUIContent(searchIcon);

        if (GUI.Button(position, searchContent))
        {
            TextLocaliserSearchWindow.Open();
        }

        position.x += position.width + 2;

        Texture storeIcon = (Texture)Resources.Load("store");
        GUIContent storeContent = new GUIContent(storeIcon);

        if (GUI.Button(position, storeContent))
        {
            TextLocalisedEditWindow.Open(key.stringValue);
        }

        //position.x = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label).x;

        Rect valueRect = new Rect(position.x, position.y + 18, 100, position.height);

        var value = LocalisationSystem.GetLocalisedValue(key.stringValue);
        GUIStyle style = GUI.skin.box;
        height = style.CalcHeight(new GUIContent(value), valueRect.width);

        valueRect.height = height;
        valueRect.y += 21;
        EditorGUI.LabelField(valueRect, value, EditorStyles.wordWrappedLabel);

        //EditorGUI.PropertyField(valueRect, property.FindPropertyRelative("value"), GUIContent.none);
        

        EditorGUI.EndProperty();
    }
}
