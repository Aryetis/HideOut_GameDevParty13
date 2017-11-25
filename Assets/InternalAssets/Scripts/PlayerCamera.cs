using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

	public Transform player;
	[Tooltip("Keep at Zero to use offset calculated at start")]
	public Vector3 offset;
	public Material targetMat;
	public bool isBlurActive = false;
	public Material blurEffect;
	[Range(0, 15)]
	public int blurPasses = 4;
	[Range(0, 8)]
	public int downRes = 0;

	private Camera cam;
	private RenderTexture renderTexture;
	private bool isUsed = false;

	private void Awake() {
		if (offset == Vector3.zero) {
			offset = transform.position - player.position;
		}
		cam = GetComponent<Camera>();
		cam.depth = -10;
		gameObject.SetActive(false);
	}

	public void Init(int width, int height) {
		gameObject.SetActive(true);
		isUsed = true;
		renderTexture = new RenderTexture(width, height, 16);
		cam.targetTexture = renderTexture;
		targetMat.SetTexture("_MainTex", renderTexture);
	}

	private void LateUpdate() {
		transform.position = player.position + offset;
	}

	private void OnRenderImage(RenderTexture source, RenderTexture destination) {
		if (!isBlurActive || blurEffect == null) {
			Graphics.Blit(source, destination);
			return;
		}
		RenderTexture tmp = RenderTexture.GetTemporary(source.width >> downRes, source.height >> downRes);
		Graphics.Blit(source, tmp);
		for (int i = 0; i < blurPasses; i++) {
			RenderTexture tmp2 = RenderTexture.GetTemporary(tmp.width, tmp.height);
			Graphics.Blit(tmp, tmp2, blurEffect);
			RenderTexture.ReleaseTemporary(tmp);
			tmp = tmp2;
		}
		Graphics.Blit(tmp, destination);
		RenderTexture.ReleaseTemporary(tmp);
	}

	private void OnDestroy() {
		if (!isUsed) return;
		renderTexture.DiscardContents();
		renderTexture.Release();
	}

}
