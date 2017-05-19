using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;

public class SublimeSync : EditorWindow
{
    static string sublime_location = @"C:\Program Files\Sublime Text 3\sublime_text.exe";
    string prj_name;
    string prj_path = "";
    bool prj_exists;
    static string file_exclude_patterns = "*.unity,*.guiskin,*.dll,*.meta ,*.prefab ,*.anim, *.physicMaterial, *.flare , *.cubemap , *.font , *.fontsettings , *.renderTexture, *.mat";
    bool showFileExcludes = true;

    static string folder_exclude_patterns = "None";
    bool showFolderExcludes = true;

    [MenuItem("Sublime Text 3/Create Sublime-Project")]
    public static void CreateSublimePrj()
    {
        EditorWindow.GetWindow<SublimeSync>(true, "Sublime-Project Generator", true);
    }

    [MenuItem("Sublime Text 3/Open Sublime-Project")]
    public static void OpenSublimePrj()
    {
        string[] subprj = FindSublimeProjects();
        if (subprj != null)
        {
            string path = @subprj[0];
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
            psi.FileName = sublime_location;
            psi.Arguments = "\"" + path + "\""; // escape the quotes
            System.Diagnostics.Process.Start(psi);
        }
    }

    public void OnFocus()
    {
        minSize = new Vector2(350, 415);
    }

    public void OnEnable()
    {
        prj_name = GetProjectName();
        prj_exists = FindSublimeProjects() != null;
    }

    public void OnGUI()
    {
        if (prj_name == "")
            prj_name = GetProjectName();

        GUILayout.Label("Unity Sublime-Project Generator", EditorStyles.boldLabel);

        GUILayout.Space(4);

        if (prj_exists)
            EditorGUILayout.HelpBox("Sublime-Project Found!  Creating a new project will overwrite the old project.", MessageType.Warning);

        GUILayout.Label("Location of sublime_text.exe:");
        sublime_location = EditorGUILayout.TextField("", sublime_location);

        prj_name = EditorGUILayout.TextField("Project Name:", prj_name);

        prj_path = EditorGUILayout.TextField("Project Path:" + Indent(2) + "Assets/", prj_path);

        EditorStyles.textField.wordWrap = true;

        showFileExcludes = EditorGUILayout.Foldout(showFileExcludes, "File types to exclude. Seperate by comma:");
        if (showFileExcludes)
            file_exclude_patterns = EditorGUILayout.TextArea(file_exclude_patterns, GUILayout.MinHeight(100), GUILayout.MaxHeight(100));

        GUILayout.Space(4);

        showFolderExcludes = EditorGUILayout.Foldout(showFolderExcludes, "Folders to exclude. Seperate by comma:");
        if (showFolderExcludes)
            folder_exclude_patterns = EditorGUILayout.TextArea(folder_exclude_patterns, GUILayout.MinHeight(100), GUILayout.MaxHeight(100));

        GUI.backgroundColor = Color.green;
        if (GUILayout.Button("Create Project"))
        {
            if (CreateSublimeProject(prj_name, "Assets/" + prj_path))
            {
                if (EditorUtility.DisplayDialog("Sublime-Project Created!", "Sublime-Project successfully created.  Open now?", "Yes", "No"))
                    OpenSublimePrj();
                else
                    Close();
            }
        }
        GUI.backgroundColor = Color.white;

    }

    public static bool CreateSublimeProject(string prj_name, string code_path)
    {
        RemoveOldSublimeProjects();

        prj_name = prj_name.Replace("/", "\\\\");

        string exclude_files = "";
        string[] files = file_exclude_patterns.Trim().Split(',');
        for (int i = 0; i < files.Length; i++)
        {
            exclude_files += "\"" + files[i].Trim() + "\"";
            if (i != files.Length - 1)
                exclude_files += ", ";
        }

        if (folder_exclude_patterns == "" || folder_exclude_patterns == " ")
        {
            folder_exclude_patterns = "None";
        }

        string exclude_folders = "";

        files = folder_exclude_patterns.Trim().Split(',');
        for (int i = 0; i < files.Length; i++)
        {
            exclude_folders += "\"" + files[i].Trim() + "\"";
            if (i != files.Length - 1)
                exclude_folders += ", ";
        }

        /*begin prj text*/
        string project_contents =
            "{\n" + Indent(1) + "\"folders\":\n" + Indent(1) + "[\n" + Indent(2) + "{\n" + Indent(3) + "\"follow_symlinks\": " + "true" + ",\n\n" + Indent(3) + "\"path\": \"./" + code_path + "\",\n\n" + Indent(3) + "\"file_exclude_patterns\":\n" + Indent(3) + "[\n" + Indent(4) + exclude_files + "\n" + Indent(3) + "],\n\n" + Indent(3) + "\"folder_exclude_patterns\":\n" + Indent(3) + "[\n" + Indent(4) + exclude_folders + "\n" + Indent(3) + "],\n" + Indent(2) + "}\n" + Indent(1) + "],\n\n" + Indent(1) + "\"solution_file\": \"./" + GetProjectName() + ".sln\"\n}";

        // place in main project folder
        string path = Directory.GetParent(Application.dataPath).ToString();

        path += "/" + prj_name + ".sublime-project";

        if (File.Exists(path))
            File.Delete(path);
            

        TextWriter tw = new StreamWriter(path);
        tw.WriteLine(project_contents);
        tw.Close();

        return true;
    }

    public static string[] FindSublimeProjects()
    {
        string prj = Directory.GetParent(Application.dataPath).ToString();
        string[] fileEntries = Directory.GetFiles(prj);
        string PicturePath;
        string[] allSublimeProjects = new string[5];

        foreach (string fileName in fileEntries)
        {
            FileInfo fi = new FileInfo(fileName);
            if (fi.Name.ToString().EndsWith(".sublime-project"))
            {
                PicturePath = fileName.Replace(@"\", "/");
                allSublimeProjects.SetValue(PicturePath, 0);
            }
        }

        return allSublimeProjects;

        // string[] allSublimeProjects = System.Array.FindAll(allFiles, name => name.EndsWith(".sublime-project"));
        // string[] allFiles = System.IO.Directory.GetFiles(prj, "*.*", System.IO.SearchOption.AllDirectories);
    }

    public static void RemoveOldSublimeProjects()
    {
        string[] projects = FindSublimeProjects();

        foreach (string dankMeme in projects)
        {
            if (dankMeme != "" && dankMeme != null)
                File.Delete(dankMeme);
        }
    }

    public static string GetProjectName()
    {
        string[] split = Application.dataPath.Split("/"[0]);
        return split[split.Length - 2];
    }

    public static string Indent(int count)
    {
        return "".PadLeft(count * 4);
    }
}