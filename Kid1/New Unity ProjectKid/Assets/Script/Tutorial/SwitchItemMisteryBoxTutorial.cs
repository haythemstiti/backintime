using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SwitchItemMisteryBoxTutorial : MonoBehaviour
{

    public Sprite imageIce;
    public Sprite imageFire;
    public Sprite imageElectricity;
    public Sprite imageReturn;
    public Sprite imageMonezDrainer;
    public Sprite imageShieldBall;
    public Sprite imageHpMinus;
    private Image canvasItem;
    public static int imageChanged;
    public static bool isDefault;
    public static bool animationFinished;
    public Image imageAnimation;
    public static GameObject fire;
    public static GameObject electricity;
    public static  GameObject ice;
    public static GameObject player;




    void Start()
    {
        canvasItem = GetComponent<Image>();
        canvasItem.enabled = false;
        isDefault = false;

    }

    void Update()
    {
        if (AnimationTransitionTutorial.animationPlaying)
        {
            imageAnimation.enabled = true;
        }
        else
        {
            imageAnimation.enabled = false;
        }
        if (isDefault)
        {
          //  Debug.LogWarning("is in default");
            imageChanged = 1;
            canvasItem.enabled = false;
            GameObject.Find("Shield").GetComponent<MeshRenderer>().enabled = false;
            Destroy(fire);
            Destroy(electricity);
            Destroy(ice);

        }
        else if (MisteryBoxWeaponTutorial.isIce && animationFinished)
        {
            canvasItem.sprite = imageIce;
            canvasItem.enabled = true;
            imageChanged = 2;
            animationFinished = false;
            ice.transform.SetParent(player.transform, false);

        }
        else if (MisteryBoxWeaponTutorial.isFire && animationFinished)
        {
            canvasItem.sprite = imageFire;
            canvasItem.enabled = true;
            imageChanged = 3;
            animationFinished = false;
            fire.transform.SetParent(player.transform, false);

        }
        else if (MisteryBoxWeaponTutorial.isElectricity && animationFinished)
        {
            canvasItem.sprite = imageElectricity;
            canvasItem.enabled = true;
            imageChanged = 4;
            animationFinished = false;
            electricity.transform.SetParent(player.transform, false);

        }
        else if (MisteryBoxItemTutorial.isReturn && animationFinished)
        {

            canvasItem.sprite = imageReturn;
            canvasItem.enabled = true;
            imageChanged = 5;
            animationFinished = false;

        }
        else if (MisteryBoxItemTutorial.isMoneyDrainer && animationFinished)
        {
            canvasItem.sprite = imageMonezDrainer;
            canvasItem.enabled = true;
            imageChanged = 6;
            animationFinished = false;
            Debug.LogWarning("is in money");

        }
        else if (MisteryBoxItemTutorial.isShieldBall && animationFinished)
        {
            canvasItem.sprite = imageShieldBall;
            canvasItem.enabled = true;
            imageChanged = 7;
            animationFinished = false;

            Debug.LogWarning("is in shield");




        }
        else if (MisteryBoxItemTutorial.isHPminus && animationFinished)
        {
            canvasItem.sprite = imageHpMinus;
            canvasItem.enabled = true;
            imageChanged = 8;
            animationFinished = false;
        }
    }

    /*void OnGUI()
    {

      GUI.TextField(new Rect(200, 200, 200, 200), "message1: " +message+"\n message 2: "+message2);

    }*/
}
