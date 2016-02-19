using UnityEngine;
using System.Collections;

public class AnimationTransition : MonoBehaviour
{

    public static Animator anim;
    public static bool animationPlaying;
    private float animTime = 0f;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        animationPlaying = false;
        animTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (animationPlaying)
        {
            animTime += Time.deltaTime;

        }
        if (animTime > 1.5f)
        {
            animationPlaying = false;
            animTime = 0f;
            anim.SetBool("AnimationChanging", false);
            SwitchItemMisteryBox.animationFinished = true;
            CharacterStrollingKid.canMove = true;
            Photonstate.canMove = true;
            Photonstate.movingChanged = true;
            //new photon
            //     DemoGame.getInstance().SendCanMove(true);
        }
    }


}
