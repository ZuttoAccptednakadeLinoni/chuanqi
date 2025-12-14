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
    public void AsyncLoadScene(string scenename)
    {
        AsyncOperation sceneAsync = SceneManager.LoadSceneAsync(scenename);
        prgCB = () =>
        {
            float val = sceneAsync.progress;
            GameRoot.Instance.loadingWind.SetProgress(val);
            if (val == 1)
            {
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
}
