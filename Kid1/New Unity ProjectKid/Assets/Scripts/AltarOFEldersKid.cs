using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class AltarOFEldersKid : MonoBehaviour {

    
    public Text roomText;
    public static string roomName;
    // Use this for initialization
    void Start()
    {

    }


    public void JoinRoom()
    {

        roomName = roomText.text;
        Application.LoadLevel("BackInTime");
    }
}
