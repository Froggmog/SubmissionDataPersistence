using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using System;

public class UpdateInputField : MonoBehaviour
{

    private MenuUIHandler menuHandler;

    public TMP_InputField playerNameIF;
    public TMP_Text personalHighscoreTF;
    public TMP_Text overallHighscoreTF;
    // Start is called before the first frame update
    void Start()
    {
        menuHandler = GameObject.Find("MenuUIHandler").GetComponent<MenuUIHandler>();
        playerNameIF.onDeselect.AddListener(menuHandler.UpdateNameInputField);
        playerNameIF.text = PersistenceManager.Instance.PlayerObj.PlayerName;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
