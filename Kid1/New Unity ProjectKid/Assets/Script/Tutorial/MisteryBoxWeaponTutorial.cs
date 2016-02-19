using UnityEngine;
using System.Collections;

public class MisteryBoxWeaponTutorial : MonoBehaviour
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

        if (SwitchItemMisteryBoxTutorial.isDefault)
        {
            isIce = false;
            isFire = false;
            isElectricity = false;

        }
        if (enter >= 2)
        {

                Instantiate(particleSystem, this.transform.position, Quaternion.identity);
                number = (int)Random.Range(1f, 4f);
                MisteryBoxCounterTutorial.numberBox = number;
                AnimationTransitionTutorial.animationPlaying = true;
                AnimationTransitionTutorial.anim.SetBool("AnimationChanging", true);
                switch (MisteryBoxCounterTutorial.numberBox)
                {
                    case 1: isIce = true;
                        SwitchItemMisteryBoxTutorial.isDefault = false;
                        SwitchItemMisteryBoxTutorial.player = GameObject.Find("Blade_girl_ver_low_Prefab");
                        SwitchItemMisteryBoxTutorial.ice = Instantiate(ice, ice.transform.position, Quaternion.Euler(new Vector3(270, 90f, 0))) as GameObject;

                        break;
                    case 2: isFire = true;
                        SwitchItemMisteryBoxTutorial.isDefault = false;
                        SwitchItemMisteryBoxTutorial.player = GameObject.Find("Blade_girl_ver_low_Prefab");
                        SwitchItemMisteryBoxTutorial.fire = Instantiate(fireSangoku, fireSangoku.transform.position, Quaternion.Euler(new Vector3(270, 90f, 0))) as GameObject;


                        break;
                    case 3: isElectricity = true;
                        SwitchItemMisteryBoxTutorial.isDefault = false;
                        SwitchItemMisteryBoxTutorial.player = GameObject.Find("Blade_girl_ver_low_Prefab");
                        SwitchItemMisteryBoxTutorial.electricity = Instantiate(electricity, electricity.transform.position, Quaternion.identity) as GameObject;

                        break;

                    //  default: SwitchItemMisteryBox.isDefault = true; break;


                }
                enter = 0;
                SwordControlTutorial.canChoose = false;
                MisteryBoxCounterTutorial.numberBox = 0;
                Destroy(MsBoxChoice);

                Instruction2.confirmChoose = false;
            

        }


    }

    void OnTriggerEnter(Collider other)
    {
        SwordControlTutorial.canChoose = true;
        Instruction2.confirmChoose = true;
        enter++;
    }
}