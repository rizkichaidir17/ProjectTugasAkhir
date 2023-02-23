using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

	public static AudioManager instance;

	public AudioMixerGroup mixerGroup;

	public Sound[] sounds;

	/*[SerializeField] Image soundOnIcon;
	[SerializeField] Image soundOffIcon;*/

	//private bool muted = false;

	void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}

		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;
			s.source.playOnAwake = s.playOnAwake;


			s.source.outputAudioMixerGroup = mixerGroup;
		}
	}

   /* void Start()
    {
        if(!PlayerPrefs.HasKey("muted"))
        {
			PlayerPrefs.SetInt("muted", 0);
			Load();
        }
		else
        {
			Load();
        }
		UpdateButtonIcon();

	}*/

    public void Play(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

		s.source.Play();
	}

	/*public void OnButtonPress()
    {
		if(muted == false)
        {
			muted = true;
			AudioListener.pause = true;
        }
		else
        {
			muted = false;
			AudioListener.pause = false;
        }
		Save();
		UpdateButtonIcon();

	}

	public void UpdateButtonIcon()
    {
		if(muted == false)
        {
			soundOffIcon.enabled = false;
			soundOnIcon.enabled = true;
        }
		else
        {
			soundOffIcon.enabled = true;
			soundOnIcon.enabled = false;
		}
    }

	private void Load()
    {
		muted = PlayerPrefs.GetInt("muted") == 1;
    }
	private void Save()
    {
		PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }*/

}
