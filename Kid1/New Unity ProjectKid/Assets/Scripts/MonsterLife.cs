using UnityEngine;
using System.Collections;

public class MonsterLife : MonoBehaviour {

    public int life;
    public GameObject particle;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (life <= 0)
        {
            Destroy(gameObject);
            Instantiate(particle, transform.position, Quaternion.identity);
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("sword"))
        {

        }
    }
}
