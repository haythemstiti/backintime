﻿using UnityEngine;
using System.Collections;

public class CanonActivation2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        CanonShoot2.canonCanShoot = true;
    }
}
