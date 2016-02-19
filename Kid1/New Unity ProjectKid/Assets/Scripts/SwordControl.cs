using UnityEngine;
using System.Collections;

public class SwordControl : MonoBehaviour
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
                transform.Translate(new Vector3(CharacterStrollingKid.y / 500000, 0f, 0f));
                transform.Translate(new Vector3(Input.GetAxis("Horizontal") / 50, 0f, 0f));
            }
            if (canChoose)
            {
                if (Mathf.Abs(CharacterStrollingKid.c) >= Mathf.Abs(CharacterStrollingKid.a) && Mathf.Abs(CharacterStrollingKid.c) >= Mathf.Abs(CharacterStrollingKid.b) && (Mathf.Abs(CharacterStrollingKid.a) + Mathf.Abs(CharacterStrollingKid.b) + Mathf.Abs(CharacterStrollingKid.c)) / 3 > 100f && CharacterStrollingKid.c > 0 && (CharacterStrollingKid.z - CharacterStrollingKid.c) > 5000 || Input.GetKey(KeyCode.A))
                {
                    anim.CrossFade("Attack");
                }
            }
        
   
    }

}
