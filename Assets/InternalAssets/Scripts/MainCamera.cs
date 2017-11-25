using UnityEngine;
using UnityEngine.UI;

public class MainCamera : MonoBehaviour {

	public PlayerCamera[] cameras;
	public int countX = 2;
	public int countY = 2;

	public RectTransform splitScreensRoot;


	public int NumberOfPlayers {
		get {
			return cameras.Length;
		}
	}

	private Camera cam;

	private void Awake() {
		cam = GetComponent<Camera>();
	}

	private void Start() {
		int pcamWidth = cam.pixelWidth / 2;
		int pcamHeight = cam.pixelHeight / 2;
		foreach (PlayerCamera pcam in cameras) {
			pcam.Init(pcamWidth, pcamHeight);
		}
		CreateUIScreens();
	}

	private void CreateUIScreens() {
		float width = 1f / countX;
		float height = 1f / countY;
		for (int i = 0; i < cameras.Length; i++) {
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
