using UnityEngine;
using System.Collections;

public class DestroyMonster : MonoBehaviour {

    private GameObject monster;
    public bool DestroyIt;
    public GameObject particle,particleHit;
    private bool attacking = false;
    public static int cubeNumber,type;
    GameObject[] monsters;
    private CubeNumber cubeScript;
	// Use this for initialization
	void Start () {
        monsters = new GameObject[100];
	}
	
	// Update is called once per frame
	void Update () {

        if (DestroyIt)
        {
            
            DestroyIt = false;
            switch (type)
            {
                case 1: monsters = GameObject.FindGameObjectsWithTag("pyro"); break;
                case 2: monsters = GameObject.FindGameObjectsWithTag("freezer"); break;
                case 3: monsters = GameObject.FindGameObjectsWithTag("electronite"); break;
            }
            
            foreach (GameObject item in monsters)
            {
                
                cubeScript = item.GetComponent<CubeNumber>();
                if (cubeScript != null)
                {
                    if (cubeScript.cubeNumber == cubeNumber)
                    {

                        monster = item;
                        Debug.Log("name: " + monster.gameObject.name+"cube number: "+cubeScript.cubeNumber);
                    }
                }
            }
            Instantiate(particle, monster.transform.position, Quaternion.identity);
            Debug.Log("destroy");
            if (monster != null)
            {
                Destroy(monster);
            }
            CharacterStrollingParent.isFighting = false;
        }

	}

}
