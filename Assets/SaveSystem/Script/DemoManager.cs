
// This code was written by Akýb Çaðrý Kürklü.

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DemoManager : MonoBehaviour
{
    // Integer
    [HideInInspector] public int intValue;
    [SerializeField] Text intText;

    // Float
    [HideInInspector] public float floatValue;
    [SerializeField] Text floatText;

    // String
    [HideInInspector] public string stringValue;
    [SerializeField] InputField stringFiled;
    [SerializeField] Text stringText;

    // Vector3
    [HideInInspector] public Vector3 vector3Value;
    [SerializeField] Text vector3XText;
    [SerializeField] Text vector3YText;
    [SerializeField] Text vector3ZText;

    // Int List
    [HideInInspector] public List<int> intListValue = new List<int>();
    int newInt;
    [SerializeField] Text intListText;
    [SerializeField] Text newIntText;

    // Transform
    public Transform cubeTransform;
    [SerializeField] float speed;

    void Update()
    {
        TransformMovement();
    }


    // Int
    public void IntAddButton()
    {
        intValue++;
        SetIntText();
    }

    public void IntSubtractButton()
    {
        intValue--;
        SetIntText();
    }

    public void SetIntText()
    {
        intText.text = intValue.ToString();
    }


    // Float
    public void FloatAddButton()
    {
        floatValue += .1f;
        SetFloatText();
    }

    public void FloatSubtractButton()
    {
        floatValue -= .1f;
        SetFloatText();
    }

    public void SetFloatText()
    {
        floatText.text = floatValue.ToString();
    }


    // String
    public void StringEnterButton()
    {
        stringValue = stringFiled.text;
        SetStringText();
    }

    public void SetStringText()
    {
        stringText.text = stringValue;
    }


    // Vector3
    public void Vector3XAddButton()
    {
        vector3Value.x++;
        SetVector3Text();
    }

    public void Vector3XSubtractButton()
    {
        vector3Value.x--;
        SetVector3Text();
    }

    public void Vector3YAddButton()
    {
        vector3Value.y++;
        SetVector3Text();
    }

    public void Vector3YSubtractButton()
    {
        vector3Value.y--;
        SetVector3Text();
    }

    public void Vector3ZAddButton()
    {
        vector3Value.z++;
        SetVector3Text();
    }

    public void Vector3ZSubtractButton()
    {
        vector3Value.z--;
        SetVector3Text();
    }

    public void SetVector3Text()
    {
        vector3XText.text = vector3Value.x.ToString();
        vector3YText.text = vector3Value.y.ToString();
        vector3ZText.text = vector3Value.z.ToString();
    }

    // Int List
    public void IntListAddButton()
    {
        newInt++;
        SetNewIntText();
    }

    public void IntListSubtractButton()
    {
        newInt--;
        SetNewIntText();
    }

    void SetNewIntText()
    {
        newIntText.text = newInt.ToString();
    }

    public void IntListEnterButton()
    {
        intListValue.Add(newInt);

        SetIntListText();
    }

    public void SetIntListText()
    {
        string listString = "";

        foreach (int i in intListValue)
        {
            listString += i.ToString() + "|";
        }

        intListText.text = listString;
    }


    // Transform
    void TransformMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            cubeTransform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.S))
        {
            cubeTransform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.A))
        {
            cubeTransform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.D))
        {
            cubeTransform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            cubeTransform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.E))
        {
            cubeTransform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.R))
        {
            cubeTransform.Rotate(Vector3.one * speed * 5 * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.F))
        {
            cubeTransform.localScale += Vector3.right * speed * Time.deltaTime;
        }
    }

    // Restart

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}