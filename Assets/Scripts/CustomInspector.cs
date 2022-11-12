
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(AssetSpawner))]

public class CustomInspector : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        AssetSpawner Spawner = (AssetSpawner)target;
     
        if (GUILayout.Button("Pass all Objects")) 
        {
            Spawner.AssignPrefabs();
        }
        if (GUILayout.Button("Generate"))
        {
            Spawner.SpawnObjects();
        }
    }
}
