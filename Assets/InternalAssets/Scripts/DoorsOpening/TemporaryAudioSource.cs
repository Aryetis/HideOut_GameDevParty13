using UnityEngine;
using System.Collections;

public class TemporaryAudioSource : MonoBehaviour {

	private AudioSource source;
	private bool playScheduled = false;
	private float startTime;
	private float lifetime;

	public static void PlayTempClip(AudioClip clip, Vector3 pos) {
		GameObject go = new GameObject();
		go.transform.position = pos;
		TemporaryAudioSource src = go.AddComponent<TemporaryAudioSource>();
		src.Play(clip);
	}

	public void Awake() {
		source = gameObject.AddComponent<AudioSource>();
		source.playOnAwake = false;
	}

	public void Play(AudioClip clip) {
		source.clip = clip;
		playScheduled = true;
	}

	public void Update() {
		if (playScheduled) {
			source.Play();
			startTime = Time.time;
			lifetime = source.clip.length;
			playScheduled = false;
		}
		if (startTime + lifetime < Time.time) {
			Destroy(gameObject);
		}
	}

}
