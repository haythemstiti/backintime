using UnityEngine;
using System.Collections;

public class CanonDesactivator : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
	
	}


    void OnTriggerEnter(Collider other)
    {
        CanonShoot.canonCanShoot = false;
    }
}
