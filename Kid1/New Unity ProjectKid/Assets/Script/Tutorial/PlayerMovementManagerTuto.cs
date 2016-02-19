using UnityEngine;
using System.Collections;

public class PlayerMovementManagerTuto : MonoBehaviour
{
    private GameObject player;
    private Vector3 distToPlayer;
    private Animation animation;

    void Start()
    {

    }

    void Update()
    {
        distToPlayer = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
        if (distToPlayer.magnitude < 2.5f)
        {
            CharacterStrollingTutorial.canMove = false;
        }

    }

}
