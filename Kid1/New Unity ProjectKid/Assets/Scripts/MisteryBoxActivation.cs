using UnityEngine;
using System.Collections;

public class MisteryBoxActivation : MonoBehaviour
{

    public GameObject msBoxChoice;
    private GameObject msboxC;
    private float z;
    private Renderer renderer;
   
    void Start()
    {
        renderer = GetComponent<Renderer>();
        
    }

    void Update()
    {
        if (CharacterStrollingKid.canMove)
        {
            renderer.enabled = true;
        }
        else
        {
            renderer.enabled = false;
        }

    }



    void OnTriggerEnter(Collider other)
    {

        msboxC = Instantiate(msBoxChoice, new Vector3(transform.localPosition.x + 1, transform.localPosition.y + 3, transform.localPosition.z), Quaternion.identity) as GameObject;

        CharacterStrollingKid.canMove = false;
        Photonstate.canMove = false;
        Photonstate.movingChanged = true;
        //new photon
        //DemoGame.getInstance().SendCanMove(false);
        SwitchItemMisteryBox.isDefault = true;
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
        Photonstate.playing = true;
        Destroy(gameObject);
    }





}
