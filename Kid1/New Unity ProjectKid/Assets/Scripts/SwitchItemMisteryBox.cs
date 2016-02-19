using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SwitchItemMisteryBox : MonoBehaviour
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
    public static GameObject ice;
    public static GameObject player;
    public static string message = "empty";
    public static string message2 = "empty2";
    private bool soundplayed;
    public AudioClip moneyClip, hpminusClip, fireClip, iceClip, joyClip,electrictyClip;
    private AudioSource itemSource;



    void Start()
    {
        canvasItem = GetComponent<Image>();
        canvasItem.enabled = false;
        isDefault = false;
        itemSource = GetComponent<AudioSource>();

    }

    void Update()
    {
        if (AnimationTransition.animationPlaying)
        {
            imageAnimation.enabled = true;
        }
        else
        {
            imageAnimation.enabled = false;
        }
        if (isDefault)
        {
            Debug.LogWarning("is in default");
            imageChanged = 1;
            canvasItem.enabled = false;
            GameObject.Find("Shield").GetComponent<MeshRenderer>().enabled = false;
            Destroy(fire);
            Destroy(electricity);
            Destroy(ice);
            Photonstate.itemChanged = true;
            Photonstate.item = "None";
            //new photon
            //DemoGame.getInstance().SendItem("None");
            Debug.Log("Default");
            soundplayed = false;

        }
        else if (MisteryBoxWeapon.isIce && animationFinished)
        {
            canvasItem.sprite = imageIce;
            canvasItem.enabled = true;
            imageChanged = 2;
            animationFinished = false;
            ice.transform.SetParent(player.transform, false);
            Photonstate.itemChanged = true;
            Photonstate.item = "Ice";
            //new photon
            //DemoGame.getInstance().SendItem("Ice");
            message = "ice";
            Debug.Log("Ice");
            itemSource.PlayOneShot(iceClip);

        }
        else if (MisteryBoxWeapon.isFire && animationFinished)
        {
            canvasItem.sprite = imageFire;
            canvasItem.enabled = true;
            imageChanged = 3;
            animationFinished = false;
            fire.transform.SetParent(player.transform, false);
            Photonstate.itemChanged = true;
            Photonstate.item = "Fire";
            //new photon
            //DemoGame.getInstance().SendItem("Fire");
            Debug.Log("Fire");
            itemSource.PlayOneShot(fireClip);

        }
        else if (MisteryBoxWeapon.isElectricity && animationFinished)
        {
            canvasItem.sprite = imageElectricity;
            canvasItem.enabled = true;
            imageChanged = 4;
            animationFinished = false;
            electricity.transform.SetParent(player.transform, false);
            Photonstate.itemChanged = true;
            Photonstate.item = "Electricity";
            //new photon
            //DemoGame.getInstance().SendItem("Electricity");
            Debug.Log("Electricity");
            itemSource.PlayOneShot(electrictyClip);
        }
        else if (MisteryBoxItem.isReturn && animationFinished)
        {

            canvasItem.sprite = imageReturn;
            canvasItem.enabled = true;
            imageChanged = 5;
            animationFinished = false;
            LifePlayer.executed = false;
            Photonstate.itemChanged = true;
            Photonstate.item = "Is Return";
            //new photon
            //DemoGame.getInstance().SendItem("Is Return");
            message = "is return switch";
            Debug.LogWarning("is in return");
            itemSource.PlayOneShot(joyClip);

        }
        else if (MisteryBoxItem.isMoneyDrainer && animationFinished)
        {

            canvasItem.sprite = imageMonezDrainer;
            canvasItem.enabled = true;
            imageChanged = 6;
            animationFinished = false;
            Photonstate.itemChanged = true;
            Photonstate.item = "Money Drainer";
            //new photon
            //DemoGame.getInstance().SendItem("Money Drainer");
            message = "money";
            Debug.LogWarning("is in money");
            itemSource.PlayOneShot(moneyClip);


        }
        else if (MisteryBoxItem.isShieldBall && animationFinished)
        {
            canvasItem.sprite = imageShieldBall;
            canvasItem.enabled = true;
            imageChanged = 7;
            animationFinished = false;
            Photonstate.itemChanged = true;
            Photonstate.item = "Shield";
            //new photon
            //DemoGame.getInstance().SendItem("Shield");
            GameObject.Find("Shield").GetComponent<MeshRenderer>().enabled = true;
            message = "shield";
            Debug.LogWarning("is in shield");
            itemSource.PlayOneShot(joyClip);




        }
        else if (MisteryBoxItem.isHPminus && animationFinished)
        {
            canvasItem.sprite = imageHpMinus;
            canvasItem.enabled = true;
            imageChanged = 8;
            animationFinished = false;
            LifePlayer.executed = false;
            Photonstate.itemChanged = true;
            Photonstate.item = "Hp Minus";
            //new photon
            //DemoGame.getInstance().SendItem("Hp Minus");
            message = "hp minus";
            Debug.LogWarning("is in hp");
            itemSource.PlayOneShot(hpminusClip);

        }
    }

}
