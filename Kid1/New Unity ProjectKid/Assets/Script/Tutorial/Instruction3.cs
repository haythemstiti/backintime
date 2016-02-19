using UnityEngine;
using System.Collections;

public class Instruction3 : MonoBehaviour
{

    private GameObject imageShield, imageShieldSuccess;
    private bool instruction3;
    private bool move = true;
    void Start()
    {
        imageShield = GameObject.Find("imageShield");
        imageShield.SetActive(false);

        imageShieldSuccess = GameObject.Find("imageShieldSuccess");
        imageShieldSuccess.SetActive(false);
    }

    void Update()
    {
        if (Mathf.Abs(CharacterStrollingTutorial.b) >= Mathf.Abs(CharacterStrollingTutorial.a) && Mathf.Abs(CharacterStrollingTutorial.b) >= Mathf.Abs(CharacterStrollingTutorial.c) && (Mathf.Abs(CharacterStrollingTutorial.a) + Mathf.Abs(CharacterStrollingTutorial.b) + Mathf.Abs(CharacterStrollingTutorial.c)) / 3 > 200f && CharacterStrollingTutorial.b > 0 || Input.GetKey(KeyCode.Z))
        {
            if (instruction3)
            {
                imageShield.SetActive(false);
                imageShieldSuccess.SetActive(true);
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {

            if (move)
            {
                imageShield.SetActive(true);
                CharacterStrollingTutorial.canMove = false;
                move = false;
            }
            instruction3 = true;

    }
    public void shieldSuccess1()
    {
        CharacterStrollingTutorial.canMove = true;
        imageShieldSuccess.SetActive(false);
        Destroy(gameObject);
    }
}

