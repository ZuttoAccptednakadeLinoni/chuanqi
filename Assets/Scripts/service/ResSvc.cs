using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
///
/// 资源加载服务
/// </summary>
public class ResSvc : MonoBehaviour
{
    public static ResSvc Instance = null;
    public void InitSvc()
    {
        Instance = this;
        Debug.Log("InitSvc");
    }

    public Action prgCB = null;
    public void AsyncLoadScene(string scenename, Action loaded)
    {
        GameRoot.Instance.loadingWind.SetWndState();
        AsyncOperation sceneAsync = SceneManager.LoadSceneAsync(scenename);
        prgCB = () =>
        {
            float val = sceneAsync.progress;
            GameRoot.Instance.loadingWind.SetProgress(val);
            if (val == 1)
            {
                if (loaded != null) {
                    loaded();
                }
                prgCB = null;
                sceneAsync = null;
                GameRoot.Instance.loadingWind.gameObject.SetActive(false);
            }
        };

    }

    private void Update()
    {
        if (prgCB != null)
        {
            prgCB();
        }
    }
    private Dictionary<string, AudioClip> adDic = new Dictionary<string, AudioClip>();
    public AudioClip LoadAudio(string path, bool cache = false) {
        AudioClip au = null;
        if (!adDic.TryGetValue(path, out au)) {
            au = Resources.Load<AudioClip>(path);
            if (cache) {
                adDic.Add(path, au);
            }
        }
        return au;
    }
}
