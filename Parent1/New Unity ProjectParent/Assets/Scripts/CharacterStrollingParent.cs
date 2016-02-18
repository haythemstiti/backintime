using UnityEngine;
using System.Collections;

public class CharacterStrollingParent : MonoBehaviour
{
    public static int counter = 1;
    public static Animation animRun;
    public float speed = 0.5f;
    private float animTime = 0;
    private int rotX = 0;
    private string message = "empty";
    public static bool rotxOK = false;
    public static bool attack = false;
    public static bool shield = false;
    private bool isAttacking = false;
    private bool isJumping = false;
    private bool isShielding = false;
    public static bool isTurning = false;
    public static bool canMove = true;
    private CapsuleCollider collider;
    public AudioClip soundJump, soundAttack, soundAttack1;
    private AudioSource source;
    public static bool shieldActivated;
    private float speedPrivate;
    public static Vector3 pos;
    public static bool isFighting;
   // private Rigidbody rb;
    void Start()
    {
        animRun = GetComponent<Animation>();
        animRun.Play();
        animRun.wrapMode = WrapMode.Loop;
        collider = GetComponent<CapsuleCollider>();
        source = GetComponent<AudioSource>();
       // rb = GetComponent<Rigidbody>();
        animRun["Run"].speed = 0.8f;
        animRun["Jump_NoBlade"].speed = 0.7f;
        canMove = true;
        speedPrivate = speed;
        attack = false;
        shield = false;
        rotxOK = false;
        isTurning = false;
        isFighting = false;
        counter = 1;
        
    }


    void Update()
    {

        if (canMove)
        {
            if (counter < 12)
            {
                transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("Cube" + counter).transform.position, Time.deltaTime * speed);
                transform.rotation = Quaternion.Lerp(transform.rotation, GameObject.Find("Cube" + counter).transform.rotation, Time.deltaTime * speed);
            }
        }
            if(isFighting)
        {
            transform.position = pos;
        }
        
        if (!isAttacking && !isJumping && !isShielding && !isTurning)
        {
            if (canMove)
            {
                animRun.CrossFade("Run");
                speed = 1.5f;
            }
            else
            {
                animRun.CrossFade("Idle");
            }
        }

        if (rotxOK && !isAttacking && !isJumping && !isShielding && canMove)
        {
            isJumping = true;
            animRun.CrossFade("Jump_NoBlade");
            source.PlayOneShot(soundJump);
            //  rb.AddForce(Vector3.up * 50, ForceMode.VelocityChange);

        }
        if (isJumping)
        {
            speed = 3.0f;
            animTime += Time.deltaTime;
            collider.enabled = false;

        }
        if (animTime > 1.2f && isJumping)
        {
            rotxOK = false;
            animTime = 0;
            isJumping = false;
            animRun.CrossFade("Run");
            collider.enabled = true;
            speed = 1.5f;
        }

        //attack
        if (attack && !isAttacking && !isJumping && !isShielding && !canMove)
        {
            isAttacking = true;
            message = "attack begin";
            animRun.CrossFade("Attack");
            message = "attack end";
            source.PlayOneShot(soundAttack);
        }
        if (isAttacking)
        {
            animTime += Time.deltaTime;

        }
        if (animTime > 1.667f && isAttacking)
        {
            attack = false;
            animTime = 0;
            isAttacking = false;
            animRun.CrossFade("Idle");
        }

        //shield
        if (shield && !isAttacking && !isJumping && !isShielding)
        {
            isShielding = true;
            message = "attack begin";
            animRun.CrossFade("Block");
            message = "attack end";
            source.PlayOneShot(soundAttack1);
            shieldActivated = true;
            speed = 0;
        }
        if (isShielding)
        {
            animTime += Time.deltaTime;

        }
        if (animTime > 1.067f && isShielding)
        {
            shield = false;
            speed = speedPrivate;
            animTime = 0;
            isShielding = false;
            animRun.CrossFade("Idle");
            shieldActivated = false;
        }

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name.Equals("Trigger" + counter) && counter < 12)
        {
            GameObject.Find("Cube" + counter).GetComponent<NetworkCharacter>().containsMonster = true;
        }

        if (col.gameObject.name.Equals("Cube" + counter) && counter < 12)
        {
            switch (counter)
            {
                case 1: animRun.CrossFade("L_Run"); break;
                case 2: animRun.CrossFade("R_Run"); break;
                case 3: animRun.CrossFade("R_Run"); break;
                case 4: animRun.CrossFade("L_Run"); break;
                case 5: animRun.CrossFade("L_Run"); break;
                case 6: animRun.CrossFade("R_Run"); break;
                case 7: animRun.CrossFade("R_Run"); break;
                case 8: animRun.CrossFade("R_Run"); break;
                case 9: animRun.CrossFade("R_Run"); break;
                case 10: animRun.CrossFade("L_Run"); break;
                default:
                    break;
            }
        }
      
        else if (col.gameObject.tag.Equals("ball") && shieldActivated)
        {
            Destroy(col.gameObject);

        }
         
    }

    

 

}
