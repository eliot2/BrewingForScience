﻿using UnityEngine;
using System.Collections;
using LoLSDK;

public class AudioManager : MonoBehaviour {

    public AudioSource MusicPlayer;
    private float originalVolume;
    public AudioSource SfxPlayer;

    public AudioClip[] Musics; 
    public AudioClip[] Sfxs;


    public string[] MscNames;

	// Use this for initialization
	void Start () {
        gameObject.tag = "AudioMan";
        originalVolume = MusicPlayer.volume;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public static void PlayM(int MusicNum)
    {
        GetRef()._PlayM(MusicNum);
    }

    public static void PlayS(int SfxNum)
    {
        GetRef()._PlayM(SfxNum);
    }

    private void _PlayM(int musicNum)
    {
        MusicPlayer.Stop();
        MusicPlayer.clip = Musics[musicNum];
        MusicPlayer.Play();
        Debug.Log("AUdio name?: " + Musics[musicNum].name);
        //LOLSDK.Instance.PlaySound(Musics[musicNum].name
    }

    private void _PlayS(int sfxNum)
    {
        SfxPlayer.Stop();
        SfxPlayer.clip = Sfxs[sfxNum];
        SfxPlayer.Play();

    }

    public static AudioManager GetRef()
    {
        return GameObject.FindGameObjectWithTag("AudioMan").GetComponent<AudioManager>();
    }

    public static string GetMscName(int musicNum)
    {
        return GetRef().MscNames[musicNum];
    }

    public void TurnMusicOff()
    {
        LOLSDK.Instance.ConfigureSound(0.65f, 0.0f, 0.1f);
        MusicPlayer.volume = 0;
    }
    public void TurnMusicOn()
    {
        MusicPlayer.volume = originalVolume;
        LOLSDK.Instance.ConfigureSound(0.65f, 0.2f, 0.1f);
    }
}
