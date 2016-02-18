using UnityEngine;
using System.Collections;

public class CanonIconActivation : MonoBehaviour {

    private GameObject imageCanon;
    private GameObject detailCanon;
	void Start () {

        imageCanon = GameObject.Find("ImageCanon");
        imageCanon.SetActive(false);
        detailCanon = GameObject.Find("ImageInfoCanon");
        detailCanon.SetActive(false);
	}
	
	
	void Update () {
        if (CanonShoot.canonCanShoot || CanonShoot2.canonCanShoot || CanonShoot3.canonCanShoot || CanonShoot4.canonCanShoot)
        {
            imageCanon.SetActive(true);
            detailCanon.SetActive(true);
        }
        else {
            imageCanon.SetActive(false);
            detailCanon.SetActive(false);
        }
	}
}
