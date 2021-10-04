#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

public class ShortcutsWindow : EditorWindow
{
    private static (string, string)[] _folders = new (string, string)[]
    {
        ("Units", "Assets/Prefabs/Units"),
        ("Levels", "Assets/Scenes/Levels"),
        ("Settings", "Assets/Settings"),
        ("Prefabs", "Assets/Prefabs"),
        ("Animations", "Assets/Animations"),
        ("Textures", "Assets/Textures"),
        ("Materials", "Assets/Materials"),
        ("Characters Models", "Assets/Models/Characters"),
    };

    private static MethodInfo _getInstanceIDMethod;

    static ShortcutsWindow()
    {
        _getInstanceIDMethod = typeof(AssetDatabase).GetMethod("GetMainAssetInstanceID",
            BindingFlags.Static | BindingFlags.NonPublic);
    }

    private ReorderableList _levelsList;
    private List<Shortcut> _shortcuts = new List<Shortcut>();

    [MenuItem("Window/Shortcuts")]
    public static void ShowWindow()
    {
        var win = EditorWindow.GetWindow(typeof(ShortcutsWindow), false, "Shortcuts");
        win.minSize = new Vector2(100, 22);
        win.maxSize = new Vector2(1000, 22);
    }

    public void OnEnable()
    {
        LoadList();
        _levelsList = new ReorderableList(_shortcuts, typeof(string), true, true, true, true);
        _levelsList.drawHeaderCallback = DrawLevelsHeader;
        _levelsList.drawElementCallback = DrawListElement;
        _levelsList.onAddCallback = AddToList;
        _levelsList.onRemoveCallback = SaveList;
        _levelsList.onReorderCallback = SaveList;
    }

    void DrawLevelsHeader(Rect rect)
    {
        EditorGUI.LabelField(new Rect(rect.x, rect.y, rect.width - rect.height, rect.height), "Shortcuts");
    }

    void DrawListElement(Rect rect, int index, bool isActive, bool isFocused)
    {
        if (index >= _levelsList.list.Count)
            return;
        var shortcut = (Shortcut)_levelsList.list[index];
        shortcut.Name = EditorGUI.TextArea(new Rect(rect.x, rect.y, 80, rect.height - 2), shortcut.Name);
        shortcut.Path = EditorGUI.TextArea(new Rect(rect.x + 84, rect.y, rect.width - 82, rect.height - 2), shortcut.Path);
        if (shortcut.Edited)
            shortcut.Save();
    }

    private void AddToList(ReorderableList _)
    {

        var shortcut = new Shortcut();
        _shortcuts.Add(shortcut);
        SaveList(_);
        shortcut.Save();
    }

    private void LoadList()
    {
        var shortcuts = EditorPrefs.GetString("shortcuts").Split(';');
        _shortcuts.Clear();
        _shortcuts.AddRange(shortcuts.Where(s => s != "").Select(s => new Shortcut(s)));
    }

    private void SaveList(ReorderableList _)
    {
        var shortcuts = string.Join(";", _shortcuts.Select(s => s.Id));
        EditorPrefs.SetString("shortcuts", shortcuts);
    }

    void OnGUI()
    {
        using (var helper = EditorGUILayoutHelper.Horizontal(out var rect))
            foreach (var entry in _shortcuts)
                if (GUILayout.Button(entry.Name))
                    ShowFolderContents((int)_getInstanceIDMethod.Invoke(null, new object[] { System.IO.Path.Combine("Assets", entry.Path) }));

        _levelsList.DoLayoutList();
    }

    public class Shortcut
    {
        public string Id { get; private set; }
        public bool Edited { get; private set; }
        public string Name
        {
            get => _name;
            set
            {
                if (value != _name)
                {
                    _name = value;
                    Edited = true;
                }
            }
        }
        public string Path
        {
            get => _path;
            set
            {
                if (value != _path)
                {
                    _path = value;
                    Edited = true;
                }
            }
        }

        private string _name = "Assets";
        private string _path = "";

        public Shortcut(string id = null)
        {
            if (id == null)
                do
                    Id = $"shortcut_{Random.Range(0, int.MaxValue)}";
                while (EditorPrefs.HasKey(Id));
            else
            {
                Id = id;
                Load();
            }
        }

        public void Load()
        {
            var shortc = EditorPrefs.GetString(Id).Split(';');
            if (shortc.Length == 2)
            {
                _name = shortc[0];
                _path = shortc[1];
            }
            else
            {
                _name = "Assets";
                _path = "";
            }
            Edited = false;
        }

        public void Save()
        {
            EditorPrefs.SetString(Id, $"{Name};{Path}");
            Edited = false;
        }
    }


    //https://forum.unity.com/threads/tutorial-how-to-to-show-specific-folder-content-in-the-project-window-via-editor-scripting.508247/
    #region Show Folder Content

    /// <summary>
    /// Selects a folder in the project window and shows its content.
    /// Opens a new project window, if none is open yet.
    /// </summary>
    /// <param name="folderInstanceID">The instance of the folder asset to open.</param>
    private static void ShowFolderContents(int folderInstanceID)
    {
        // Find the internal ProjectBrowser class in the editor assembly.
        Assembly editorAssembly = typeof(Editor).Assembly;
        System.Type projectBrowserType = editorAssembly.GetType("UnityEditor.ProjectBrowser");

        // This is the internal method, which performs the desired action.
        // Should only be called if the project window is in two column mode.
        MethodInfo showFolderContents = projectBrowserType.GetMethod(
            "ShowFolderContents", BindingFlags.Instance | BindingFlags.NonPublic);

        // Find any open project browser windows.
        Object[] projectBrowserInstances = Resources.FindObjectsOfTypeAll(projectBrowserType);

        if (projectBrowserInstances.Length > 0)
        {
            for (int i = 0; i < projectBrowserInstances.Length; i++)
                ShowFolderContentsInternal(projectBrowserInstances[i], showFolderContents, folderInstanceID);
        }
        else
        {
            EditorWindow projectBrowser = OpenNewProjectBrowser(projectBrowserType);
            ShowFolderContentsInternal(projectBrowser, showFolderContents, folderInstanceID);
        }
    }

    private static void ShowFolderContentsInternal(Object projectBrowser, MethodInfo showFolderContents, int folderInstanceID)
    {
        // Sadly, there is no method to check for the view mode.
        // We can use the serialized object to find the private property.
        SerializedObject serializedObject = new SerializedObject(projectBrowser);
        bool inTwoColumnMode = serializedObject.FindProperty("m_ViewMode").enumValueIndex == 1;

        if (!inTwoColumnMode)
        {
            // If the browser is not in two column mode, we must set it to show the folder contents.
            MethodInfo setTwoColumns = projectBrowser.GetType().GetMethod(
                "SetTwoColumns", BindingFlags.Instance | BindingFlags.NonPublic);
            setTwoColumns.Invoke(projectBrowser, null);
        }

        bool revealAndFrameInFolderTree = true;
        showFolderContents.Invoke(projectBrowser, new object[] { folderInstanceID, revealAndFrameInFolderTree });
    }

    private static EditorWindow OpenNewProjectBrowser(System.Type projectBrowserType)
    {
        EditorWindow projectBrowser = EditorWindow.GetWindow(projectBrowserType);
        projectBrowser.Show();

        // Unity does some special initialization logic, which we must call,
        // before we can use the ShowFolderContents method (else we get a NullReferenceException).
        MethodInfo init = projectBrowserType.GetMethod("Init", BindingFlags.Instance | BindingFlags.Public);
        init.Invoke(projectBrowser, null);

        return projectBrowser;
    }
    #endregion
}
#endif