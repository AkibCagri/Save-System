
// This code was written by Akýb Çaðrý Kürklü.

using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField] string saveFileName = "Save File";
    [SerializeField] string saveFilePath = "";
    [SerializeField] DemoManager demoManager;

    private void Awake()
    {
        SaveSystem.saveFileName = saveFileName;
        SaveSystem.saveFilePath = saveFilePath;
    }

    // Int
    public void IntSaveButton()
    {
        SaveSystem.SaveVariableData<int>("int Value", demoManager.intValue);
    }

    public void IntLoadButton()
    {
        demoManager.intValue = SaveSystem.LoadVariableData<int>("int Value", 0);
        demoManager.SetIntText();
    }


    // Float
    public void FloatSaveButton()
    {
        SaveSystem.SaveVariableData<float>("float Value", demoManager.floatValue);
    }

    public void FloatLoadButton()
    {
        demoManager.floatValue = SaveSystem.LoadVariableData<float>("float Value", 0);
        demoManager.SetFloatText();
    }


    // String
    public void StringSaveButton()
    {
        SaveSystem.SaveVariableData<string>("string Value", demoManager.stringValue);
    }

    public void StringLoadButton()
    {
        demoManager.stringValue = SaveSystem.LoadVariableData<string>("string Value", "");
        demoManager.SetStringText();
    }


    // Vector3
    public void Vector3SaveButton()
    {
        SaveSystem.SaveVariableData<Vector3>("Vector3 Value", demoManager.vector3Value);
    }

    public void Vector3LoadButton()
    {
        demoManager.vector3Value = SaveSystem.LoadVariableData<Vector3>("Vector3 Value", Vector3.zero);
        demoManager.SetVector3Text();
    }


    // Int List
    public void IntListSaveButton()
    {
        SaveSystem.SaveVariableData<List<int>>("Int List Value", demoManager.intListValue);
    }

    public void IntListLoadButton()
    {
        demoManager.intListValue = SaveSystem.LoadVariableData<List<int>>("Int List Value", new List<int>());
        demoManager.SetIntListText();
    }


    // Transform
    public void TransformSaveButton()
    {
        SaveSystem.SaveTransform("Transform", demoManager.cubeTransform);
    }

    public void TransformLoadButton()
    {
        SaveSystem.LoadTransform("Transform", demoManager.cubeTransform);
    }
}
