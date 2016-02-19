using UnityEngine;
using System.Collections;

public class Instruction1 : MonoBehaviour {

    private GameObject imageJump, imageJumpSuccess;
    private bool move = true;
    private bool jumpSuccess,instruction1;
	void Start () {
        imageJump = GameObject.Find("imageJump");
        imageJump.SetActive(false);

        imageJumpSuccess = GameObject.Find("imageJumpSuccess");
        imageJumpSuccess.SetActive(false);
	}
	
	void Update () {
        if (Mathf.Abs(CharacterStrollingTutorial.c) >= Mathf.Abs(CharacterStrollingTutorial.a) && Mathf.Abs(CharacterStrollingTutorial.c) >= Mathf.Abs(CharacterStrollingTutorial.b) && (Mathf.Abs(CharacterStrollingTutorial.a) + Mathf.Abs(CharacterStrollingTutorial.b) + Mathf.Abs(CharacterStrollingTutorial.c)) / 3 > 200f && CharacterStrollingTutorial.c < 0 && (CharacterStrollingTutorial.z - CharacterStrollingTutorial.c) < 5000 || Input.GetKey(KeyCode.Space))
        {
            if (instruction1)
            {
                imageJump.SetActive(false);
                imageJumpSuccess.SetActive(true);
            }
        }

       
	}

    void OnTriggerEnter(Collider other) {

        if (move)
        {
            imageJump.SetActive(true);
            CharacterStrollingTutorial.canMove = false;
            move = false;
        }
        instruction1 = true;
    }
    public void jumpSuccess1() 
    {
        CharacterStrollingTutorial.canMove = true;
        imageJumpSuccess.SetActive(false);
        Destroy(gameObject);
    }
}
