using UnityEngine;
using UnityEditor;

public class DeletePlayerPrefsScript : EditorWindow
{
    [MenuItem("Window/Delete PlayerPrefs (All)")]
    static void DeleteAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("All player Preferences Deleted!");
    }
}