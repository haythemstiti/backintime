using UnityEngine;
using System.Collections;

public class Instruction4 : MonoBehaviour
{

    private GameObject imageAttack, imageAttackSuccess;
    private bool instruction4;
    private bool move = true;
    void Start()
    {
        imageAttack = GameObject.Find("imageAttack");
        imageAttack.SetActive(false);

        imageAttackSuccess = GameObject.Find("imageAttackSuccess");
        imageAttackSuccess.SetActive(false);
    }

    void Update()
    {
        if (Mathf.Abs(CharacterStrollingTutorial.c) >= Mathf.Abs(CharacterStrollingTutorial.a) && Mathf.Abs(CharacterStrollingTutorial.c) >= Mathf.Abs(CharacterStrollingTutorial.b) && (Mathf.Abs(CharacterStrollingTutorial.a) + Mathf.Abs(CharacterStrollingTutorial.b) + Mathf.Abs(CharacterStrollingTutorial.c)) / 3 > 100f && CharacterStrollingTutorial.c > 0 && (CharacterStrollingTutorial.z - CharacterStrollingTutorial.c) > 5000 && !CharacterStrollingTutorial.canMove || Input.GetKey(KeyCode.A))
        {
            if (instruction4)
            {
                imageAttack.SetActive(false);
                imageAttackSuccess.SetActive(true);
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            if (move)
            {
                imageAttack.SetActive(true);
                CharacterStrollingTutorial.canMove = false;
                move = false;
            }
            instruction4 = true;
        }
    }
    public void AttackSuccess1()
    {
        CharacterStrollingTutorial.canMove = true;
        imageAttackSuccess.SetActive(false);
        Destroy(gameObject);
    }
}

