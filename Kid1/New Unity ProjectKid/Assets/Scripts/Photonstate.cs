using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Photonstate : Photon.MonoBehaviour
{

    // Use this for initialization
    public GameObject Character, CharacterSpawningPos;
    private bool CharacterSpawned = false;
    public int Money = 1000;
    public Text moneyText;
    public bool SpawnMonster = false;
    public string CubeName = "";
    public int MonsterType = 0;
    public GameObject Monster1, Monster2, Monster3, Fire;
    private GameObject monster;
    private CubeNumber cubeScript;
    public static bool playing;
    private AudioSource itemSource;
    public AudioClip boxClip;
    public Canvas CanvasWaiting;
    private GameObject canvasBest;
    private GameObject secCamera;
    public static int counter;
    public static bool counterChanged,playerStateChanged,movingChanged;
    public static bool jump, attack, shield, turn;
    public static bool canMove;
    public static Vector3 pos;
    public static int lifePlayer;
    public static bool lifeChanged;
    public static bool destroMonsterLife;
    public static int numberMonsterLife;
    public static int typeMonsterLife;
    public static bool monsterLifeChanged;
    public static bool moneyChanged;
    public static bool finishChanged;
    public static bool kidVictory;
    public static bool itemChanged;
    public static string item;
    public GameObject particlePuff;
    public static bool posChanged;
    private bool paused = false;
    private GameObject canvasPause;
    private bool test = false;
   
    // Use this for initialization
    void Start()
    {

        if (!PhotonNetwork.connected)
        {
            PhotonNetwork.isMessageQueueRunning = false;
            PhotonNetwork.automaticallySyncScene = true;
            PhotonNetwork.ConnectUsingSettings("backintime");
        }
        PhotonNetwork.playerName = PlayerPrefs.GetString("playerName", "Guest" + UnityEngine.Random.Range(1, 9999));
        itemSource = GetComponent<AudioSource>();
        canvasBest = GameObject.Find("CanvasBestOf5");
        canvasBest.GetComponent<Canvas>().enabled = false;
        canvasPause = GameObject.Find("CanvasPause");
        canvasPause.GetComponent<Canvas>().enabled = false;
        secCamera = GameObject.Find("SecondaryCamera");
        counter = 1;
        jump = false;
        attack = false;
        shield = false;
        turn = false;
        counterChanged = false;
        playerStateChanged = false;
        canMove = false;
        lifeChanged = false;
        lifePlayer = 0;
        destroMonsterLife = false;
        numberMonsterLife = 0;
        typeMonsterLife = 0;
        monsterLifeChanged = false;
        finishChanged = false;
        kidVictory = false;
        itemChanged = false;
        item = "";
        posChanged = false;

    }

   
    void Update()
    {

        if (PhotonNetwork.room != null)
        {
            if (PhotonNetwork.room.playerCount == 2 && CharacterSpawned && !test)
            {
                Debug.Log("two players");
                Instantiate(Character, CharacterSpawningPos.transform.position, Quaternion.identity);
                photonView.RPC("SpawnPlayer", PhotonTargets.Others);
                CharacterSpawned = false;
                CanvasWaiting.GetComponent<Canvas>().enabled = false;
                Destroy(secCamera);
                test = true;
            }
            if (!CharacterSpawned && !test)
            {
                Debug.Log("photon kid");
                photonView.RPC("Spawn", PhotonTargets.Others);
            }
        }
            if (counterChanged)
            {
                photonView.RPC("CubeCounter", PhotonTargets.Others, counter);
                counterChanged = false;
            }
            if (playerStateChanged)
            {
                photonView.RPC("CharacterState", PhotonTargets.Others, jump,attack,shield,turn);
                playerStateChanged = false;
            }
            if (movingChanged)
            {
                photonView.RPC("CanMove", PhotonTargets.Others,canMove);
                movingChanged = false;
            }
            if (lifeChanged)
            {
                photonView.RPC("SendLifePlayer", PhotonTargets.Others, lifePlayer);
                lifeChanged = false;
            }
            if (monsterLifeChanged)
            {
                photonView.RPC("SendMonsterLife", PhotonTargets.Others, destroMonsterLife, numberMonsterLife, typeMonsterLife);
                monsterLifeChanged = false;
            }
            if (moneyChanged)
            {
                photonView.RPC("SendMoney", PhotonTargets.Others);
                moneyChanged = false;
            }
            if (finishChanged)
            {
                photonView.RPC("SendLevelFinished", PhotonTargets.Others, kidVictory);
                finishChanged = false;
            }
            if (itemChanged)
            {
                photonView.RPC("SendItem", PhotonTargets.Others, item);
                itemChanged = false;
            }
            if (posChanged)
            {
                photonView.RPC("SendPlayerPosition", PhotonTargets.Others, pos);
                posChanged = false;
            }
            if (paused)
            {
                Time.timeScale = 0f;
                canvasPause.GetComponent<Canvas>().enabled = true;
            }
            else
            {
                Time.timeScale = 1f;
                canvasPause.GetComponent<Canvas>().enabled = false;
            }

        
        //new photon
        /*
        if (DemoGame.getInstance().State == ClientState.JoinedLobby && DemoGame.getInstance().State != ClientState.Joined)
        {
            JoinRoom();

        }
        else if (DemoGame.getInstance().State != ClientState.JoinedLobby)
        {
            DemoGame.getInstance().OpJoinLobby(TypedLobby.Default);
        }
        if (DemoGame.getInstance().CurrentRoom.PlayerCount == 2 && CharacterSpawned)
        {
            Instantiate(Character, CharacterSpawningPos.transform.position, Quaternion.identity);
            DemoGame.getInstance().SpawnCharacter();
            CharacterSpawned = false;
            CanvasWaiting.GetComponent<Canvas>().enabled = false;
            Destroy(secCamera);

        }
         * */
        if (SpawnMonster)
        {
            SpawnMonster = false;
            switch (MonsterType)
            {
                case 1: monster = Instantiate(Monster1, GameObject.Find("" + CubeName).transform.position, Quaternion.Euler(new Vector3(90f, transform.rotation.y, transform.rotation.z))) as GameObject;
                    Debug.Log("name:" + monster.gameObject.name);
                    cubeScript = monster.GetComponent<CubeNumber>();
                    cubeScript.cubeNumber = int.Parse(CubeName.Substring(4, 1));
                    if (cubeScript == null)
                    {
                        Debug.Log("again cube script is null");
                    }
                    break;
                case 2: monster = Instantiate(Monster2, GameObject.Find("" + CubeName).transform.position, Quaternion.Euler(new Vector3(90f, transform.rotation.y, transform.rotation.z))) as GameObject;
                    cubeScript = monster.GetComponent<CubeNumber>();
                    cubeScript.cubeNumber = int.Parse(CubeName.Substring(4, 1));
                    break;
                case 3: monster = Instantiate(Monster3, GameObject.Find("" + CubeName).transform.position, Quaternion.Euler(new Vector3(90f, transform.rotation.y, transform.rotation.z))) as GameObject;
                    //     monster.GetComponent<CubeNumber>().cubeNumber = int.Parse(CubeName.Substring(4, 1));
                    cubeScript = monster.GetComponent<CubeNumber>();
                    cubeScript.cubeNumber = int.Parse(CubeName.Substring(4, 1));
                    break;
                case 4: monster = Instantiate(Fire, GameObject.Find("" + CubeName).transform.position, Quaternion.Euler(new Vector3(90f, transform.rotation.y, transform.rotation.z))) as GameObject;
                    break;

            }
            switch (CubeName)
            {
                case "Cube1": monster.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 180f, transform.rotation.z)); break;
                case "Cube2": monster.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 90f, transform.rotation.z)); break;
                case "Cube3": monster.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 180f, transform.rotation.z)); break;
                case "Cube4": monster.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 270f, transform.rotation.z)); break;
                case "Cube5": monster.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 180f, transform.rotation.z)); break;
                case "Cube6": monster.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 90f, transform.rotation.z)); break;
                case "Cube7": monster.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 180f, transform.rotation.z)); break;
                case "Cube8": monster.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 270f, transform.rotation.z)); break;
                case "Cube9": monster.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 0f, transform.rotation.z)); break;
                case "Cube10": monster.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 90f, transform.rotation.z)); break;
                case "Cube11": monster.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 0f, transform.rotation.z)); break;
                default:
                    break;
            }
            Instantiate(particlePuff, GameObject.Find("" + CubeName).transform.position, Quaternion.identity);

        }
        moneyText.text = Money + "";

        if (playing)
        {
            playing = false;
            itemSource.PlayOneShot(boxClip);
        }

    }

    void OnJoinedLobby()
    {
        StartGame();
    }


    public void StartGame()
    {
        
        PhotonNetwork.JoinOrCreateRoom(AltarOFEldersKid.roomName, new RoomOptions() { isVisible = false, maxPlayers = 2 }, TypedLobby.Default);
       
    }

    public void MainMenu()
    {
        PhotonNetwork.Disconnect();
        Application.LoadLevel("menu2");
    }

    [RPC]
    void SpawnPlayer()
    {
        
    }

    [RPC]
    void CubeCounter(int count)
    {

    }

    [RPC]
    void CharacterState(bool jump, bool attack, bool shield, bool turn)
    {

    }

    [RPC]
    void CanMove(bool canmove)
    {

    }

    [RPC]
    void SpawnMonsters(string cubename, int monstertype)
    {
        SpawnMonster = true;
        CubeName = cubename;
        MonsterType = monstertype;
    }

    [RPC]
    void SendLifePlayer(int life)
    {

    }

    [RPC]
    void SendMonsterLife(bool destroy, int number, int type)
    {

    }
    [RPC]
    void SendMoney()
    {

    }

    [RPC]
    void SendMoney2(int money)
    {
        Money = money;
    }

    [RPC]
    void SendSpawnBall(bool spawn, int type, Vector3 pos)
    {
        GameObject.Find("Code").GetComponent<CanonBallControl>().SpawnBall = spawn;
        GameObject.Find("Code").GetComponent<CanonBallControl>().ballType = type;
        GameObject.Find("Code").GetComponent<CanonBallControl>().moveTo = pos;
    }

    [RPC]
    void SendLevelFinished(bool kidvictory)
    {

    }

    [RPC]
    void SendItem(string item)
    {

    }

    [RPC]
    void Spawn()
    {
        CharacterSpawned = true;
    }

    [RPC]
    void SendPlayerPosition(Vector3 pos)
    {

    }

    [RPC]
    void SendPause()
    {
        paused = !paused;

    }


    void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }
}
