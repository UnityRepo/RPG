using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class SaveData : MonoBehaviour
{
    public Data data = new Data();

    public Transform player;
    public GameObject PObject;

    public void SaveToJson()
    {
        if (SceneManager.GetActiveScene().name == "Chapter")
        {
            Player pScript = PObject.GetComponent<Player>();

            data.x = player.position.x;
            data.y = player.position.y;
            data.z = player.position.z;
            data.doneFirst = pScript.doneFirst;
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
            //data.doneFirst = pScript.doneFirst;
            pScript.doneFirst = data.doneFirst;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F11))
        {
            Screen.fullScreen = !Screen.fullScreen;
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
}