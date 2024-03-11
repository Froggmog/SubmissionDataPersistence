using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using System;

public class UpdateInputField : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        TMP_InputField iF = GetComponent<TMP_InputField>();
        iF.onEndEdit.AddListener(PersistenceManager.Instance.UpdatePlayerName);
        iF.text = PersistenceManager.Instance.PlayerObj.PlayerName;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
