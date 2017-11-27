using UnityEngine;
using UnityEngine.UI;

public class MainCamera : MonoBehaviour {

	public PlayerCamera[] cameras;
	private int countX = 2;
	private int countY = 2;

	public RectTransform splitScreensRoot;
	public GameObject horizBar;
	public GameObject vertBar;

	public int numberOfPlayers = 0;

	private Camera cam;

	private void Awake() {
		PlayerFolderBehavior playerFolder = FindObjectOfType<PlayerFolderBehavior>();
		foreach (Transform child in playerFolder.transform) {
			if (child.gameObject.activeSelf) {
				numberOfPlayers++;
			}
		}
		Debug.Log(numberOfPlayers);
		cam = GetComponent<Camera>();
		countX = (numberOfPlayers == 1) ? 1 : 2;
		countY = (numberOfPlayers <= 2) ? 1 : 2;
	}

	private void Start() {
		int pcamWidth = cam.pixelWidth / countX;
		int pcamHeight = cam.pixelHeight / countY;
		for (int i = 0; i < numberOfPlayers; i++) {
			cameras[i].Init(pcamWidth, pcamHeight);
		}
		CreateUIScreens();
	}

	private void CreateUIScreens() {
		if (countX == 1) {
			vertBar.SetActive(false);
		}
		if (countY == 1) {
			horizBar.SetActive(false);
		}
		float width = 1f / countX;
		float height = 1f / countY;
		for (int i = 0; i < numberOfPlayers; i++) {
			float posX = ((countX != 1) ? i % countX : 0) * width;
			float posY = 1 - ((countY != 1) ? i / countY : 0) * width;
			CreateUIScreen("Screen" + i, posX, posX + width, posY - height, posY, cameras[i].targetMat);
		}
	}

	private GameObject CreateUIScreen(string name, float xmin, float xmax, float ymin, float ymax, Material mat) {
		GameObject go = new GameObject();
		go.transform.SetParent(splitScreensRoot);
		go.name = name;
		RectTransform rect = go.AddComponent<RectTransform>();
		rect.anchorMin = new Vector2(xmin, ymin);
		rect.anchorMax = new Vector2(xmax, ymax);
		rect.offsetMin = Vector2.zero;
		rect.offsetMax = Vector2.zero;
		RawImage img = go.AddComponent<RawImage>();
		img.material = mat;
		return go;
	}

}
