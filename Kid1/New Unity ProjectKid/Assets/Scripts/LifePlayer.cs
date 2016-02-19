using UnityEngine;
using System.Collections;


public class LifePlayer : MonoBehaviour
{

    private int life = 200;
    private GameObject healthBar;
    private EnergyBar eb;
    public GameObject particle;
    public GameObject particleBall;
    public int hitByPyro;
    public int hitByFreezer;
    public int hitByElectronite;
    public static bool executed = false;
    private GameObject canavasBest;
    public static bool GameWon;
    private bool incremented;
    public AudioClip hpminusClip,kidClip,parentClip;
    private AudioSource itemSource;
    void Start()
    {
        healthBar = GameObject.FindGameObjectWithTag("healthbar");
        eb = healthBar.GetComponent<EnergyBar>();
        executed = false;
        itemSource = GetComponent<AudioSource>();
        canavasBest = GameObject.Find("CanvasBestOf5");

        

    }


    void Update()
    {
        if (life <= 0 && !incremented)
        {
            incremented = true;
            Photonstate.finishChanged = true;
            Photonstate.kidVictory = false;
            //new photon
            //DemoGame.getInstance().SendFinishedLevel();
            //DemoGame.getInstance().SendLoadFinish(false);
            ScoreCounter.scoreParent++;
            BackgroundThemeControl.isPlaying = false;
            itemSource.PlayOneShot(parentClip);
            canavasBest.GetComponent<Canvas>().enabled = true;
            GameWon = true;

        }



        if (MisteryBoxItem.isHPminus && !executed)
        {

            executed = true;
            if (life > 25)
                life -= 25;

            else
                life = 0;
        }
        else if (MisteryBoxItem.isReturn && !executed)
        {
            executed = true;
            if (life < 150)
                life += 50;
            else
                life = 200;
        }
        eb.valueCurrent = life;
        Photonstate.lifeChanged = true;
        Photonstate.lifePlayer = life;
        //new photon
        //DemoGame.getInstance().SendPlayerLife(life);


    }


    void OnTriggerEnter(Collider other)
    {

        if (!MisteryBoxItem.isShieldBall)
        {
            if (other.gameObject.tag.Equals("orc"))
            {
                Instantiate(particle, transform.position, Quaternion.identity);
                life -= hitByFreezer;
                eb.valueCurrent -= hitByFreezer;
                Debug.LogWarning("Freezer trigger");
            }

            if (other.gameObject.tag.Equals("plant"))
            {
                Instantiate(particle, transform.position, Quaternion.identity);
                life -= hitByPyro;
                eb.valueCurrent -= hitByPyro;
                Debug.LogWarning("piro trigger");
            }
            if (other.gameObject.tag.Equals("bee"))
            {
                Instantiate(particle, transform.position, Quaternion.identity);
                life -= hitByElectronite;
                eb.valueCurrent -= hitByElectronite;
                Debug.LogWarning("electro trigger");
            }
        }
        if (other.gameObject.tag.Equals("fireThrower"))
        {
            Instantiate(particle, transform.position, Quaternion.identity);
            life -= 10;
            eb.valueCurrent -= 10;
            itemSource.PlayOneShot(hpminusClip);
        }

        if (other.gameObject.tag.Equals("fireFloor"))
        {

            life -= 10;
            eb.valueCurrent -= 10;
            itemSource.PlayOneShot(hpminusClip);
        }
        if (other.gameObject.tag.Equals("ball") && !CharacterStrollingKid.shieldActivated)
        {
            Instantiate(particle, transform.position, Quaternion.identity);
            life -= 10;
            itemSource.PlayOneShot(hpminusClip);
        }
        else if (other.gameObject.tag.Equals("ball") && CharacterStrollingKid.shieldActivated)
        {
            Instantiate(particleBall, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag.Equals("Finish") && !incremented)
        {
            incremented = true;
            ScoreCounter.scoreChild++;
            BackgroundThemeControl.isPlaying = false;
            itemSource.PlayOneShot(kidClip);
            Photonstate.finishChanged = true;
            Photonstate.kidVictory = true;
            //new photon
            //DemoGame.getInstance().SendLoadFinish(true);
            //DemoGame.getInstance().SendFinishedLevel();
            canavasBest.GetComponent<Canvas>().enabled = true;
            GameWon = true;

        }

    }


}
