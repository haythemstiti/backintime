using UnityEngine;
using System.Collections;

public class CanonBallControl : MonoBehaviour
{

    public bool SpawnBall;
    public int ballType;
    public GameObject ball1, ball2, ball3, ball4;
    private GameObject ball, spike;
    private Vector3 pos;
    public Vector3 moveTo;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (SpawnBall)
        {
            switch (ballType)
            {
                case 1: ball = ball1;
                    pos = GameObject.Find("hit1").transform.position;
                    break;
                case 2: ball = ball2;
                    pos = GameObject.Find("hit2").transform.position;
                    break;
                case 3: ball = ball3;
                    pos = GameObject.Find("hit3").transform.position;
                    break;
                case 4: ball = ball4;
                    pos = GameObject.Find("hit4").transform.position;
                    break;

            }
            spike = Instantiate(ball, pos, Quaternion.identity) as GameObject;
            SpawnBall = false;
        }
        if(spike)
        spike.transform.position = Vector3.MoveTowards(spike.transform.position, moveTo, Time.deltaTime * 10);



    }
}
