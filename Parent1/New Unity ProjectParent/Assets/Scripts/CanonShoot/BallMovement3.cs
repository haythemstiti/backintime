using UnityEngine;
using System.Collections;

public class BallMovement3 : MonoBehaviour
{

    public int speed;
    Vector3 realPosition = Vector3.zero;
    void Start()
    {

    }

    void Update()
    {
        
            transform.position = Vector3.MoveTowards(transform.position, CanonShoot3.ballTarget.transform.position, Time.deltaTime * speed);
        
    }

}
