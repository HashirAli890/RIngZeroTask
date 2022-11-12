
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class SpwanerObjectProperties 
{
    public string Name = "ItemObject";
    public string FolderPath;
    public Transform SpawnPosition;
    public List<GameObject> Prefabs = new List<GameObject>();
    public GameObject SpawnedObject;

    public void AssignPrefabsFromPath() 
    {
        string[] aFilePaths = Directory.GetFiles(FolderPath);

        foreach (string sFilePath in aFilePaths)
        {
            if (Path.GetExtension(sFilePath) == ".prefab")
            {
                Debug.Log(Path.GetExtension(sFilePath));

                GameObject objAsset = AssetDatabase.LoadAssetAtPath(sFilePath, typeof(Object)) as GameObject;
                Prefabs.Add(objAsset);
            }
        }
    }
}

public class AssetSpawner : MonoBehaviour
{
    public List<SpwanerObjectProperties> Properties;
    public Transform ParentObject;

    public void AssignPrefabs() 
    {
        for (int  i=0;i< Properties.Count;i++ )
        {
            Properties[i].Prefabs.Clear();
            Properties[i].AssignPrefabsFromPath(); 
        }
    }
   
    public void SpawnObjects() 
    {
        if (!ParentObject)
              ParentObject = new GameObject().transform;
        for (int i=0;i< Properties.Count;i++) 
        {
            if (Properties[i].SpawnedObject)
                DestroyImmediate(Properties[i].SpawnedObject);
            int SpawnObjectIndex = Random.Range(0, Properties[i].Prefabs.Count);
            Properties[i].SpawnedObject =  Instantiate(Properties[i].Prefabs[SpawnObjectIndex], Properties[i].SpawnPosition.position, Properties[i].SpawnPosition.rotation);
            Properties[i].SpawnedObject.name = Properties[i].Name;
            Properties[i].SpawnedObject.transform.SetParent(ParentObject);
        }
    }


    
}
