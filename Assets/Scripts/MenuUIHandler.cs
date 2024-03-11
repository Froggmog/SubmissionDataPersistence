using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class MenuUIHandler : MonoBehaviour
{

    [SerializeField]
    private TMP_Text personalHighscore;
    [SerializeField]
    private TMP_Text overallHighscore;

    // Start is called before the first frame update
    void Awake()
    {
        
        SceneManager.sceneLoaded += OnSceneLoaded;
        //SceneManager.sceneUnloaded += OnSceneUnloaded;
        
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateUI();
    }

     void OnSceneUnloaded(Scene current)
    {
       //SceneManager.sceneLoaded -= OnSceneLoaded;
        //SceneManager.sceneUnloaded -= OnSceneUnloaded;

    }

    public void StartGame()
    {
        SceneManager.LoadScene("main");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("menu");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
        
    }

    public void UpdateNameInputField(string value){
            PersistenceManager.Instance.PlayerObj = new Player();
            PersistenceManager.Instance.PlayerObj.PlayerName = value;
            

    }

    public void UpdateUI(){
        
        personalHighscore.text = "Personal Highscore: " + PersistenceManager.Instance.PlayerObj.PersonalHighscore;
        overallHighscore.text = "Overall Highscore: " + Player.highscore + " by " + Player.highScoreName;
    }
}
