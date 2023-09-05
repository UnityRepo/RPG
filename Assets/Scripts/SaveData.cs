using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEngine.UI;

public class SaveData : MonoBehaviour
{
    public Data data = new Data();

    public Transform player;
    public GameObject PObject;

    public GameObject Screenx;
    public GameObject Screeny;

    public void SaveToJson()
    {
        if (SceneManager.GetActiveScene().name == "Chapter")
        {
            Player pScript = PObject.GetComponent<Player>();

            data.x = player.position.x;
            data.y = player.position.y;
            data.z = player.position.z;

            data.doneFirst = pScript.doneFirst;

            data.textCounter = pScript.textCounter;
        }
        else if (SceneManager.GetActiveScene().name == "Title")
        {
            string filePaths = Application.persistentDataPath + "/Data.json";
            string Data2 = System.IO.File.ReadAllText(filePaths);

            data = JsonUtility.FromJson<Data>(Data2);

            Screenx.GetComponent<InputField>();

            data.ScreenX = int.Parse(Screenx.GetComponent<InputField>().text);
            data.ScreenY = int.Parse(Screeny.GetComponent<InputField>().text);

            Debug.Log(data.ScreenX + "" + data.ScreenY);
        }
        string Data = JsonUtility.ToJson(data);
        string filePath = Application.persistentDataPath + "/Data.json";
        System.IO.File.WriteAllText(filePath, Data);
    }

    public void LoadFromJson()
    {

        string filePath = Application.persistentDataPath + "/Data.json";
        string Data = System.IO.File.ReadAllText(filePath);

        data = JsonUtility.FromJson<Data>(Data);

        player.position = new Vector3(data.x, data.y, data.z);

        if (SceneManager.GetActiveScene().name == "Chapter")
        {
            Player pScript = PObject.GetComponent<Player>();

            data.x = player.position.x;
            data.y = player.position.y;
            data.z = player.position.z;

            pScript.doneFirst = data.doneFirst;

            pScript.textCounter = data.textCounter;

            pScript.ScreenX = data.ScreenX;
            pScript.ScreenY = data.ScreenY;
        }
    }

    public void loadScreen()
    {
        if (!Screen.fullScreen)
        {
            Screen.SetResolution(data.ScreenX, data.ScreenY, true);
        }
        else
        {
            Screen.fullScreen = false;
            Screen.SetResolution(data.ScreenX, data.ScreenY, true);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F11))
        {
            if (!Screen.fullScreen)
            {
                Screen.SetResolution(data.ScreenX, data.ScreenY, true);
            }
            else
            {
                Screen.fullScreen = false;
            }
        }
    }

}

[System.Serializable]
public class Data
{
    public float x;
    public float y;
    public float z;

    public bool doneFirst;
    public int textCounter;

    public int ScreenX;
    public int ScreenY;
}