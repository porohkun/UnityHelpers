using UnityEditor;

[CustomEditor(typeof(DontDestroyOnLoad))]
[CanEditMultipleObjects]
public class DontDestroyOnLoadEditor : Editor
{
    public override void OnInspectorGUI() { }
}