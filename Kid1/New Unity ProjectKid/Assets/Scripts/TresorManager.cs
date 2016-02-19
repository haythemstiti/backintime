using UnityEngine;
using System.Collections;

public class TresorManager : MonoBehaviour
{

    private GameObject imageTresor1KidColor, imageTresor2KidColor, imageTresor3KidColor, imageTresor1ParentColor, imageTresor2ParentColor, imageTresor3ParentColor;
    void Start()
    {
        imageTresor1KidColor = GameObject.Find("imageTresor1KidColor");
        imageTresor2KidColor = GameObject.Find("imageTresor2KidColor");
        imageTresor3KidColor = GameObject.Find("imageTresor3KidColor");
        imageTresor1ParentColor = GameObject.Find("imageTresor1ParentColor");
        imageTresor2ParentColor = GameObject.Find("imageTresor2ParentColor");
        imageTresor3ParentColor = GameObject.Find("imageTresor3ParentColor");

        imageTresor1KidColor.SetActive(false);
        imageTresor2KidColor.SetActive(false);
        imageTresor3KidColor.SetActive(false);

        imageTresor1ParentColor.SetActive(false);
        imageTresor2ParentColor.SetActive(false);
        imageTresor3ParentColor.SetActive(false);

    }
    void Update()
    {
        switch (ScoreCounter.scoreChild)
        {
            case 1:
                imageTresor1KidColor.SetActive(true);

                imageTresor2KidColor.SetActive(false);
                imageTresor3KidColor.SetActive(false);
                break;
            case 2:
                imageTresor1KidColor.SetActive(true);
                imageTresor2KidColor.SetActive(true);

                imageTresor3KidColor.SetActive(false);
                break;
            case 3:
                imageTresor3KidColor.SetActive(true);
                imageTresor2KidColor.SetActive(true);
                imageTresor1KidColor.SetActive(true);
                break;
        }

        switch (ScoreCounter.scoreParent)
        {
            case 1:
                imageTresor1ParentColor.SetActive(true);

                imageTresor2ParentColor.SetActive(false);
                imageTresor3ParentColor.SetActive(false);
                break;
            case 2:
                imageTresor1ParentColor.SetActive(true);
                imageTresor2ParentColor.SetActive(true);

                imageTresor3ParentColor.SetActive(false);

                break;
            case 3:
                imageTresor1ParentColor.SetActive(true);
                imageTresor2ParentColor.SetActive(true);
                imageTresor3ParentColor.SetActive(true);
                break;
        }
    }
}
