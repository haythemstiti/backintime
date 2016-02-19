using UnityEngine;
using System.Collections;

public class ChangeScene : Photon.MonoBehaviour {

    public GameObject btn1, btn2, btn3, panel;

    void Start() 
    {
        PhotonNetwork.Disconnect();
        Time.timeScale = 1f;
        ScoreCounter.scoreChild = 0;
        ScoreCounter.scoreParent = 0;


        panel.SetActive(false);
        
       /* btn1.SetActive(false);
        btn2.SetActive(false);
        btn3.SetActive(false);
        panel.SetActive(true);
         */

    }
	public void changeToScene (string sceneToChangeTo) {
   
           Application.LoadLevel("TheAltarOfElders");

	}
    public void goTutorial() {
        Application.LoadLevel("Tutorial");
    }

    public void Quit() 
    {
        Application.Quit();
    }
    /*
    void Update()
    {
        if (BandValues.x != 0)
        {
            btn1.SetActive(true);
            btn2.SetActive(true);
            btn3.SetActive(true);
            panel.SetActive(false);
        }
    }
     */
    
}
