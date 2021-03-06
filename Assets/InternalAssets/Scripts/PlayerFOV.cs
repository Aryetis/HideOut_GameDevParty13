using UnityEngine;

public class PlayerFOV : MonoBehaviour {

	[SerializeField]
	private float _FOVAngle = 80f;
	public float FOVAngle {
		get {
			return _FOVAngle;
		}
		private set {
			_FOVAngle = value;
			spotlight.spotAngle = _FOVAngle;
		}
	}

	[SerializeField]
	private float _FOVRange = 100f;
	public float FOVRange {
		get {
			return _FOVRange;
		}
		private set {
			_FOVRange = value;
			spotlight.range = _FOVRange;
		}
	}

	[SerializeField]
	private float _aroundRange = 40f;
	public float AroundRange {
		get {
			return _aroundRange;
		}
		private set {
			_aroundRange = value;
			pointLight.range = _aroundRange;
		}
	}

	[SerializeField]
	private float _intensity = 1f;
	public float Intensity {
		get {
			return _intensity;
		}
		set {
			_intensity = value;
			pointLight.intensity = pointBaseIntensity * _intensity;
			spotlight.intensity = spotBaseIntensity * _intensity;
		}
	}

	private Light spotlight;
	private float spotBaseIntensity;
	private Light pointLight;
	private float pointBaseIntensity;

	private void Awake() {
		spotlight = transform.Find("FOV").GetComponent<Light>();
		spotlight.spotAngle = _FOVAngle;
		spotlight.range = _FOVRange;
		pointLight = transform.Find("Around").GetComponent<Light>();
		pointLight.range = _aroundRange;
		spotBaseIntensity = spotlight.intensity;
		pointBaseIntensity = pointLight.intensity;
		spotlight.intensity = spotBaseIntensity * _intensity;
		pointLight.intensity = pointBaseIntensity * _intensity;
	}

	private void Update() {

	}

}
