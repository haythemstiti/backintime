using UnityEngine;
using System.Collections;

public class PlayerMovementManger : MonoBehaviour
{

    private Vector3 distToPlayer;


    void Start()
    {


    }

    void Update()
    {
        distToPlayer = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;


        if (distToPlayer.magnitude < 1.5f)
        {

            CharacterStrollingKid.canMove = false;
            Photonstate.canMove = false;
            Photonstate.movingChanged = true;
            Photonstate.posChanged = true;
            Photonstate.pos = GameObject.FindGameObjectWithTag("Player").transform.position;
            //new photon
            //DemoGame.getInstance().SendCanMove(false);
            //DemoGame.getInstance().SendPlayerPosition(GameObject.FindGameObjectWithTag("Player").transform.position);
        }


    }

}
