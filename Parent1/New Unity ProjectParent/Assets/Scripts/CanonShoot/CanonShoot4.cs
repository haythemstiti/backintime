using UnityEngine;
using System.Collections;

public class CanonShoot4 : MonoBehaviour {

    public GameObject spikeBall;
    public static GameObject ballTarget;
    public static bool canonActivated;
    public static bool canonCanShoot = false;
    void Start()
    {
        ballTarget = GameObject.FindGameObjectWithTag("hit4");
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
                PhotonState.typeBall = 4;
                PhotonState.posBall = ballTarget.transform.position;
                //new photon
                //  DemoGame.getInstance().SendSpawnBall(true, 4, ballTarget.transform.position);
                canonActivated = false;

                MoneyCount.Money -= 200;
            }
            else if (MoneyCount.Money == 200)
            {
                Instantiate(spikeBall, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                PhotonState.ballChanged = true;
                PhotonState.spawnBall = true;
                PhotonState.typeBall = 4;
                PhotonState.posBall = ballTarget.transform.position;
                // new photon
                //   DemoGame.getInstance().SendSpawnBall(true, 4, ballTarget.transform.position);
                MoneyCount.Money = 0;
                canonActivated = false;
            }
        }
    }

}
