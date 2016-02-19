using UnityEngine;
using System.Collections;

public class SwordControlTutorial : MonoBehaviour
{

    Vector3 realPosition = Vector3.zero;
    Quaternion realRotation = Quaternion.identity;
    public static bool canChoose = false;
    public Animation anim;
    void Start()
    {
        anim = GetComponent<Animation>();
        canChoose = false;
    }

    void Update()
    {

        if (!canChoose)
        {
            transform.Translate(new Vector3(CharacterStrollingTutorial.y / 500000, 0f, 0f));
            transform.Translate(new Vector3(Input.GetAxis("Horizontal") / 50, 0f, 0f));
        }
        if (canChoose)
        {
            if (Mathf.Abs(CharacterStrollingTutorial.c) >= Mathf.Abs(CharacterStrollingTutorial.a) && Mathf.Abs(CharacterStrollingTutorial.c) >= Mathf.Abs(CharacterStrollingTutorial.b) && (Mathf.Abs(CharacterStrollingTutorial.a) + Mathf.Abs(CharacterStrollingTutorial.b) + Mathf.Abs(CharacterStrollingTutorial.c)) / 3 > 100f && CharacterStrollingTutorial.c > 0 && (CharacterStrollingTutorial.z - CharacterStrollingTutorial.c) > 5000 || Input.GetKey(KeyCode.A))
            {
                anim.CrossFade("Attack");
            }
        }
    }







    /*  void OnGUI()
      {
          GUI.TextArea(new Rect(100f, 100f, 100f, 100f), "A :" + a + "\n nbrEnter :" + MisteryBox.enter + "\n CanAttack :" + canAttack);
      }
     **/
}
