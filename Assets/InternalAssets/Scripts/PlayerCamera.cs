using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

	public Transform player;
	[Tooltip("Keep at Zero to use offset calculated at start")]
	public Vector3 offset;
	public Material targetMat;

	private Camera cam;
	private RenderTexture renderTexture;

	private void Awake() {
		if (offset == Vector3.zero) {
			offset = transform.position - player.position;
		}
		cam = GetComponent<Camera>();
		cam.depth = -10;
	}

	public void Init(int width, int height) {
		renderTexture = new RenderTexture(width, height, 16);
		cam.targetTexture = renderTexture;
		targetMat.SetTexture("_MainTex", renderTexture);
	}

	private void LateUpdate() {
		transform.position = player.position + offset;
	}

	private void OnDestroy() {
		renderTexture.DiscardContents();
		renderTexture.Release();
	}

}
