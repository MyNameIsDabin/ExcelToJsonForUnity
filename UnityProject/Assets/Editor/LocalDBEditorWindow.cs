using System.Diagnostics;
using UnityEditor;
using UnityEngine;

public class LocalDBEditorWindow : EditorWindow
{
    private const string SettingWindowTitle = "ExcelToJsonSettings";
    private const string EdtiorSettingDir = "Assets/LocalDB";
    private const string EditorSettingResDir = "Assets/LocalDB/Resources";
    private const string EditorSettingFile = "Assets/LocalDB/Resources/LocalDBSettings.asset";

    public static LocalDBSettings settings;

    [MenuItem("LocalDB/데이터 시트(JSON) 다운로드")]
    public static void LoadGoogleSpreadSheet()
    {
        string toolPath = Application.dataPath + @"/ExternalTools/GoogleSpreadSheetToJson/app.js";
        RunNodeScript(toolPath, "gss --json true");
    }

    [MenuItem("LocalDB/언어 시트(CSV) 다운로드")]
    public static void LoadGoogleSpreadSheetLanguages()
    {
        string toolPath = Application.dataPath + @"/ExternalTools/GoogleSpreadSheetToJson/app.js";
        RunNodeScript(toolPath, "gss --csv true");
    }

    public static void RunNodeScript(string toolPath, string arguments)
    {
        Process p = new Process();
        p.StartInfo.CreateNoWindow = false;
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.RedirectStandardOutput = true;
        p.StartInfo.RedirectStandardError = true;
        p.StartInfo.RedirectStandardInput = true;
        p.StartInfo.FileName = "node";
        p.StartInfo.Arguments = toolPath + " " + arguments;
        p.Start();
    }

    [MenuItem("LocalDB/설정")]

    public static void ShowWindow()
    {
        GetWindow(typeof(LocalDBEditorWindow)).titleContent.text = SettingWindowTitle;

        if (!AssetDatabase.IsValidFolder(EditorSettingResDir))
            AssetDatabase.CreateFolder(EdtiorSettingDir, "Resources");

        LoadSettings();
    }

    private void OnGUI()
    {
        // TODO..

        //GUILayout.Label("Excel Path");

        //settings.ExcelPath = EditorGUILayout.TextField("Text Field", settings.ExcelPath);
    }

    private void OnDestroy()
    {
        SaveSettings();
    }

    public static void SaveSettings()
    {
        if (settings == null)
        {
            settings = CreateInstance<LocalDBSettings>();
            AssetDatabase.CreateAsset(settings, EditorSettingFile);
        }

        AssetDatabase.SaveAssets();
        EditorUtility.SetDirty(settings);
    }

    public static void LoadSettings()
    {
        var instance = AssetDatabase.LoadAssetAtPath(EditorSettingFile, typeof(LocalDBSettings)) as LocalDBSettings;
        if (instance == null)
            SaveSettings();
        else
            settings = instance;
    }
}
