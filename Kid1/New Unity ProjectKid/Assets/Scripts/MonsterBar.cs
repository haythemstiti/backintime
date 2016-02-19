using UnityEngine;
using System.Collections;

public class MonsterBar : MonoBehaviour {

    private GameObject monsterBar;
    public static EnergyBar eb;
    public static bool activateMonsterBar;
    public static string monsterType;
    
	void Start () {
        monsterBar = GameObject.Find("MonsterBar");
        eb = monsterBar.GetComponent<EnergyBar>();
        monsterBar.SetActive(false);


	}
	
	
	void Update () {
        if (activateMonsterBar)
        {
            monsterBar.SetActive(true);

        }
        else {
            

            switch (monsterType)
            {
                case "Pyro": eb.valueCurrent = 8; break;
                case "Freezer": eb.valueCurrent = 8; break;
                case "Electronite": eb.valueCurrent = 8; break;
                default: eb.valueCurrent = 8; break;
            }

            
        }
	}
   /* void OnGUI()
    {

        GUI.TextField(new Rect(200, 200, 200, 200), "activated: " + activateMonsterBar);

    }*/
}
