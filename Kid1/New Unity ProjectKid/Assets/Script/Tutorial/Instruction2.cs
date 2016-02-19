using UnityEngine;
using System.Collections;

public class Instruction2 : MonoBehaviour {

    private GameObject imagePickBox, imageChooseItem, imageConfirmChoose;
    private bool move = true;
    private bool instruction2, chooseok;
    public static bool confirmChoose;
	void Start () 
    {
        imagePickBox = GameObject.Find("imagePickBox");
        imagePickBox.SetActive(false);

        imageChooseItem = GameObject.Find("imageChooseItem");
        imageChooseItem.SetActive(false);

        imageConfirmChoose = GameObject.Find("imageConfirmChoose");
        imageConfirmChoose.SetActive(false);

	}
	

	void Update ()
    {
        if (Mathf.Abs(CharacterStrollingTutorial.c) >= Mathf.Abs(CharacterStrollingTutorial.a) && Mathf.Abs(CharacterStrollingTutorial.c) >= Mathf.Abs(CharacterStrollingTutorial.b) && (Mathf.Abs(CharacterStrollingTutorial.a) + Mathf.Abs(CharacterStrollingTutorial.b) + Mathf.Abs(CharacterStrollingTutorial.c)) / 3 > 200f && CharacterStrollingTutorial.c < 0 && (CharacterStrollingTutorial.z - CharacterStrollingTutorial.c) < 5000 || Input.GetKey(KeyCode.Space))
        {
            if (instruction2)
            {
                imagePickBox.SetActive(false);
                if (!chooseok)
                {
                    imageChooseItem.SetActive(true);
                    chooseok = true;
                }
                
            }
        }
        if (confirmChoose)
        {
            imageConfirmChoose.SetActive(true);
            imageChooseItem.SetActive(false);

        }
        else 
        {
            imageConfirmChoose.SetActive(false);
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (move)
        {
            CharacterStrollingTutorial.canMove = false;
            imagePickBox.SetActive(true);
            move = false;
            instruction2 = true;
        }
        MisteryBoxActivationTutorial.activateCollider = true;
    }

    void OnTriggerExit(Collider other) 
    {
        imagePickBox.SetActive(false);
        imageChooseItem.SetActive(false);
        imageConfirmChoose.SetActive(false);
        Destroy(gameObject);
    }

}
