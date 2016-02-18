using UnityEngine;
using System.Collections;

public class DetailShowObjects : MonoBehaviour {

    private GameObject detailPyro;
    private GameObject detailFreezer;
    private GameObject detailElectronite;
    private GameObject detailFire;
    private GameObject detailCanon;
    private GameObject closeDetailsImg;
	void Start () {
        detailPyro = GameObject.Find("ImageDetailPyro");
        detailFreezer = GameObject.Find("ImageDetailFreezer");
        detailElectronite = GameObject.Find("ImageDetailElectronite");
        detailFire = GameObject.Find("ImageDetailFire");
        detailCanon = GameObject.Find("ImageDetailCanon");
        closeDetailsImg = GameObject.Find("ImageCloseDetails");

        detailPyro.SetActive(false);
        detailFreezer.SetActive(false);
        detailElectronite.SetActive(false);
        detailFire.SetActive(false);
        detailCanon.SetActive(false);
        closeDetailsImg.SetActive(false);
	}
	
	void Update () {
	
	}

    public void showDetailPyro()
    {
        detailPyro.SetActive(true);
        detailFreezer.SetActive(false);
        detailElectronite.SetActive(false);
        detailFire.SetActive(false);
        detailCanon.SetActive(false);
        closeDetailsImg.SetActive(true);
    }
    public void showDetailFreezer() 
    {
        detailPyro.SetActive(false);
        detailFreezer.SetActive(true);
        detailElectronite.SetActive(false);
        detailFire.SetActive(false);
        detailCanon.SetActive(false);
        closeDetailsImg.SetActive(true);
    }
    public void showDetailElectronite()
    {
        detailPyro.SetActive(false);
        detailFreezer.SetActive(false);
        detailElectronite.SetActive(true);
        detailFire.SetActive(false);
        detailCanon.SetActive(false);
        closeDetailsImg.SetActive(true);
    }
    public void showDetailFire() 
    {
        detailPyro.SetActive(false);
        detailFreezer.SetActive(false);
        detailElectronite.SetActive(false);
        detailFire.SetActive(true);
        detailCanon.SetActive(false);
        closeDetailsImg.SetActive(true);
    }
    public void showDetailCanon() 
    {
        detailPyro.SetActive(false);
        detailFreezer.SetActive(false);
        detailElectronite.SetActive(false);
        detailFire.SetActive(false);
        detailCanon.SetActive(true);
        closeDetailsImg.SetActive(true);
    }

    public void closeDetails()
    {
        detailPyro.SetActive(false);
        detailFreezer.SetActive(false);
        detailElectronite.SetActive(false);
        detailFire.SetActive(false);
        detailCanon.SetActive(false);
        closeDetailsImg.SetActive(false);
    }
}
