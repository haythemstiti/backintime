using UnityEngine;
using System.Collections;

public class CharacterStrollingTutorial : MonoBehaviour
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
    //private CapsuleCollider collider;
    public AudioClip soundJump, soundAttack, soundAttack1;
    private AudioSource source;
    public static bool shieldActivated;
    private float speedPrivate;
    // private Rigidbody rb;
    void Start()
    {
        animRun = GetComponent<Animation>();
        animRun.Play();
        animRun.wrapMode = WrapMode.Loop;
        //collider = GetComponent<CapsuleCollider>();
        source = GetComponent<AudioSource>();
        // rb = GetComponent<Rigidbody>();
        animRun["Run"].speed = 0.8f;
        animRun["Jump_NoBlade"].speed = 0.7f;
        canMove = true;
        speedPrivate = speed;
        isTurning = false;
    }


    void Update()
    {

        if (canMove)
        {
            if (counter <= 2)
            {
                transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("Cube" + counter).transform.position, Time.deltaTime * speed);
                //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, (transform.rotation.eulerAngles.y + 100f * Time.deltaTime), transform.rotation.eulerAngles.z);
                transform.rotation = Quaternion.Lerp(transform.rotation, GameObject.Find("Cube" + counter).transform.rotation, Time.deltaTime * speed);
                //  transform.LookAt(GameObject.Find("Cube" + counter).transform.position);


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

        if (Mathf.Abs(c) >= Mathf.Abs(a) && Mathf.Abs(c) >= Mathf.Abs(b) && (Mathf.Abs(a) + Mathf.Abs(b) + Mathf.Abs(c)) / 3 > 200f && c < 0 && (z - c) < 5000 && rotxOK == false && !isAttacking && !isJumping && !isShielding || Input.GetKey(KeyCode.Space))
        {
            rotxOK = true;
        }
        else if (rotxOK && !isJumping)
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
            

        }
        if (animTime > 1.2f && isJumping)
        {
            rotxOK = false;
            animTime = 0;
            isJumping = false;
            animRun.CrossFade("Run");
           
            speed = 1.5f;
        }

        //attack
        if (Mathf.Abs(c) >= Mathf.Abs(a) && Mathf.Abs(c) >= Mathf.Abs(b) && (Mathf.Abs(a) + Mathf.Abs(b) + Mathf.Abs(c)) / 3 > 100f && c > 0 && (z - c) > 5000 && attack == false && !isAttacking && !isJumping && !isShielding && !canMove || Input.GetKey(KeyCode.A))
        {
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
            attack = false;
            animTime = 0;
            isAttacking = false;
            animRun.CrossFade("Idle");
        }

        //shield
        if (Mathf.Abs(b) >= Mathf.Abs(a) && Mathf.Abs(b) >= Mathf.Abs(c) && (Mathf.Abs(a) + Mathf.Abs(b) + Mathf.Abs(c)) / 3 > 200f && b > 0 && shield == false && !isAttacking && !isJumping && !isShielding /*&& !canMove*/ || Input.GetKey(KeyCode.Z))
        {
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

        // Debug.Log("x: "+x+" y: "+y+" z: "+" a: "+a+" b "+b+" c "+c);
        //attack

        /*   else if (animTime > animRun["Attack00"].time)
           {
               message = "attack end 1";
               animRun.CrossFade("Run");
               rotX = 0;
           }
           */
        /*  if (!animRun.IsPlaying("Attack00"))
          {
              animRun.CrossFade("Run");
              rotX = 0;
          }
          */

    }

    void OnTriggerEnter(Collider col)
    {


        if (col.gameObject.name.Equals("Cube" + counter) && counter <=2)
        {
            Debug.LogWarning("isTurning and counter: " + counter);
            isTurning = true;

            //   Debug.LogWarning("contains: " + GameObject.Find("Cube" + counter).GetComponent<NetworkCharacter>().containsMonster);
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
        }
    }

    void OnTriggerExit(Collider col)
    {

        if (col.gameObject.name.Equals("Cube1"))
        {
            // Debug.LogWarning("not turning and counter: " + counter);
            animRun.CrossFade("Run");
            isTurning = false;
        }
    }

    void OnGUI()
    {/*
        if (Mathf.Abs(c) >= Mathf.Abs(a) && Mathf.Abs(c) >= Mathf.Abs((b))) message = "CCCCC";
        if (Mathf.Abs(b) >= Mathf.Abs(a) && Mathf.Abs(b) >= Mathf.Abs((c))) message = "BBBBB";
        if (Mathf.Abs(a) >= Mathf.Abs(b) && Mathf.Abs(a) >= Mathf.Abs((c))) message = "AAAAA"; */
        //  GUI.TextField(new Rect(200, 200, 400, 400), "x: " + x + "\n y: " + y + "\n z: " + z + "\n a:" + a + "\n b:" + b + "\n c:" + c + "\n accX: " + accX + "\n accY: " + accY + "\n accZ: " + accZ + "\n message: " + message);
    }

}
