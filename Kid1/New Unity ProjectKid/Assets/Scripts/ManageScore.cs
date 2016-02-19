using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ManageScore : MonoBehaviour {

    public Text textParent, textKid;
	// Use this for initialization
	void Start () {
        textKid.text = "" + PlayerPrefs.GetInt("ChildScore");
        textParent.text = "" + PlayerPrefs.GetInt("ParentScore");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void NextLevel()
    {
        
        Application.LoadLevel("BackInTime");
    }
}
