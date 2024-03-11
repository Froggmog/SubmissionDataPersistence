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
    
    [System.Serializable]
    class Highscore{
        public int highscore = 0;
        public string highscoreName = "Dummy";
    }

    Highscore highscore;

    

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
        Application.quitting += SaveHighscore;
        LoadPlayerName();
        LoadHighscore();  
           
    }

    void SavePlayerName()
    {
        if (!Directory.Exists(Application.persistentDataPath + "/SaveData")) Directory.CreateDirectory(Application.persistentDataPath + "/SaveData");

        string path = Application.persistentDataPath + "/SaveData/Playername.json";

        string data = JsonUtility.ToJson(playerObj);
        File.WriteAllText(path, data);
    }

    void SaveHighscore()
    {
        if (!Directory.Exists(Application.persistentDataPath + "/SaveData")) Directory.CreateDirectory(Application.persistentDataPath + "/SaveData");

        string path = Application.persistentDataPath + "/SaveData/highscore.json";

        string data = JsonUtility.ToJson(highscore);
        File.WriteAllText(path, data);
    }

    public void LoadHighscore()
    {

        string path = Application.persistentDataPath + "/SaveData/highscore.json";
        if (File.Exists(path))
        {
            string data = File.ReadAllText(path);
            highscore = JsonUtility.FromJson<Highscore>(data);
            if (highscore.highscore > Player.highscore){
                Player.highScoreName = highscore.highscoreName;
                Player.highscore = highscore.highscore;
            }
            return;
        }
        highscore = new Highscore();
    }

    public void LoadPlayerName()
    {

        string path = Application.persistentDataPath + "/SaveData/Playername.json";
        if (File.Exists(path))
        {
            string data = File.ReadAllText(path);
            PlayerObj = JsonUtility.FromJson<Player>(data);
            return;
        }
        playerObj = new Player();
    }

    public void UpdateHighscore(){
        highscore.highscore = Player.highscore;
        highscore.highscoreName = Player.highScoreName;
        SaveHighscore();
    }
}
