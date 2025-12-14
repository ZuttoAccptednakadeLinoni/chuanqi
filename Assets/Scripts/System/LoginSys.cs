using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 登录注册系统
/// </summary>
public class LoginSys : MonoBehaviour
{
    /// <summary>
    /// 初始化
    /// </summary>
    public void InitSys()
    {
        Debug.Log("InitSys");
        EnterLogin(); 
    }
/// <summary>
///
/// 进入登录场景
/// </summary>
    public void EnterLogin()
    {
        GameRoot.Instance.loadingWind.gameObject.SetActive(true);
        //异步加载，显示进度条，加载完后打开登录界面
        GameRoot.Instance.loadingWind.InitWind();
        ResSvc.Instance.AsyncLoadScene(Constants.SceneLogin);
        
    }
}
