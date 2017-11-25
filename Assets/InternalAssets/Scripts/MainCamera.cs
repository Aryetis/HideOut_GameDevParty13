using UnityEngine;
using UnityEngine.UI;

public class MainCamera : MonoBehaviour {

	public PlayerCamera camera1;
	public PlayerCamera camera2;
	public PlayerCamera camera3;
	public PlayerCamera camera4;

	public RectTransform splitScreensRoot;

	private int numberOfPlayers;

	private Camera cam;

	private void Awake() {
		cam = GetComponent<Camera>();
		numberOfPlayers = 0;
		if (camera1 != null) {
			numberOfPlayers++;
		}
		if (camera2 != null) {
			numberOfPlayers++;
		}
		if (camera3 != null) {
			numberOfPlayers++;
		}
		if (camera4 != null) {
			numberOfPlayers++;
		}
	}

	private void Start() {
		int pcamWidth = cam.pixelWidth / 2;
		int pcamHeight = cam.pixelHeight / 2;
		camera1.Init(pcamWidth, pcamHeight);
		camera2.Init(pcamWidth, pcamHeight);
		camera3.Init(pcamWidth, pcamHeight);
		camera4.Init(pcamWidth, pcamHeight);
		CreateUIScreens();
	}

	private void CreateUIScreens() {
		CreateUIScreen("Screen1", 0f, .5f, .5f, 1f, camera1.targetMat);
		CreateUIScreen("Screen2", .5f, 1f, .5f, 1f, camera2.targetMat);
		CreateUIScreen("Screen3", 0f, .5f, 0f, .5f, camera3.targetMat);
		CreateUIScreen("Screen4", .5f, 1f, 0f, .5f, camera4.targetMat);
	}

	private GameObject CreateUIScreen(string name, float xmin, float xmax, float ymin, float ymax, Material mat) {
		GameObject go = new GameObject();
		go.transform.SetParent(splitScreensRoot);
		go.name = name;
		RectTransform rect = go.AddComponent<RectTransform>();
		rect.anchorMin = new Vector2(xmin, ymin);
		rect.anchorMax = new Vector2(xmax, ymax);
		float width = xmax - xmin;
		float height = ymax - ymin;
		rect.offsetMin = Vector2.zero;
		rect.offsetMax = Vector2.zero;
		RawImage img = go.AddComponent<RawImage>();
		img.material = mat;
		return go;
	}

}
