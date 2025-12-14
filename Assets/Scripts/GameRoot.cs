using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 游戏启动入口
/// </summary>
public class GameRoot : MonoBehaviour
{
    public static GameRoot Instance=null;
    public LoadingWind loadingWind;
    void Start()
    {
        Instance = this;
        DontDestroyOnLoad(this);
        Debug.Log("GameStart>>>");
        Init();
    }

    private void Init()
    {
        ResSvc res = GetComponent<ResSvc>();
        res.InitSvc();
        LoginSys login = GetComponent<LoginSys>();
        login.InitSys();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
