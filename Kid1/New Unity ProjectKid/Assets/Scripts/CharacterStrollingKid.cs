using UnityEngine;
using System.Collections;

public class CharacterStrollingKid : Photon.MonoBehaviour
{
    private int counter = 1;
    public static Animation animRun;
    public float speed = 0.5f;
    public static float x, y, z, a, b, c;
    public static float accX, accY, accZ;
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
    public bool DestroyMonster;
    private GameObject monster;
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
        animRun["Run"].speed = 0.8f;
        animRun["Jump_NoBlade"].speed = 0.7f;
        canMove = true;
        speedPrivate = speed;
        attack = false;
        shield = false;
        rotxOK = false;
        isTurning = false;
        //new photon
        //    DemoGame.getInstance().SendCharacterState(false, false, false, false);
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

        accX += a;
        accY += b;
        accZ += c;
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

        if (Mathf.Abs(c) >= Mathf.Abs(a) && Mathf.Abs(c) >= Mathf.Abs(b) && (Mathf.Abs(a) + Mathf.Abs(b) + Mathf.Abs(c)) / 3 > 200f && c < 0 && (z - c) < 5000 && rotxOK == false && !isAttacking && !isJumping && !isShielding && canMove || Input.GetKey(KeyCode.Space))
        {
            rotxOK = true;
            Photonstate.playerStateChanged = true;
            Photonstate.jump = true;
            Photonstate.attack = false;
            Photonstate.shield = false;
            Photonstate.turn = false;
            //new photon
            //  DemoGame.getInstance().SendCharacterState(true, false, false, false);
        }
        else if (rotxOK && !isJumping)
        {
            isJumping = true;
            animRun.CrossFade("Jump_NoBlade");
            source.PlayOneShot(soundJump);


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
        if (Mathf.Abs(c) >= Mathf.Abs(a) && Mathf.Abs(c) >= Mathf.Abs(b) && (Mathf.Abs(a) + Mathf.Abs(b) + Mathf.Abs(c)) / 3 > 100f && c > 0 && (z - c) > 5000 && attack == false && !isAttacking && !isJumping && !isShielding && !canMove || Input.GetKey(KeyCode.A))
        {
            Photonstate.playerStateChanged = true;
            Photonstate.jump = false;
            Photonstate.attack = true;
            Photonstate.shield = false;
            Photonstate.turn = false;
            //new photon
            //  DemoGame.getInstance().SendCharacterState(false, true, false, false);
            attack = true;
        }
        else if (attack && !isAttacking)
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
            Photonstate.playerStateChanged = true;
            Photonstate.jump = false;
            Photonstate.attack = false;
            Photonstate.shield = false;
            Photonstate.turn = false;
            //new photon
            //  DemoGame.getInstance().SendCharacterState(false, false, false, false);
            attack = false;
            animTime = 0;
            isAttacking = false;
            animRun.CrossFade("Idle");
        }

        //shield
        if (Mathf.Abs(b) >= Mathf.Abs(a) && Mathf.Abs(b) >= Mathf.Abs(c) && (Mathf.Abs(a) + Mathf.Abs(b) + Mathf.Abs(c)) / 3 > 200f && b > 0 && shield == false && !isAttacking && !isJumping && !isShielding /*&& !canMove*/ || Input.GetKey(KeyCode.Z))
        {
            Photonstate.playerStateChanged = true;
            Photonstate.jump = false;
            Photonstate.attack = false;
            Photonstate.shield = true;
            Photonstate.turn = false;
            //new photon
            //DemoGame.getInstance().SendCharacterState(false, false, true, false);
            shield = true;

        }
        else if (shield && !isShielding)
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


        if (col.gameObject.name.Equals("Cube" + counter) && counter < 12)
        {
            Debug.LogWarning("isTurning and counter: " + counter);
            isTurning = true;
            Photonstate.playerStateChanged = true;
            Photonstate.jump = false;
            Photonstate.attack = false;
            Photonstate.shield = false;
            Photonstate.turn = true;
            //new photon
            //DemoGame.getInstance().SendCharacterState(false, false, false, true);

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
            counter++;
            Photonstate.counter = counter;
            Photonstate.counterChanged = true;
            //new photon
            //DemoGame.getInstance().SendCubeCounter(counter);
        }

    }

    void OnTriggerExit(Collider col)
    {

        if (col.gameObject.tag.Equals("cubeMonster"))
        {
            Debug.LogWarning("not turning and counter: " + counter);
            animRun.CrossFade("Run");
            isTurning = false;
            Photonstate.playerStateChanged = true;
            Photonstate.jump = false;
            Photonstate.attack = false;
            Photonstate.shield = false;
            Photonstate.turn = false;
            //new photon
            //DemoGame.getInstance().SendCharacterState(false, false, false, false);
        }
    }




}
