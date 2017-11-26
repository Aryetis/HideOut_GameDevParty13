using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinningManager : MonoBehaviour {
	private GameObject playersFolder;
	private List<GameObject> activePlayersList;

	public GameObject winUi;
	private bool hasWon = false;

	// Use this for initialization
	void Start() {
		playersFolder = GameObject.Find("PlayersFolder");

		activePlayersList = new List<GameObject>();
		foreach (Transform t in playersFolder.transform)
			if (t.gameObject.activeSelf)
				activePlayersList.Add(t.gameObject);
	}

	// Update is called once per frame
	void Update() {
		if (hasWon) return;
		for (int i = 0; i < activePlayersList.Count; i++) {
			if (activePlayersList[i].activeSelf == false) {
				activePlayersList.RemoveAt(i);
				i--;
			}

			if (activePlayersList.Count <= 1) {
				Time.timeScale = 0.00000000000000000001f;
				winUi.SetActive(true);
				StartCoroutine(BackToMainMenu());
				hasWon = true;
			}
		}
	}

	public IEnumerator BackToMainMenu() {
		yield return new WaitForSecondsRealtime(5f);
		Time.timeScale = 1f;
		Destroy(GameObject.Find("PlayersFolder"));
		Destroy(GameObject.Find("JoystickManager"));
		Destroy(GameObject.Find("SoundManager"));
		SceneManager.LoadScene("MainMenu");
	}
}
