using UnityEngine;
using System.Collections;

public class LifeMonsterTutorial : MonoBehaviour {

    public GameObject particuleExplosion;
    private GameObject imageFinish;
    public int life;
	void Start () {
        imageFinish = GameObject.Find("imageFinish");
        imageFinish.SetActive(false);
	}
	
	void Update () {
        if (life <= 0) 
        {
            Instantiate(particuleExplosion, transform.position, Quaternion.identity);
            imageFinish.SetActive(true);
            Destroy(gameObject);
        }
	}
    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag.Equals("sword"))
        {
            life--;
        }
    }
}
