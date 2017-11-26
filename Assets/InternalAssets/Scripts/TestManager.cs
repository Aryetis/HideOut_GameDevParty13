using UnityEngine;

public class TestManager : Singleton<TestManager> {

	public void Update() {
		if (Input.GetKeyDown(KeyCode.Space)) {
			PlayerCamera.CastWaveOnAll(new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f)), 5f, 10f, Color.white, Color.yellow, Color.red);
		}
	}

}
