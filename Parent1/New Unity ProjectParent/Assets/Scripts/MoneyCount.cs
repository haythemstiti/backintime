using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MoneyCount : MonoBehaviour
{

    public static int Money;
    private float timeChrono;
    private float timeChronoDestroy;
    public Text text;
    public GameObject coin;
    private float x, z;
    private bool coinInstanciated;
    private GameObject coin2;
    public GameObject particleCoinAppear;
    void Start()
    {
        Money = 1500;
    }


    void Update()
    {
        
            timeChrono += Time.deltaTime;

            if (timeChrono >= 6)
            {
                x = Random.Range(10f, 30f);
                z = Random.Range(15f, 35f);
                coin2 = Instantiate(coin, new Vector3(x, 7f, z), Quaternion.Euler(new Vector3(270f, 0f, 0f))) as GameObject;
                Instantiate(particleCoinAppear, coin2.transform.position, Quaternion.identity);
                coinInstanciated = true;
                timeChrono = 0;
            }

            if (coinInstanciated)
            {
                timeChronoDestroy += Time.deltaTime;
            }

            if (timeChronoDestroy >= 6)
            {
                Destroy(coin2);
                coinInstanciated = false;
                timeChronoDestroy = 0;
                timeChrono = 0;

            }
            text.text = Money + "";
            PhotonState.moneyChanged = true;
            PhotonState.money = Money;
          //new photon
           // DemoGame.getInstance().SendMoney(Money);



    }

}
