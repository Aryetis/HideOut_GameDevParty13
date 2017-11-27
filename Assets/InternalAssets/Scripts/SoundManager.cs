using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class SoundManager : Singleton<SoundManager> {

    public AudioSource efxSource;                   //Drag a reference to the audio source which will play the sound effects.
    public AudioSource musicSource;                 //Drag a reference to the audio source which will play the music.
    public static SoundManager instance = null;     //Allows other scripts to call functions from SoundManager.             
    public float lowPitchRange = .95f;              //The lowest a sound effect will be randomly pitched.
    public float highPitchRange = 1.05f;            //The highest a sound effect will be randomly pitched.

	public NavMeshAgent jason;

    void Awake() {
        //Check if there is already an instance of SoundManager
        if (instance == null)
            //if not, set it to this.
            instance = this;
        //If instance already exists:
        else if (instance != this)
            //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
            Destroy(gameObject);

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySingle(AudioClip clip) {
        //Set the clip of our efxSource audio source to the clip passed in as a parameter.
        efxSource.clip = clip;

        //Play the clip.
        efxSource.Play();
    }

	public void PlayHearableSound(Vector3 pos, AudioClip clip, float range) {
		if (clip != null) {
			TemporaryAudioSource.PlayTempClip(clip, pos);
		}
		PlayerCamera.CastWaveOnAll(pos, 10f, range, Color.cyan, Color.blue, Color.magenta);
		if (Vector3.Distance(pos, jason.transform.position) < range) {
			jason.SetDestination(pos);
		}
	}

	public void PlayEnemySound(Vector3 pos, AudioClip clip, float range) {
		if (clip != null) {
			TemporaryAudioSource.PlayTempClip(clip, pos);
		}
		PlayerCamera.CastWaveOnAll(pos, 15f, range, Color.yellow, Color.red, Color.red);
	}
}


