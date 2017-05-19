using UnityEngine;
using UnityEditor;

public class DialogScriptableObject {
    [MenuItem("Assets/Create/Dialog")]
    public static void CreateAsset() {
        ScriptableObjectUtils.CreateAsset<DialogBase>();
    }
}