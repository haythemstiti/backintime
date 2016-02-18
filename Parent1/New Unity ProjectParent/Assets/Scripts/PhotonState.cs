using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class PhotonState : Photon.MonoBehaviour
{

    // Use this for initialization
    public Canvas ParentCanvas, CanvasWaiting;
    private bool SpawnCharacter = false;
    public GameObject Character, CharacterSpawningPos;
    public int LifePayer = 200;
    public Text healthText;
    public bool LevelFinished;
    public bool kidVictory;
    private GameObject canvasBest;
    private bool test = false;
    private bool incremented;
    private GameObject healthBar;
    private EnergyBar eb;
    public Text textParent, textChild;
    public static string cubeName;
    public static int monsterType;
    public static bool spawnMonster;
    public static int money;
    public static bool moneyChanged;
    public static bool ballChanged;
    public static bool spawnBall;
    public static int typeBall;
    public static Vector3 posBall;
    public static bool destroyCoin;
    private AudioSource itemSource;
    public AudioClip coinClip;
    public static bool pauseChanged;

    public GameObject btnNextRound;

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
        canvasBest = GameObject.Find("CanvasBestOf5");
        canvasBest.SetActive(false);

        healthBar = GameObject.FindGameObjectWithTag("healthbar");
        eb = healthBar.GetComponent<EnergyBar>();

        incremented = false;
        cubeName = "";
        monsterType = 0;
        spawnMonster = false;
        money = 0;
        moneyChanged = false;
        ballChanged = false;
        spawnBall = false;
        typeBall = 0;
        posBall = new Vector3(0, 0, 0);
        destroyCoin = false;
        pauseChanged = false;

        itemSource = GetComponent<AudioSource>();

        
        
    }




    void Update()
    {

        if (PhotonNetwork.room != null)
        {
            if (PhotonNetwork.room.playerCount == 2 && test)
            {
                photonView.RPC("Spawn", PhotonTargets.Others);
                test = false;
                Debug.Log("photon parent");
            }
        }
        //new photon
        /*
        if (DemoGame.getInstance().State == ClientState.JoinedLobby && DemoGame.getInstance().State != ClientState.Joined)
        {
            CreateRoom();
        }
        else if (DemoGame.getInstance().State != ClientState.JoinedLobby)
        {
            DemoGame.getInstance().OpJoinLobby(TypedLobby.Default);
        }
        if (DemoGame.getInstance().CurrentRoom.PlayerCount == 2 && !test)
        {
            DemoGame.getInstance().SpawnCharacter();
            test = true;
        }
         * */

        

        if (SpawnCharacter)
        {

            CanvasWaiting.GetComponent<Canvas>().enabled = false;
            ParentCanvas.GetComponent<Canvas>().enabled = true;
            Instantiate(Character, CharacterSpawningPos.transform.position, Quaternion.identity);
            SpawnCharacter = false;
        }


        if (LevelFinished && !incremented)
        {

            if (kidVictory)
            {
                incremented = true;
                ScoreCounter.scoreChild++;
                textChild.text = "" + ScoreCounter.scoreChild;
                textParent.text = "" + ScoreCounter.scoreParent;

                if (ScoreCounter.scoreChild >= 3)
                {
                    textChild.text = "You Win !";
                    btnNextRound.SetActive(false);
                   // btnNextRound.GetComponent<Image>().enabled = false;
                }

            }
            else
            {
                incremented = true;
                ScoreCounter.scoreParent++;
                textChild.text = "" + ScoreCounter.scoreChild;
                textParent.text = "" + ScoreCounter.scoreParent;

                if (ScoreCounter.scoreParent >= 3)
                {
                    textParent.text = "You Win !";
                    btnNextRound.SetActive(false);
                    //btnNextRound.GetComponent<Image>().enabled = false;
                }
            }

            canvasBest.SetActive(true);
        }
        if (spawnMonster)
        {
            photonView.RPC("SpawnMonsters", PhotonTargets.Others, cubeName, monsterType);
            spawnMonster = false;
        }
        eb.valueCurrent = LifePayer;
        if (moneyChanged)
        {
            photonView.RPC("SendMoney2", PhotonTargets.Others,money);
            moneyChanged = false;
        }

        if (ballChanged)
        {
            photonView.RPC("SendSpawnBall", PhotonTargets.Others, spawnBall, typeBall, posBall);
            ballChanged = false;
        }
        if (destroyCoin)
        {
            itemSource.PlayOneShot(coinClip);
            destroyCoin = false;
        }
        if (pauseChanged)
        {
            pauseChanged = false;
            photonView.RPC("SendPause", PhotonTargets.Others);
        }

    }

    void OnJoinedLobby()
    {
        StartGame();
    }

    void StartGame()
    {


        PhotonNetwork.JoinOrCreateRoom(AltarOfEldersParent.roomName, new RoomOptions() { isVisible = false, maxPlayers = 2 }, TypedLobby.Default);

    }

    void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }

    [RPC]
    void SpawnPlayer()
    {
        SpawnCharacter = true;
    }

    [RPC]
    void CubeCounter(int count)
    {
        CharacterStrollingParent.counter = count;
    }

    [RPC]
    void CharacterState(bool jump, bool attack, bool shield, bool turn)
    {
        CharacterStrollingParent.rotxOK = jump;
        CharacterStrollingParent.attack = attack;
        CharacterStrollingParent.shield = shield;
        CharacterStrollingParent.isTurning = turn;
    }

    [RPC]
    void CanMove(bool canmove)
    {
        CharacterStrollingParent.canMove = canmove;

    }

    

    [RPC]
    void SendLifePlayer(int life)
    {
        LifePayer = life;
    }

    [RPC]
    void SpawnMonsters(string cubename, int monstertype)
    {

    }

    [RPC]
    void SendMonsterLife(bool destroy, int number, int type)
    {
        GameObject.Find("Code").GetComponent<DestroyMonster>().DestroyIt = destroy;
        DestroyMonster.cubeNumber = number;
        DestroyMonster.type = type;
    }

    [RPC]
    void SendMoney()
    {
        MoneyCount.Money += 5;
    }

    [RPC]
    void SendMoney2(int money)
    {

    }

    [RPC]
    void SendSpawnBall(bool spaw, int type, Vector3 pos)
    {

    }

    [RPC]
    void SendLevelFinished(bool kidvictory)
    {
        LevelFinished = true;
        kidVictory = kidvictory;
    }

    [RPC]
    void SendItem(string item)
    {
        MysteryItem.Item = item;
        MysteryItem.executed = false;
    }

    [RPC]
    void Spawn()
    {
        test = true;
    }

    [RPC]
    void SendPlayerPosition(Vector3 pos)
    {
        CharacterStrollingParent.pos = pos;
        CharacterStrollingParent.isFighting = true;
    }

    [RPC]
    void SendPause()
    {

    }


}
