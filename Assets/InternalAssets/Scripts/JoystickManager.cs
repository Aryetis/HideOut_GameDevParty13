using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class JoystickManager : MonoBehaviour
{
    public List<GameObject> playersList { get; private set; }
    private GameObject playersFolder;
    private List<GameObject> statusList;
    private bool[] joystickStatus; // false <=> unattributed joystick
    private int activePlayersNumber;
    private float TimerToStart;

	public AudioClip gameMusic;

	// Use this for initialization
	void Start ()
    {
        playersList = new List<GameObject>();
        playersFolder = GameObject.Find("PlayersFolder");

        statusList = new List<GameObject>();
        statusList.Add(GameObject.Find("Player1Status"));
        statusList.Add(GameObject.Find("Player2Status"));
        statusList.Add(GameObject.Find("Player3Status"));
        statusList.Add(GameObject.Find("Player4Status"));

        foreach(GameObject go in statusList)
            go.SetActive(false);

        joystickStatus = new bool[] {false, false, false, false, false, false, false, false, false, false, false};

        foreach(Transform t in playersFolder.transform)
        {
            playersList.Add(t.gameObject);
            t.gameObject.SetActive(false);
        }

        activePlayersNumber = 0;
        TimerToStart = 2.0f;
	}

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
	
	// Update is called once per frame
	void Update ()
    {
        /********************************************
         * ASSIGNING JOYSYICK NUMBER TO EACH PLAYER *
         ********************************************/
        if(activePlayersNumber <= 4)
        {
            if(Input.GetAxisRaw("J1_Start") > 0 && !joystickStatus[0] )
            {
                Debug.Log("KeyCode.Joystick1Button7 START PRESSED");
                statusList[activePlayersNumber].SetActive(true);
                playersList[activePlayersNumber].SetActive(true);
                playersList[activePlayersNumber].GetComponent<PlayerInputs>().SetAllowMovement(false);
                playersList[activePlayersNumber].GetComponent<PlayerInputs>().SetJoyNumber(1);
                activePlayersNumber++;
                joystickStatus[0] = true; 
            }
            if(Input.GetAxisRaw("J2_Start") > 0 && !joystickStatus[1] )
            {
                Debug.Log("KeyCode.Joystick2Button7 START PRESSED");
                statusList[activePlayersNumber].SetActive(true);
                playersList[activePlayersNumber].SetActive(true);
                playersList[activePlayersNumber].GetComponent<PlayerInputs>().SetAllowMovement(false);
                playersList[activePlayersNumber].GetComponent<PlayerInputs>().SetJoyNumber(2);
                activePlayersNumber++;
                joystickStatus[1] = true;
            }
            if(Input.GetAxisRaw("J3_Start") > 0 && !joystickStatus[2] )
            {
                Debug.Log("KeyCode.Joystick3Button7 START PRESSED");
                statusList[activePlayersNumber].SetActive(true);
                playersList[activePlayersNumber].SetActive(true);
                playersList[activePlayersNumber].GetComponent<PlayerInputs>().SetAllowMovement(false);
                playersList[activePlayersNumber].GetComponent<PlayerInputs>().SetJoyNumber(3);
                activePlayersNumber++;
                joystickStatus[2] = true; 
            }
            if(Input.GetAxisRaw("J4_Start") > 0 && !joystickStatus[3] )
            {
                Debug.Log("KeyCode.Joystick4Button7 START PRESSED");
                statusList[activePlayersNumber].SetActive(true);
                playersList[activePlayersNumber].SetActive(true);
                playersList[activePlayersNumber].GetComponent<PlayerInputs>().SetAllowMovement(false);
                playersList[activePlayersNumber].GetComponent<PlayerInputs>().SetJoyNumber(4);
                activePlayersNumber++;
                joystickStatus[3] = true;   
            }
            if(Input.GetAxisRaw("J5_Start") > 0 && !joystickStatus[4] )
            {                
                Debug.Log("KeyCode.Joystick5Button7 START PRESSED");
                statusList[activePlayersNumber].SetActive(true);
                playersList[activePlayersNumber].SetActive(true);
                playersList[activePlayersNumber].GetComponent<PlayerInputs>().SetAllowMovement(false);
                playersList[activePlayersNumber].GetComponent<PlayerInputs>().SetJoyNumber(5);
                activePlayersNumber++;
                joystickStatus[4] = true;    
            }
            if(Input.GetAxisRaw("J6_Start") > 0 && !joystickStatus[5] )
            {
                Debug.Log("KeyCode.Joystick6Button7 START PRESSED");
                statusList[activePlayersNumber].SetActive(true);
                playersList[activePlayersNumber].SetActive(true);
                playersList[activePlayersNumber].GetComponent<PlayerInputs>().SetAllowMovement(false);
                playersList[activePlayersNumber].GetComponent<PlayerInputs>().SetJoyNumber(6);
                activePlayersNumber++;
                joystickStatus[5] = true; 
            }
            if(Input.GetAxisRaw("J7_Start") > 0 && !joystickStatus[6] )
            {
                Debug.Log("KeyCode.Joystick7Button7 START PRESSED");
                statusList[activePlayersNumber].SetActive(true);
                playersList[activePlayersNumber].SetActive(true);
                playersList[activePlayersNumber].GetComponent<PlayerInputs>().SetAllowMovement(false);
                playersList[activePlayersNumber].GetComponent<PlayerInputs>().SetJoyNumber(7);
                activePlayersNumber++;
                joystickStatus[6] = true; 
            }
            if(Input.GetAxisRaw("J8_Start") > 0 && !joystickStatus[7] )
            {
                Debug.Log("KeyCode.Joystick8Button7 START PRESSED");
                statusList[activePlayersNumber].SetActive(true);
                playersList[activePlayersNumber].SetActive(true);
                playersList[activePlayersNumber].GetComponent<PlayerInputs>().SetAllowMovement(false);
                playersList[activePlayersNumber].GetComponent<PlayerInputs>().SetJoyNumber(8);
                activePlayersNumber++;
                joystickStatus[7] = true; 
            }
            if(Input.GetAxisRaw("J9_Start") > 0 && !joystickStatus[8] )
            {
                Debug.Log("KeyCode.Joystick9Button7 START PRESSED");
                statusList[activePlayersNumber].SetActive(true);
                playersList[activePlayersNumber].SetActive(true);
                playersList[activePlayersNumber].GetComponent<PlayerInputs>().SetAllowMovement(false);
                playersList[activePlayersNumber].GetComponent<PlayerInputs>().SetJoyNumber(9);
                activePlayersNumber++;
                joystickStatus[8] = true; 
            }
            if(Input.GetAxisRaw("J10_Start") > 0 && !joystickStatus[9] )
            {
                Debug.Log("KeyCode.Joystick10Button7 START PRESSED");
                statusList[activePlayersNumber].SetActive(true);
                playersList[activePlayersNumber].SetActive(true);
                playersList[activePlayersNumber].GetComponent<PlayerInputs>().SetAllowMovement(false);
                playersList[activePlayersNumber].GetComponent<PlayerInputs>().SetJoyNumber(10);
                activePlayersNumber++;
                joystickStatus[9] = true; 
            }
            if(Input.GetAxisRaw("J11_Start") > 0 && !joystickStatus[10] )
            {
                Debug.Log("KeyCode.Joystick11Button7 START PRESSED");
                statusList[activePlayersNumber].SetActive(true);
                playersList[activePlayersNumber].SetActive(true);
                playersList[activePlayersNumber].GetComponent<PlayerInputs>().SetAllowMovement(false);
                playersList[activePlayersNumber].GetComponent<PlayerInputs>().SetJoyNumber(11);
                activePlayersNumber++;
                joystickStatus[10] = true; 
            }

        }

        if (Input.GetButton("JALL_Start") || Input.GetKey(KeyCode.Return)) 
        {
            TimerToStart -= Time.deltaTime;
		}

		if (Input.GetButtonUp("JALL_Start"))
        {
			TimerToStart = 2.0f;
		}

		/*****************************
         * HOLD START TO LAUNCH GAME *
         *****************************/
		if (TimerToStart <= 0 && SceneManager.GetActiveScene().name == "PlayersSelectionScene")
        {
			//SceneManager.LoadScene("SonarTestScene");
			//SceneManager.LoadScene("ControllerTestScene");
			SceneManager.LoadScene("MainGame");
			SoundManager.I.musicSource.Stop();
			SoundManager.I.musicSource.clip = gameMusic;
			SoundManager.I.musicSource.Play();
		}
			
	}
}
