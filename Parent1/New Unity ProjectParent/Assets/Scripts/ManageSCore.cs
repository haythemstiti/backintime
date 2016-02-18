using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ManageSCore : Photon.MonoBehaviour {

	public Text textParent, textKid;
    private bool incremented;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void NextLevel()
    {
        Application.LoadLevel("BackInTime");
    }

    public void MainMenu() 
    {
        PhotonNetwork.Disconnect();
        Application.LoadLevel("menu2");
    }

}
