using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {

    public static int scoreParent;
    public static int scoreChild;
    public Text textParent, textChild;
    private GameObject btnNextRound;
    void Start()
    {
        btnNextRound = GameObject.Find("btnNextRound");
    }

    void Update()
    {
        if (LifePlayer.GameWon)
        {
            LifePlayer.GameWon = false;
            textChild.text = "" + ScoreCounter.scoreChild;
            textParent.text = "" + ScoreCounter.scoreParent;
            if (ScoreCounter.scoreChild >= 3) 
            {
                textChild.text = "You Win !";
                btnNextRound.SetActive(false);
            }
            else if (ScoreCounter.scoreParent >= 3)
            {
                textParent.text = "You Win !";
                btnNextRound.SetActive(false);
            }
        }
    }

    public void NextLevel()
    {
        Application.LoadLevel("BackInTime");
    }

    public void MainMenu() 
    {
        Application.LoadLevel("menu2");
    }
}
