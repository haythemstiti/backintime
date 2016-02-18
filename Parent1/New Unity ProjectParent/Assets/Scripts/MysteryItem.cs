using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MysteryItem : MonoBehaviour {


    public static string Item;
    public static bool executed;
    public Image ItemImage;
    public Sprite none,fire, ice, electricty, hpminus, hpplus, shield, moneydrainer;
	// Use this for initialization
	void Start () {
        Item = "None";
        executed = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Item.Equals("Money Drainer") && !executed)
        {
            executed = true;
            if (MoneyCount.Money > 200)
                MoneyCount.Money -= 200;
            else
                MoneyCount.Money = 0;
        }
        else if (Item.Equals("Fire"))
        {
            ItemImage.sprite = fire;
        }
        else if (Item.Equals("Ice"))
        {
            ItemImage.sprite = ice;
        }
        else if (Item.Equals("Electricity"))
        {
            ItemImage.sprite = electricty;
        }
        else if (Item.Equals("Is Return"))
        {
            ItemImage.sprite = hpplus;
        }
        else if (Item.Equals("Shield"))
        {
            ItemImage.sprite = shield;
        }
        else if (Item.Equals("Hp Minus"))
        {
            ItemImage.sprite = hpminus;
        }
        else if (Item.Equals("None"))
        {
            ItemImage.sprite = none;
        }
	}
}
