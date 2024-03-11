using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{
    [SerializeField]
    private string playerName = "";

    public string PlayerName { get => playerName; set => playerName = value; }

    public int PersonalHighscore
    {
        get => personalHighscore; set
        {
            personalHighscore = value;
        }
    }

 
    [SerializeField]
    private int personalHighscore = 0;
    
    public static int highscore = 0;
    
    public static string highScoreName = "";



}
