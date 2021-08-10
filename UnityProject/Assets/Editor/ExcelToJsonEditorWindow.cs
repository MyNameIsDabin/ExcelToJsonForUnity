using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ExcelToJsonEditorWindow : EditorWindow
{
    private const string SettingWindowTitle = "ExcelToJsonSettings";
    private const string EdtiorSettingDir = "Assets/ExcelToJson";
    private const string EditorSettingResDir = "Assets/ExcelToJson/Resources";
    private const string EditorSettingFile = "Assets/ExcelToJson/Resources/ExcelToJsonSettings.asset";

    public static ExcelToJsonSettings settings;

    [MenuItem("DataBase/ExcelToJsonSettings")]

    public static void ShowWindow()
    {
        GetWindow(typeof(ExcelToJsonEditorWindow)).titleContent.text = SettingWindowTitle;

        if (!AssetDatabase.IsValidFolder(EditorSettingResDir))
            AssetDatabase.CreateFolder(EdtiorSettingDir, "Resources");

        LoadSettings();
    }

    private void OnGUI()
    {
        GUILayout.Label("Excel Path");

        settings.ExcelPath = EditorGUILayout.TextField("Text Field", settings.ExcelPath);
    }

    private void OnDestroy()
    {
        SaveSettings();
    }

    public static void SaveSettings()
    {
        var instance = CreateInstance<ExcelToJsonSettings>();
        AssetDatabase.CreateAsset(instance, EditorSettingFile);
        AssetDatabase.SaveAssets();
    }

    public static void LoadSettings()
    {
        if (AssetDatabase.LoadAssetAtPath(EditorSettingFile, typeof(ExcelToJsonSettings)) == null)
            SaveSettings();
    }
}
