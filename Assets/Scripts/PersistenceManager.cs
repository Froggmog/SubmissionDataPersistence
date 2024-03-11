using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using TMPro;
using UnityEditor.Experimental.GraphView;

public class PersistenceManager : MonoBehaviour
{

    private static PersistenceManager instance;

    public static PersistenceManager Instance { get => instance; set => instance = value; }
    public Player PlayerObj { get => playerObj; set => playerObj = value; }

    private Player playerObj;

    [SerializeField] private TMP_InputField playerInputField;



    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

#if UNITY_EDITOR
        EditorApplication.quitting += SavePlayerName;
        Application.quitting += SavePlayerName;
#else
        Application.quitting += SavePlayerName;
#endif
        LoadPlayerName();

    }

    public void UpdatePlayerName(string value)
    {
        playerObj.PlayerName = value;
    }

    void SavePlayerName()
    {
        if (!Directory.Exists(Application.persistentDataPath + "/SaveData")) Directory.CreateDirectory(Application.persistentDataPath + "/SaveData");

        string path = Application.persistentDataPath + "/SaveData/Playername.json";

        string data = JsonUtility.ToJson(playerObj);
        File.WriteAllText(path, data);
    }

    public void LoadPlayerName()
    {



        if (playerObj == null)
        {
            string path = Application.persistentDataPath + "/SaveData/Playername.json";
            if (File.Exists(path))
            {
                string data = File.ReadAllText(path);
                playerObj = JsonUtility.FromJson<Player>(data);
                playerInputField.text = playerObj.PlayerName;
                return;
            } else {
                playerObj = new Player();
            }
            
        }

    }




}
