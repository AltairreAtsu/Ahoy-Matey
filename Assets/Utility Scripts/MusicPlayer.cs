using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {

	public AudioClip[] music;
	public float splashVolume = 1.0f;
	public float musicVolume = 0.40f;

	private AudioSource audioSource;

	private void Start () {
		// Prevent Destruction of Music PLayer
		GameObject.DontDestroyOnLoad(gameObject);

		audioSource = gameObject.GetComponent<AudioSource>();

        SceneManager.sceneLoaded += OnSceneLoaded;
        int loadedLevel = SceneManager.GetActiveScene().buildIndex;

		if(loadedLevel == 0){
			audioSource.loop = false;
			audioSource.volume = splashVolume;
			audioSource.Play();
		} else {
			audioSource.clip = music[loadedLevel];
			audioSource.loop = true;
			audioSource.Play();
		}

		foreach (AudioClip clip in music){
			if(clip == null){
				Debug.LogWarning("Audio Clip missing from music Array!\n" + "All array entries must have values!");
			}
		}
	}
	
	public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        int loadedLevel = scene.buildIndex;

        if (music[loadedLevel] != null && music[loadedLevel] != audioSource.clip){
			audioSource.Stop();
			audioSource.clip = music[loadedLevel];
			if(loadedLevel > 0){
				audioSource.loop = true;
				audioSource.volume = musicVolume;
				audioSource.Play();
			}
		}
	}

	public void StopAndPlay(AudioClip clip){
		audioSource.Stop();
		audioSource.loop = false;
		audioSource.clip = clip;
		audioSource.Play();
	}

    public void ToggleMute()
    {
        if (audioSource.volume == 0f)
            audioSource.volume = musicVolume;
        else
            audioSource.volume = 0f;
    }

	public void SetMusicVolume(float musicVolume){
		audioSource.volume = musicVolume;
	}

}
