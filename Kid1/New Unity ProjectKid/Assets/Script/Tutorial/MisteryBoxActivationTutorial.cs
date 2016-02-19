using UnityEngine;
using System.Collections;

public class MisteryBoxActivationTutorial : MonoBehaviour
{

    public GameObject msBoxChoice;
    private GameObject msboxC;
    private float z;
    public static bool activateCollider;
    private BoxCollider boxCollider;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    void Update()
    {
       if (activateCollider)
        {
            boxCollider.enabled = true;
        }
        else 
        {
            boxCollider.enabled = false;
        }
    }


    void OnTriggerEnter(Collider other)
    {

        CharacterStrollingTutorial.canMove = false;
            msboxC = Instantiate(msBoxChoice, new Vector3(transform.localPosition.x + 1, transform.localPosition.y + 3, transform.localPosition.z), Quaternion.identity) as GameObject;
            MysteryBox();
            Destroy(gameObject);
    }

    void MysteryBox()
    {
        CharacterStrollingTutorial.canMove = false;
        SwitchItemMisteryBoxTutorial.isDefault = true;

        switch (gameObject.name)
        {
            case "MisteryBoxActivation": break;
            case "MisteryBoxActivation1": msboxC.transform.rotation = Quaternion.Euler(new Vector3(0f, 90f, 0f));
                msboxC.transform.position = new Vector3(25.35f, transform.localPosition.y + 3f, 25f);
                break;
            case "MisteryBoxActivation2": msboxC.transform.rotation = Quaternion.Euler(new Vector3(0f, -90f, 0f));
                msboxC.transform.position = new Vector3(23f, transform.localPosition.y + 3f, 39.5f);
                break;
            case "MisteryBoxActivation3": msboxC.transform.rotation = Quaternion.Euler(new Vector3(0f, 90f, 0f));
                msboxC.transform.position = new Vector3(38.75f, transform.localPosition.y + 3f, 45.5f);
                break;
            case "MisteryBoxActivation4": msboxC.transform.rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
                msboxC.transform.position = new Vector3(45f, transform.localPosition.y + 3f, 30.85f);
                break;
            case "MisteryBoxActivation5": msboxC.transform.rotation = Quaternion.Euler(new Vector3(0f, -90f, 0f));
                msboxC.transform.position = new Vector3(41f, transform.localPosition.y + 3f, 19f);
                break;
            default:
                break;
        }

    }



}
