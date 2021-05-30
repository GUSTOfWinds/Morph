using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour{
	public Sound[] sounds;
	
	void Awake() {
		foreach (Sound s in sounds){
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			
			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}
	}
	void Start(){
		Play("Theme");
	}
	public void Play (string name){
		Sound s = GetSound(name);
		if(!s.source.isPlaying) {s.source.Play();}
	}
	public void Stop(string name) {
		Sound s = GetSound(name);
		if(s.source.isPlaying) {s.source.Stop();}
	}
	private Sound GetSound(string name){
		return Array.Find(sounds, sound => sound.name.Equals(name));
	}
}
