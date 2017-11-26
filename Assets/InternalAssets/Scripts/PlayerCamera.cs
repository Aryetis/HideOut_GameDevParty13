using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {
	
    public class Wave {

        public Vector3 origin;
        public float distance;
        public float maxDistance;
        public float speed;
		public Color leadColor;
		public Color middleColor;
		public Color trailColor;

        public Wave(Vector3 ori, float sp, float maxDist, Color lead, Color middle, Color trail) {
            origin = ori;
            speed = sp;
            maxDistance = maxDist;
			leadColor = lead;
			middleColor = middle;
			trailColor = trail;
            distance = 0f;
        }

        public bool Update() {
            distance += speed * Time.deltaTime;
			float distancePortion = distance / maxDistance;
			if (distancePortion > .8f) {
				float fade = 1f - (distancePortion - .8f) / .2f;
				leadColor.a = fade;
				middleColor.a = fade;
				trailColor.a = fade;
			}
            if(distance > maxDistance)
            {
                return false;
            }
            return true;
        }

    }

    public static List<PlayerCamera> cameras;

	public GameObject player;
	public int playerIndex;
	[Tooltip("Keep at Zero to use offset calculated at start")]
	public Vector3 offset;
	public Material targetMat;
	public bool isBlurActive = false;
	public Material blurEffect;
	[Range(0, 15)]
	public int blurPasses = 4;
	[Range(0, 8)]
	public int downRes = 0;
    public Material sonarMat;


	private Camera cam;
	private RenderTexture renderTexture;
	private bool isUsed = false;

    private List<Wave> waves;

	private void Awake() {
        waves = new List<Wave>();
        if(cameras == null)
        {
            cameras = new List<PlayerCamera>();
        }
        cameras.Add(this);
        if (offset == Vector3.zero) {
            offset = transform.position - player.transform.position;
        }
        cam = GetComponent<Camera>();
        cam.depthTextureMode = DepthTextureMode.Depth;
		cam.depth = -10;
		gameObject.SetActive(false);
		player = FindObjectOfType<JoystickManager>().playersList[playerIndex];
		player.GetComponent<PlayerAttack>().pcam = this;
	}

	public void Init(int width, int height) {
		gameObject.SetActive(true);
		isUsed = true;
		renderTexture = new RenderTexture(width, height, 16);
		cam.targetTexture = renderTexture;
		targetMat.SetTexture("_MainTex", renderTexture);
	}

    private void Update() {
        List<Wave> toDelete = new List<Wave>();
        foreach (Wave wave in waves)
        {
            if (!wave.Update())
            {
                toDelete.Add(wave);
            }
        }
        foreach (Wave w in toDelete)
        {
            waves.Remove(w);
        }
    }

	private void LateUpdate() {
		if (!gameObject || !player) return;
		transform.position = player.transform.position + offset;
	}

	private void OnRenderImage(RenderTexture source, RenderTexture destination) {
        // Sonar Effect
        RenderTexture sonarTmp = RenderTexture.GetTemporary(source.width, source.height);
        Graphics.Blit(source, sonarTmp);
        foreach(Wave wave in waves)
        {
            RenderTexture sonarTmp2 = RenderTexture.GetTemporary(source.width, source.height);
            sonarMat.SetFloat("_ScanDistance", wave.distance);
            sonarMat.SetVector("_WorldSpaceScannerPos", wave.origin);
			sonarMat.SetColor("_LeadColor", wave.leadColor);
			sonarMat.SetColor("_MidColor", wave.middleColor);
			sonarMat.SetColor("_TrailColor", wave.trailColor);
			RaycastCornerBlit(sonarTmp, sonarTmp2, sonarMat);
            RenderTexture.ReleaseTemporary(sonarTmp);
            sonarTmp = sonarTmp2;
        }

        // Blur Effect
        if (!isBlurActive || blurEffect == null) {
            Graphics.Blit(sonarTmp, destination);
            RenderTexture.ReleaseTemporary(sonarTmp);
			return;
		}

		RenderTexture tmp = RenderTexture.GetTemporary(source.width >> downRes, source.height >> downRes);
        Graphics.Blit(sonarTmp, tmp);
        RenderTexture.ReleaseTemporary(sonarTmp);
		for (int i = 0; i < blurPasses; i++) {
			RenderTexture tmp2 = RenderTexture.GetTemporary(tmp.width, tmp.height);
			Graphics.Blit(tmp, tmp2, blurEffect);
			RenderTexture.ReleaseTemporary(tmp);
			tmp = tmp2;
		}
		Graphics.Blit(tmp, destination);
		RenderTexture.ReleaseTemporary(tmp);
	}

    void RaycastCornerBlit(RenderTexture source, RenderTexture dest, Material mat)
    {
        // Compute Frustum Corners
        float camFar = cam.farClipPlane;
        float camFov = cam.fieldOfView;
        float camAspect = cam.aspect;

        float fovWHalf = camFov * 0.5f;

        Vector3 toRight = cam.transform.right * Mathf.Tan(fovWHalf * Mathf.Deg2Rad) * camAspect;
        Vector3 toTop = cam.transform.up * Mathf.Tan(fovWHalf * Mathf.Deg2Rad);

        Vector3 topLeft = (cam.transform.forward - toRight + toTop);
        float camScale = topLeft.magnitude * camFar;

        topLeft.Normalize();
        topLeft *= camScale;

        Vector3 topRight = (cam.transform.forward + toRight + toTop);
        topRight.Normalize();
        topRight *= camScale;

        Vector3 bottomRight = (cam.transform.forward + toRight - toTop);
        bottomRight.Normalize();
        bottomRight *= camScale;

        Vector3 bottomLeft = (cam.transform.forward - toRight - toTop);
        bottomLeft.Normalize();
        bottomLeft *= camScale;

        // Custom Blit, encoding Frustum Corners as additional Texture Coordinates
        RenderTexture.active = dest;

        mat.SetTexture("_MainTex", source);

        GL.PushMatrix();
        GL.LoadOrtho();

        mat.SetPass(0);

        GL.Begin(GL.QUADS);

        GL.MultiTexCoord2(0, 0.0f, 0.0f);
        GL.MultiTexCoord(1, bottomLeft);
        GL.Vertex3(0.0f, 0.0f, 0.0f);

        GL.MultiTexCoord2(0, 1.0f, 0.0f);
        GL.MultiTexCoord(1, bottomRight);
        GL.Vertex3(1.0f, 0.0f, 0.0f);

        GL.MultiTexCoord2(0, 1.0f, 1.0f);
        GL.MultiTexCoord(1, topRight);
        GL.Vertex3(1.0f, 1.0f, 0.0f);

        GL.MultiTexCoord2(0, 0.0f, 1.0f);
        GL.MultiTexCoord(1, topLeft);
        GL.Vertex3(0.0f, 1.0f, 0.0f);

        GL.End();
        GL.PopMatrix();
    }

	private void OnDestroy() {
		if (!isUsed) return;
		renderTexture.DiscardContents();
		renderTexture.Release();
	}

    public void CastWave(Vector3 pos, float speed, float maxDistance, Color lead, Color middle, Color trail) {
        Wave w = new Wave(pos, speed, maxDistance, lead, middle, trail);
        waves.Add(w);
    }

    public static void CastWaveOnAll(Vector3 pos, float speed, float maxDistance, Color lead, Color middle, Color trail) {
        foreach (PlayerCamera cam in cameras) {
            cam.CastWave(pos, speed, maxDistance, lead, middle, trail);
        }
    }

}
