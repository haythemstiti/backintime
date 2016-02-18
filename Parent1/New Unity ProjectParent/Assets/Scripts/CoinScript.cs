using UnityEngine;
using System.Collections;

public class CoinScript : MonoBehaviour
{

    public GameObject particleCoin;
    private float time;
    private bool clicked;
    void Start()
    {
    }

    void Update()
    {
        transform.Rotate(new Vector3(0f, 7f, 0f));
        if (clicked)
            time += Time.deltaTime;
    }
    void OnMouseDown()
    {
        clicked = true;
        Instantiate(particleCoin, transform.position, Quaternion.identity);
        MoneyCount.Money += 50;
        PhotonState.destroyCoin = true;
        Destroy(gameObject);
    }
}
