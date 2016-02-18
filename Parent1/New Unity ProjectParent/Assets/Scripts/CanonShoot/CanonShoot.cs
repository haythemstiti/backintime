using UnityEngine;
using System.Collections;

public class CanonShoot : MonoBehaviour
{

    public GameObject spikeBall;
    public static GameObject ballTarget;
    public static bool canonActivated;
    public static bool canonCanShoot = false;
    private AudioSource canonSource;
    public AudioClip canonClip;
    void Start()
    {
        ballTarget = GameObject.FindGameObjectWithTag("hit1");
        canonActivated = false;
        canonCanShoot = false;
        canonSource = GetComponent<AudioSource>();
    }

    void Update()
    {


        if (canonActivated && canonCanShoot)
        {
            if (MoneyCount.Money > 200)
            {

                Instantiate(spikeBall, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                PhotonState.ballChanged = true;
                PhotonState.spawnBall = true;
                PhotonState.typeBall = 1;
                PhotonState.posBall = ballTarget.transform.position;
                //new Photon
                //    DemoGame.getInstance().SendSpawnBall(true, 1, ballTarget.transform.position);
                canonActivated = false;


                MoneyCount.Money -= 200;
            }
            else if (MoneyCount.Money == 200)
            {
                Instantiate(spikeBall, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                PhotonState.ballChanged = true;
                PhotonState.spawnBall = true;
                PhotonState.typeBall = 1;
                PhotonState.posBall = ballTarget.transform.position;
                //new photon
                //      DemoGame.getInstance().SendSpawnBall(true, 1, ballTarget.transform.position);
                MoneyCount.Money = 0;
                canonActivated = false;
            }
            canonSource.PlayOneShot(canonClip);

        }
    }


}
