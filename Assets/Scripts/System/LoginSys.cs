using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 登录注册系统
/// 未完成
/// </summary>
public class LoginSys : SystemRoot
{
    public static LoginSys Instance = null;
    public LoginWind loginWnd;
    public CreateWnd createWnd;
    /// <summary>
    /// 初始化
    /// </summary>
    public override void InitSys() {
        base.InitSys();

        Instance = this;
        Debug.Log("Init LoginSys...");
    }

    /// <summary>
    /// 进入登录场景
    /// </summary>
public void EnterLogin()
    {
        resSvc.AsyncLoadScene(Constants.SceneLogin, () => {
            //加载完成以后再打开注册登录界面
            loginWnd.SetWndState();
            //audioSvc.PlayBGMusic(Constants.BGLogin);
            GameRoot.AddTips(("load Done"));
            GameRoot.AddTips(("load"));
            GameRoot.AddTips(("load111"));
            GameRoot.AddTips(("load31w"));
        });
    }   
    public void RspLogin() {
             GameRoot.AddTips("登录成功");
     
             //打开角色创建界面
             createWnd.SetWndState();
             //关闭登录界面
             loginWnd.SetWndState(false);
         }
}
