using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ExcelToJsonEditorWindow : EditorWindow
{
    private static readonly string SettingWindowTitle = "ExcelToJsonSettings";

    [MenuItem("DataBase/ExcelToJsonSettings")]

    public static void ShowWindow()
    {
        GetWindow(typeof(ExcelToJsonEditorWindow)).titleContent.text = SettingWindowTitle;
    }

    void OnGUI()
    {

    }
}
