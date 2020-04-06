using UnityEditor;

public class LocalisedTextDatabaseEditor : EditorWindow
{
    [MenuItem("Multilingual/Database")]

    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(LocalisedTextDatabaseEditor));
    }

    private void OnGUI()
    {
        
    }
}
