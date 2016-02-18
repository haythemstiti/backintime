using UnityEngine;
using System.Collections;

public class ChangeScene : Photon.MonoBehaviour {



    void Start() 
    {
        PhotonNetwork.Disconnect();
        ScoreCounter.scoreChild = 0;
        ScoreCounter.scoreParent = 0;
    }
	public void changeToScene (string sceneToChangeTo) {
//if (BandValues.x != 0)
           Application.LoadLevel("TheAltarOfElders");

	}
    public void goTutorial() {
        Application.LoadLevel("Tutorial");
    }

    public void Quit() 
    {
        Application.Quit();
    }
}
