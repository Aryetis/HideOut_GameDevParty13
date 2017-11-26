using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public GameObject uiMenuRoot;

	private float pressTime = 0f;
	private float pressDuration = 3f;
	private bool firstPress = false;

	public void Awake() {
		uiMenuRoot.SetActive(false);
	}

	public void Update() {
		if (uiMenuRoot.activeSelf) {
			if (Input.GetButtonUp("JALL_Start") || Input.GetKeyUp(KeyCode.Return)) {
				if (!firstPress) {
					uiMenuRoot.SetActive(false);
				}
				firstPress = false;
			}
			if (Input.GetButton("JALL_Start") || Input.GetKey(KeyCode.Return)) {
				pressTime += Time.deltaTime;
			}
			if (pressTime > pressDuration) {
				Destroy(GameObject.Find("PlayersFolder"));
				Destroy(GameObject.Find("JoystickManager"));
				Destroy(GameObject.Find("SoundManager"));
				SceneManager.LoadScene("MainMenu");
			}
		} else {
			if (Input.GetButtonDown("JALL_Start") || Input.GetKeyDown(KeyCode.Return)) {
				uiMenuRoot.SetActive(true);
				pressTime = 0f;
				firstPress = true;
			}
		}
	}

}
