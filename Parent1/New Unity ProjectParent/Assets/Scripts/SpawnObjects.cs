using UnityEngine;
using System.Collections;

public class SpawnObjects : MonoBehaviour {
    public bool monsterClicked1 = false;
    public bool monsterClicked2 = false;
    public bool monsterClicked3 = false;
    public static bool canSpawn = false;
    public bool fireClicked = false;
    private bool zoomInClicked = false;
    private bool zoomOutClicked = false;
    private GameObject imagePyro, imagePyroSelected, imageFreezer, imageFreezerSelected, imageElectronite, imageElectroniteSelected, imageFire, imageFireSelected;
    private GameObject imageInfoPyro, imageInfoFreezer, imageInfoElectronite, imageInfoFire/*, imageInfoCanon*/;

	// Use this for initialization
	void Start () {
        imagePyro = GameObject.Find("imagePyro");
        imagePyroSelected = GameObject.Find("imagePyroSelected");
        imageFreezer = GameObject.Find("imageFreezer");
        imageFreezerSelected = GameObject.Find("imageFreezerSelected");
        imageElectronite = GameObject.Find("imageElectronite");
        imageElectroniteSelected = GameObject.Find("imageElectroniteSelected");
        imageFire = GameObject.Find("imageFire");
        imageFireSelected = GameObject.Find("imageFireSelected");

        imagePyro.SetActive(true);
        imagePyroSelected.SetActive(false);

        imageFreezer.SetActive(true);
        imageFreezerSelected.SetActive(false);

        imageElectronite.SetActive(true);
        imageElectroniteSelected.SetActive(false);

        imageFire.SetActive(true);
        imageFireSelected.SetActive(false);


        imageInfoPyro = GameObject.Find("ImageInfoPyro");
        imageInfoFreezer = GameObject.Find("ImageInfoFreezer");
        imageInfoElectronite = GameObject.Find("ImageInfoElectronite");
        imageInfoFire = GameObject.Find("ImageInfoFire");

       // imageInfoCanon = GameObject.Find("ImageInfoCanon");
        imageInfoPyro.SetActive(false);
        imageInfoFreezer.SetActive(false);
        imageInfoElectronite.SetActive(false);
        imageInfoFire.SetActive(false);

       // imageInfoCanon.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {


	}

    public void addMonster1()
    {
        monsterClicked1 = true;
        monsterClicked2 = false;
        monsterClicked3 = false;
        fireClicked = false;

        imagePyro.SetActive(false);
        imagePyroSelected.SetActive(true);

        imageFreezer.SetActive(true);
        imageFreezerSelected.SetActive(false);

        imageElectronite.SetActive(true);
        imageElectroniteSelected.SetActive(false);

        imageFire.SetActive(true);
        imageFireSelected.SetActive(false);


        imageInfoPyro.SetActive(true);
        imageInfoFreezer.SetActive(false);
        imageInfoElectronite.SetActive(false);
        imageInfoFire.SetActive(false);



           
        
    }
    public void addMonster2()
    {

        monsterClicked2 = true;
        monsterClicked1 = false;
        monsterClicked3 = false;
        fireClicked = false;

        imagePyroSelected.SetActive(false);
        imagePyro.SetActive(true);

        imageFreezer.SetActive(false);
        imageFreezerSelected.SetActive(true);

        imageElectronite.SetActive(true);
        imageElectroniteSelected.SetActive(false);

        imageFire.SetActive(true);
        imageFireSelected.SetActive(false);

        imageInfoPyro.SetActive(false);
        imageInfoFreezer.SetActive(true);
        imageInfoElectronite.SetActive(false);
        imageInfoFire.SetActive(false);
    }
    public void addMonster3()
    {
        monsterClicked3 = true;
        monsterClicked1 = false;
        monsterClicked2 = false;
        fireClicked = false;

        imagePyroSelected.SetActive(false);
        imagePyro.SetActive(true);

        imageFreezer.SetActive(true);
        imageFreezerSelected.SetActive(false);

        imageElectronite.SetActive(false);
        imageElectroniteSelected.SetActive(true);

        imageFire.SetActive(true);
        imageFireSelected.SetActive(false);

        imageInfoPyro.SetActive(false);
        imageInfoFreezer.SetActive(false);
        imageInfoElectronite.SetActive(true);
        imageInfoFire.SetActive(false);
    
    }
    public void addFire()
    {
        fireClicked = true;
        monsterClicked1 = false;
        monsterClicked2 = false;
        monsterClicked3 = false;

        imagePyro.SetActive(true);
        imagePyroSelected.SetActive(false);

        imageFreezer.SetActive(true);
        imageFreezerSelected.SetActive(false);

        imageElectronite.SetActive(true);
        imageElectroniteSelected.SetActive(false);

        imageFire.SetActive(false);
        imageFireSelected.SetActive(true);


        imageInfoPyro.SetActive(false);
        imageInfoFreezer.SetActive(false);
        imageInfoElectronite.SetActive(false);
        imageInfoFire.SetActive(true);

    }




    public void FireCanon()
    {
        
        CanonShoot.canonActivated = true;
        CanonShoot2.canonActivated = true;
        CanonShoot3.canonActivated = true;
        CanonShoot4.canonActivated = true;
    }
    public void DesFireCanon()
    {
        CanonShoot.canonActivated = false;
        CanonShoot2.canonActivated = false;
        CanonShoot3.canonActivated = false;
        CanonShoot4.canonActivated = false;
         
    }

   
}
