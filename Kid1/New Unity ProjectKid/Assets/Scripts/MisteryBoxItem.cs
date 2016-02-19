using UnityEngine;
using System.Collections;

public class MisteryBoxItem : MonoBehaviour
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
        if (SwitchItemMisteryBox.isDefault)
        {
            isReturn = false;
            isMoneyDrainer = false;
            isShieldBall = false;
            isHPminus = false;

        }

        if (enter >= 2)
        {

            Instantiate(particleSystem, this.transform.position, Quaternion.identity);
            Photonstate.playing = true;
            number = (int)Random.Range(4f, 8f);
            MisteryBoxCounter.numberBox = number;
            AnimationTransition.animationPlaying = true;
            AnimationTransition.anim.SetBool("AnimationChanging", true);
            switch (MisteryBoxCounter.numberBox)
            {
                case 4: isReturn = true;
                    SwitchItemMisteryBox.isDefault = false;
                    SwitchItemMisteryBox.player = GameObject.Find("Blade_girl_ver_low_Prefab(Clone)");
                    SwitchItemMisteryBox.message2 = "isreturn";

                    break;
                case 5: isMoneyDrainer = true;
                    SwitchItemMisteryBox.message2 = "ismoney";
                    SwitchItemMisteryBox.isDefault = false;
                    SwitchItemMisteryBox.player = GameObject.Find("Blade_girl_ver_low_Prefab(Clone)");
                    

                    break;
                case 6: isShieldBall = true;
                    SwitchItemMisteryBox.message2 = "isshield";
                    SwitchItemMisteryBox.isDefault = false;
                    SwitchItemMisteryBox.player = GameObject.Find("Blade_girl_ver_low_Prefab(Clone)");
                    

                    break;
                case 7: isHPminus = true;
                    SwitchItemMisteryBox.message2 = "ishpminus";
                    SwitchItemMisteryBox.isDefault = false;
                    SwitchItemMisteryBox.player = GameObject.Find("Blade_girl_ver_low_Prefab(Clone)");
                    break;
                //  default: SwitchItemMisteryBox.isDefault = true; break;
            }
            enter = 0;
            SwordControl.canChoose = false;
            Destroy(MsBoxChoice);



        }


    }

    void OnTriggerEnter(Collider other)
    {
        SwordControl.canChoose = true;
        enter++;
    }


    
}