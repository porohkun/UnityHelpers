using System.Linq;
using UnityEditor;

public static class SwitchReleaseBuild
{
    private const string MenuName = "Tools/Release Build";
    private const string ReleaseDefineSymbol = "RELEASE_BUILD";

    public static bool IsEnabled
    {
        get
        {
            PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, out var symbols);
            return symbols.Contains(ReleaseDefineSymbol);
        }
        set
        {
            PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, out var symbols);
            if (symbols.Contains(ReleaseDefineSymbol))
                symbols = symbols.Except(ReleaseDefineSymbol).ToArray();
            else
                symbols = symbols.Union(ReleaseDefineSymbol).ToArray();
            PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, symbols);

        }
    }

    [MenuItem(MenuName)]
    private static void ToggleAction()
    {
        IsEnabled = !IsEnabled;
    }

    [MenuItem(MenuName, true)]
    private static bool ToggleActionValidate()
    {
        Menu.SetChecked(MenuName, IsEnabled);
        return true;
    }
}
