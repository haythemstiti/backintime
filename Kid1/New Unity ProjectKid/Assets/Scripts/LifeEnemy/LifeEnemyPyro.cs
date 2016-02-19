using UnityEngine;
using System.Collections;

public class LifeEnemyPyro : MonoBehaviour
{

    public int life = 8;
    public GameObject particleHit;
    public GameObject particleDestroy;
    Vector3 realPosition = Vector3.zero;
    Quaternion realRotation = Quaternion.identity;
    private CubeNumber cubeScript = null;
    void Start()
    {
        cubeScript = GetComponent<CubeNumber>();
    }

    void Update()
    {
        

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag.Equals("sword"))
        {
            VibrationControl.vibrate = true;
            if (life <= 0)
            {

                Instantiate(particleDestroy, transform.position, Quaternion.identity);
                CharacterStrollingKid.canMove = true;
                Photonstate.movingChanged = true;
                Photonstate.canMove = true;
                //new photon
                //DemoGame.getInstance().SendCanMove(true);
                MonsterBar.activateMonsterBar = false;
                SwitchItemMisteryBox.isDefault = true;
                if (cubeScript == null)
                {
                    Debug.Log("cubeScript is null");
                }
                Photonstate.monsterLifeChanged = true;
                Photonstate.destroMonsterLife = true;
                Photonstate.numberMonsterLife = cubeScript.cubeNumber;
                Photonstate.typeMonsterLife = 1;
                //new photon
                //DemoGame.getInstance().SendMonsterLife(true, cubeScript.cubeNumber,1);
                VibrationControl.vibrate = false;
                Destroy(gameObject);
            }
            else
            {



                
                if (MisteryBoxWeapon.isIce)
                {
                    life -= 8;
                    MonsterBar.activateMonsterBar = true;
                    MonsterBar.eb.valueCurrent -= 8;
                    MonsterBar.eb.valueMax = 8;
                    Instantiate(particleHit, transform.position, Quaternion.identity);
                    Photonstate.moneyChanged = true;
                    //new photon
                    //DemoGame.getInstance().SendMony();
                }
                else
                {
                    Instantiate(particleHit, transform.position, Quaternion.identity);
                    Photonstate.moneyChanged = true;
                  //new photon
                    // DemoGame.getInstance().SendMony();
                    life -= 1;
                    MonsterBar.activateMonsterBar = true;
                    MonsterBar.eb.valueCurrent -= 1;
                    MonsterBar.eb.valueMax = 8;
                }

            }
        }



    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("sword"))
        {
            VibrationControl.vibrate = false;
        }
    }


}
