/****************************************************
    文件：AudioSvc.cs
	作者：k0itoyuu
    日期：2025/12/16 17:28:52
	功能：声音播放服务
*****************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 未完成
/// </summary>
public class AudioSvc : MonoBehaviour
{
    public static AudioSvc Instance = null;
    public AudioSource bgAudio;
    public AudioSource uiAudio;
    public void InitSvc() {
        Instance = this;
        Debug.Log("Init AudioSvc...");
    }
    public void PlayBGMusic(string name, bool isLoop = true) {
        AudioClip audio = ResSvc.Instance.LoadAudio("ResAudio/" + name, true);
        if (bgAudio.clip == null || bgAudio.clip.name != audio.name) {
            bgAudio.clip = audio;
            bgAudio.loop = isLoop;
            bgAudio.Play();
        }
    }

    public void PlayUIAudio(string name) {
        AudioClip audio = ResSvc.Instance.LoadAudio("ResAudio/" + name, true);
        uiAudio.clip = audio;
        uiAudio.Play();
    }
}
