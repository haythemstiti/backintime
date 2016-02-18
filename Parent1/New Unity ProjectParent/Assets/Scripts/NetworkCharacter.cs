using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NetworkCharacter : MonoBehaviour
{
    public GameObject camera;
    public GameObject monster1, monster2, monster3, fire, player, m1, m2, m3;
    private SpawnObjects sp;
    public GameObject particle;
    private bool clickedMonster = false;
    private bool clickedFire = false;
    public bool containsMonster = false;
    private bool containsFire = false;
    private int monsterSpawned = 0;
    private int x = 0;
    private static float coolDownP, coolDownF, coolDownE;
    private static  bool canSpawnPyro = true;
    private static  bool canSpawnFreezer = true;
    private static  bool canSpawnElectronite = true;
    private int cooldownP,cooldownF,cooldownE;

    private GameObject FilledBarPyro, FilledBarFreezer, FilledBarElectronite, FilledBarFire;
    private EnergyBar ebPyro, ebFreezer, ebElectronite, ebFire;
    private CubeNumber cubeScript;
    void Start()
    {

        sp = camera.GetComponent<SpawnObjects>();
        canSpawnPyro = true;
        canSpawnFreezer = true;
        canSpawnElectronite = true;

        FilledBarPyro = GameObject.Find("FilledBarPyro");
        ebPyro = FilledBarPyro.GetComponent<EnergyBar>();
        ebPyro.valueMax = 30;

        FilledBarFreezer = GameObject.Find("FilledBarFreezer");
        ebFreezer = FilledBarFreezer.GetComponent<EnergyBar>();
        ebFreezer.valueMax = 10;

        FilledBarElectronite = GameObject.Find("FilledBarElectronite");
        ebElectronite = FilledBarElectronite.GetComponent<EnergyBar>();
        ebElectronite.valueMax = 20;

        

    }

    void FixedUpdate()
    {
        if (!canSpawnPyro && containsMonster)
        {
            coolDownP += Time.fixedDeltaTime;
            ebPyro.valueCurrent = (int)coolDownP;
        }
        cooldownP = (int)coolDownP;
        if (cooldownP >= 30 && containsMonster)
        {
            canSpawnPyro = true;
            coolDownP = 0f;
            cooldownP = 0;
        }

        if (!canSpawnFreezer && containsMonster)
        {
            coolDownF += Time.fixedDeltaTime;

            ebFreezer.valueCurrent = (int)coolDownF;
        }
        cooldownF = (int)coolDownF;
        if (cooldownF >= 10 && containsMonster)
        {
            canSpawnFreezer = true;
            coolDownF = 0f;
            cooldownF = 0;
        }

        if (!canSpawnElectronite && containsMonster)
        {
            coolDownE += Time.fixedDeltaTime;
            ebElectronite.valueCurrent = (int)coolDownE;
        }
        cooldownE = (int)coolDownE;
        if (cooldownE >= 20 && containsMonster)
        {
            canSpawnElectronite = true;
            cooldownE = 0;
            coolDownE = 0f;
        }
        SpawnMonsters();
    }

    void Update()
    {
        


    }

   

    void OnMouseDown()
    {
        if (gameObject.tag.Equals("cubeMonster"))
        {
            clickedMonster = true;
        }
        else if (gameObject.tag.Equals("cubeFire"))
        {
            clickedFire = true;
        }
    }


    void SpawnMonsters()
    {
        
            if (clickedMonster && !containsMonster)
            {
                if (sp.monsterClicked1 && gameObject.tag.Equals("cubeMonster") && MoneyCount.Money >= 150)
                {
                    if (canSpawnPyro)
                    {
                            monster2 = Instantiate(m1, transform.position, Quaternion.Euler(new Vector3(90f, transform.rotation.y, transform.rotation.z))) as GameObject;
                            switch (gameObject.name)
                            {
                                case "Cube1": monster2.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 180f, transform.rotation.z)); break;
                                case "Cube2": monster2.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 90f, transform.rotation.z)); break;
                                case "Cube3": monster2.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 180f, transform.rotation.z)); break;
                                case "Cube4": monster2.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 270f, transform.rotation.z)); break;
                                case "Cube5": monster2.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 180f, transform.rotation.z)); break;
                                case "Cube6": monster2.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 90f, transform.rotation.z)); break;
                                case "Cube7": monster2.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 180f, transform.rotation.z)); break;
                                case "Cube8": monster2.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 270f, transform.rotation.z)); break;
                                case "Cube9": monster2.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 0f, transform.rotation.z)); break;
                                case "Cube10": monster2.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 90f, transform.rotation.z)); break;
                                case "Cube11": monster2.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 0f, transform.rotation.z)); break;
                                default:
                                    break;
                            }
                            PhotonState.spawnMonster = true;
                            PhotonState.cubeName = gameObject.name;
                            PhotonState.monsterType = 1;
                        //new photon
                       //     DemoGame.getInstance().SendSpawnMonster(gameObject.name, 1);
                            cubeScript = monster2.GetComponent<CubeNumber>();
                            cubeScript.cubeNumber = int.Parse(gameObject.name.Substring(4, 1));
                            containsMonster = true;
                            MoneyCount.Money -= 150;
                            canSpawnPyro = false;
                            Instantiate(particle, new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z), Quaternion.identity);
                        
                        }

                }
                else if (sp.monsterClicked2 && gameObject.tag.Equals("cubeMonster") && MoneyCount.Money >= 200)
                {
                    if (canSpawnFreezer)
                    {
                       
                            monster2 = Instantiate(m2, transform.position, Quaternion.Euler(new Vector3(90f, transform.rotation.y, transform.rotation.z))) as GameObject;
                            switch (gameObject.name)
                            {
                                case "Cube1": monster2.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 180f, transform.rotation.z)); break;
                                case "Cube2": monster2.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 90f, transform.rotation.z)); break;
                                case "Cube3": monster2.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 180f, transform.rotation.z)); break;
                                case "Cube4": monster2.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 270f, transform.rotation.z)); break;
                                case "Cube5": monster2.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 180f, transform.rotation.z)); break;
                                case "Cube6": monster2.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 90f, transform.rotation.z)); break;
                                case "Cube7": monster2.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 180f, transform.rotation.z)); break;
                                case "Cube8": monster2.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 270f, transform.rotation.z)); break;
                                case "Cube9": monster2.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 0f, transform.rotation.z)); break;
                                case "Cube10": monster2.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 90f, transform.rotation.z)); break;
                                case "Cube11": monster2.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 0f, transform.rotation.z)); break;
                                default:
                                    break;
                            }
                            PhotonState.spawnMonster = true;
                            PhotonState.cubeName = gameObject.name;
                            PhotonState.monsterType = 2;
                        // new photon
                       //     DemoGame.getInstance().SendSpawnMonster(gameObject.name, 2);
                            cubeScript = monster2.GetComponent<CubeNumber>();
                            cubeScript.cubeNumber = int.Parse(gameObject.name.Substring(4, 1));
                        
                            containsMonster = true;
                            MoneyCount.Money -= 200;
                            canSpawnFreezer = false;
                           Instantiate(particle, new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z), Quaternion.identity);
                        
                    }
                }
                else if (sp.monsterClicked3 && gameObject.tag.Equals("cubeMonster") && MoneyCount.Money >= 150)
                {

                    if (canSpawnElectronite)
                    {
                        
                            monster2 = Instantiate(m3, transform.position, Quaternion.Euler(new Vector3(90f, transform.rotation.y, transform.rotation.z))) as GameObject;
                            switch (gameObject.name)
                            {
                                case "Cube1": monster2.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 180f, transform.rotation.z)); break;
                                case "Cube2": monster2.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 90f, transform.rotation.z)); break;
                                case "Cube3": monster2.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 180f, transform.rotation.z)); break;
                                case "Cube4": monster2.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 270f, transform.rotation.z)); break;
                                case "Cube5": monster2.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 180f, transform.rotation.z)); break;
                                case "Cube6": monster2.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 90f, transform.rotation.z)); break;
                                case "Cube7": monster2.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 180f, transform.rotation.z)); break;
                                case "Cube8": monster2.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 270f, transform.rotation.z)); break;
                                case "Cube9": monster2.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 0f, transform.rotation.z)); break;
                                case "Cube10": monster2.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 90f, transform.rotation.z)); break;
                                case "Cube11": monster2.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 0f, transform.rotation.z)); break;
                                default:
                                    break;
                            }
                            PhotonState.spawnMonster = true;
                            PhotonState.cubeName = gameObject.name;
                            PhotonState.monsterType = 3;
                        // new photon
                        //    DemoGame.getInstance().SendSpawnMonster(gameObject.name, 3);
                            cubeScript = monster2.GetComponent<CubeNumber>();
                            cubeScript.cubeNumber = int.Parse(gameObject.name.Substring(4, 1));
                            containsMonster = true;
                            MoneyCount.Money -= 150;
                            canSpawnElectronite = false;
                            Instantiate(particle, new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z), Quaternion.identity);
                        
                    }
                }

                clickedMonster = false;

            }
            if (clickedFire && !containsFire)
            {
                if (sp.fireClicked && gameObject.tag.Equals("cubeFire"))
                {
                    
                        monster2 = Instantiate(fire, transform.position, Quaternion.Euler(new Vector3(90f, transform.rotation.y, transform.rotation.z))) as GameObject;
                        PhotonState.spawnMonster = true;
                        PhotonState.cubeName = gameObject.name;
                        PhotonState.monsterType = 4;
                    //new photon
                    //      DemoGame.getInstance().SendSpawnMonster(gameObject.name, 4);
                        containsFire = true;
                        MoneyCount.Money -= 10;
                        Instantiate(particle, new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z), Quaternion.identity);
                    
                    }

                clickedFire = false;
            }
            
        
    }



   
}
