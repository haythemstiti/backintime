using UnityEngine;
using System.Collections;

public class LocationPlayerManager : MonoBehaviour {

    private GameObject player;

	void Start () {
        
	}
	
	void Update () {

	}
    public void getPosition() 
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        Debug.LogWarning("pos: " + player.transform.position.x);
    }
}
