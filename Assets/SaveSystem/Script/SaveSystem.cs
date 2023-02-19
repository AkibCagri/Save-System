
// This code was written by Akýb Çaðrý Kürklü.

using UnityEngine;
using System.IO;
using System;

public static class SaveSystem

{
    public static string saveFileName = "Save File";
    public static string saveFilePath = "";
    static string pathResult => CombinePath();

    static string CombinePath()
    {
        string path = Path.Combine(Application.persistentDataPath, saveFilePath);
        string result = Path.Combine(path, saveFileName);
        return result;
    }

    static void CreateFolder()
    {
        if (Directory.Exists(pathResult) == false)
        {
            Directory.CreateDirectory(pathResult);
            Debug.Log("created");
        }
    }

    public static void SaveVariableData<T>(string key, T value)
    {
        CreateFolder();
        VariableData<T> variableData = new VariableData<T>();
        variableData.value = value;
        string data = JsonUtility.ToJson(variableData, true);
        File.WriteAllText(pathResult + "/" + key + ".json", data);
    }

    public static T LoadVariableData<T>(string key, T defaultValue)
    {
        string path = pathResult + "/" + key + ".json";
        if (File.Exists(path))
        {
            string data = File.ReadAllText(pathResult + "/" + key + ".json");
            VariableData<T> loadedVariableData = JsonUtility.FromJson<VariableData<T>>(data);
            return loadedVariableData.value;
        }
        else
        {
            Debug.Log("File not found");
            return defaultValue;
        }
    }

    public static void SaveClassData<T>(string key, T savedClass) where T : new()
    {
        CreateFolder();
        T classData = savedClass;
        string data = JsonUtility.ToJson(classData, true);
        File.WriteAllText(pathResult + "/" + key + ".json", data);
    }

    public static T LoadClassData<T>(string key)
    {
        string path = pathResult + "/" + key + ".json";
        if (File.Exists(path))
        {
            string data = File.ReadAllText(pathResult + "/" + key + ".json");
            T loadedClassData = JsonUtility.FromJson<T>(data);
            return loadedClassData;
        }
        else
        {
            Debug.Log("File not found");
            T result = (T)Convert.ChangeType(null, typeof(T));
            return result;
        }
    }

    public static void DeleteKey(string key)
    {
        if (File.Exists(pathResult + "/" + key + ".json"))
        {
            File.Delete(pathResult + "/" + key + ".json");
            Debug.Log(pathResult + "/" + key + ".json" + " deleted.");
        }
        else
        {
            Debug.Log(pathResult + "/" + key + ".json" + " not found.");
        }
    }

    public static void DeleteAllSaves()
    {
        if (Directory.Exists(pathResult))
        {
            Directory.Delete(pathResult);
            Debug.Log(pathResult + " deleted.");
        }
        else
        {
            Debug.Log(pathResult + " not found.");
        }
    }

    public static void SaveTransform(string key, Transform savedTransform)
    {
        Transform savedTransformParent = savedTransform.parent;
        savedTransform.parent = null;

        TransformValuesData myTransformValues = new TransformValuesData();
        myTransformValues.position = savedTransform.position;
        myTransformValues.rotation = savedTransform.rotation;
        myTransformValues.scale = savedTransform.localScale;

        savedTransform.parent = savedTransformParent;


        SaveClassData(key, myTransformValues);
    }

    public static void LoadTransform(string key, Transform targetTransfom)
    {
        TransformValuesData myTransformValues = LoadClassData<TransformValuesData>(key);
        if (myTransformValues == null)
        {
            return;
        }

        Transform targetTransfomParent = targetTransfom.parent;
        targetTransfom.parent = null;

        targetTransfom.position = myTransformValues.position;
        targetTransfom.rotation = myTransformValues.rotation;
        targetTransfom.localScale = myTransformValues.scale;

        targetTransfom.parent = targetTransfomParent;
    }


















}
