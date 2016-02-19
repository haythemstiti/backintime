using UnityEngine;
using System.Collections;

public class MisteryBoxItemTutorial : MonoBehaviour
{

    private int enter;
    public GameObject MsBoxChoice;

    public GameObject particleSystem;
    public static bool isReturn = false;
    public static bool isMoneyDrainer = false;
    public static bool isShieldBall = false;
    public static bool isHPminus = false;
    public GameObject shieldBall;

    public int lifeMinus;
    public int MoneyDrainer;

    private int number;
    void Start()
    {
        enter = 0;
        isReturn = false;
        isMoneyDrainer = false;
        isShieldBall = false;
        isHPminus = false;
    }

    void Update()
    {
        if (SwitchItemMisteryBoxTutorial.isDefault)
        {
            isReturn = false;
            isMoneyDrainer = false;
            isShieldBall = false;
            isHPminus = false;
        }

        if (enter >= 2)
        {

                Instantiate(particleSystem, this.transform.position, Quaternion.identity);
                number = (int)Random.Range(4f, 8f);
                MisteryBoxCounterTutorial.numberBox = number;
                AnimationTransitionTutorial.animationPlaying = true;
                AnimationTransitionTutorial.anim.SetBool("AnimationChanging", true);
                switch (MisteryBoxCounterTutorial.numberBox)
                {
                    case 4: isReturn = true;
                        SwitchItemMisteryBoxTutorial.isDefault = false;
                        SwitchItemMisteryBoxTutorial.player = GameObject.Find("Blade_girl_ver_low_Prefab");

                        break;
                    case 5: isMoneyDrainer = true;
                        SwitchItemMisteryBoxTutorial.isDefault = false;      
                        SwitchItemMisteryBoxTutorial.player = GameObject.Find("Blade_girl_ver_low_Prefab");

                        break;
                    case 6: isShieldBall = true;
                        SwitchItemMisteryBoxTutorial.isDefault = false;
                        SwitchItemMisteryBoxTutorial.player = GameObject.Find("Blade_girl_ver_low_Prefab");

                        break;
                    case 7: isHPminus = true;
                        SwitchItemMisteryBoxTutorial.isDefault = false;
                        SwitchItemMisteryBoxTutorial.player = GameObject.Find("Blade_girl_ver_low_Prefab");
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