using UnityEngine;
using System.Collections;

public class MisteryBoxWeapon : MonoBehaviour
{

    private int enter;
    public GameObject MsBoxChoice;

    public GameObject particleSystem;
    public static bool isIce = false;
    public static bool isFire = false;
    public static bool isElectricity = false;

    public GameObject fireSangoku;
    public GameObject electricity;
    public GameObject ice;
    private GameObject player;
    private int number;

    void Start()
    {
        isIce = false;
        isFire = false;
        isElectricity = false;
    }

    void Update()
    {

        if (SwitchItemMisteryBox.isDefault)
        {
            isIce = false;
            isFire = false;
            isElectricity = false;

        }
        if (enter >= 2)
        {

            Instantiate(particleSystem, this.transform.position, Quaternion.identity);
            Photonstate.playing = true;
            number = (int)Random.Range(1f, 4f);
            MisteryBoxCounter.numberBox = number;
            AnimationTransition.animationPlaying = true;
            AnimationTransition.anim.SetBool("AnimationChanging", true);
            switch (MisteryBoxCounter.numberBox)
            {
                case 1: isIce = true;
                    SwitchItemMisteryBox.isDefault = false;
                    SwitchItemMisteryBox.player = GameObject.Find("Blade_girl_ver_low_Prefab(Clone)");
                    SwitchItemMisteryBox.ice = Instantiate(ice, ice.transform.position, Quaternion.Euler(new Vector3(270, 90f, 0))) as GameObject;

                    break;
                case 2: isFire = true;
                    SwitchItemMisteryBox.isDefault = false;
                    SwitchItemMisteryBox.player = GameObject.Find("Blade_girl_ver_low_Prefab(Clone)");
                    SwitchItemMisteryBox.fire = Instantiate(fireSangoku, fireSangoku.transform.position, Quaternion.Euler(new Vector3(270, 90f, 0))) as GameObject;


                    break;
                case 3: isElectricity = true;
                    SwitchItemMisteryBox.isDefault = false;
                    SwitchItemMisteryBox.player = GameObject.Find("Blade_girl_ver_low_Prefab(Clone)");
                    SwitchItemMisteryBox.electricity = Instantiate(electricity, electricity.transform.position, Quaternion.identity) as GameObject;

                    break;

                //  default: SwitchItemMisteryBox.isDefault = true; break;


            }
            enter = 0;
            SwordControl.canChoose = false;
            MisteryBoxCounter.numberBox = 0;
            Destroy(MsBoxChoice);
        }




    }

    void OnTriggerEnter(Collider other)
    {
        SwordControl.canChoose = true;
        enter++;
    }



}