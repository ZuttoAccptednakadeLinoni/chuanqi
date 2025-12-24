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
    public DynamicWnd dynamicWnd;
    void Start()
    {
        Instance = this;
        DontDestroyOnLoad(this);
        Debug.Log("GameStart>>>");
        
        ClearUIRoot();
        
        Init();
    }
    private void ClearUIRoot() {//只保留提示界面
        Transform canvas = transform.Find("Canvas");
        for (int i = 0; i < canvas.childCount; i++) {
            canvas.GetChild(i).gameObject.SetActive(false);
        }

        dynamicWnd.SetWndState();
    }
    private void Init()
    {
        //服务模块初始化
        NetSvc net = GetComponent<NetSvc>();
        net.InitSvc();
        ResSvc res = GetComponent<ResSvc>();
        res.InitSvc();
        AudioSvc audio = GetComponent<AudioSvc>();
        audio.InitSvc();
        
        //业务系统初始化
        LoginSys login = GetComponent<LoginSys>();
        login.InitSys();
        
        
        //进入登录场景并加载相应UI
        login.EnterLogin();
    }
    public static void AddTips(string tips) {
        Instance.dynamicWnd.AddTips(tips);
    }
}
