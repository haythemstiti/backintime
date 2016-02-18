using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using System.Collections;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using UnityEngine.UI;

public class AltarOfEldersParent : MonoBehaviour {


    public Text roomText;
    public static string roomName;
	// Use this for initialization
	void Start () {
        
        
	}

   


    public void CreateRoom()
    {
        roomName = roomText.text;
        Application.LoadLevel("BackInTime");
    }
}
