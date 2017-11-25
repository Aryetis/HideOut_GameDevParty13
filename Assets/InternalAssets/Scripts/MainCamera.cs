using UnityEngine;

public class MainCamera : MonoBehaviour {

	public PlayerCamera camera1;
	public PlayerCamera camera2;
	public PlayerCamera camera3;
	public PlayerCamera camera4;

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
	}

}
