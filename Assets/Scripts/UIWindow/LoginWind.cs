using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 登录注册界面
/// 写到这了
/// </summary>
public class LoginWind : WindowRoot
{
    public TMP_InputField iptAcct;
    public TMP_InputField iptPass;
    public Button btnEnter;
    public Button btnNotice;
    protected override void InitWnd() {
        base.InitWnd();

        //获取本地存储的账号密码
        if (PlayerPrefs.HasKey("Acct") && PlayerPrefs.HasKey("Pass")) {
            iptAcct.text = PlayerPrefs.GetString("Acct");
            iptPass.text = PlayerPrefs.GetString("Pass");
        }
        else {
            iptAcct.text = "";
            iptPass.text = "";
        }
    }
    /// <summary>
    /// 点击进入游戏
    /// </summary>
    public void ClickEnterBtn() {
        //audioSvc.PlayUIAudio(Constants.UILoginBtn);

        string acct = iptAcct.text;
        string pass = iptPass.text;
        if (acct != "" && pass != "") {
            //更新本地存储的账号密码
            PlayerPrefs.SetString("Acct", acct);
            PlayerPrefs.SetString("Pass", pass);

            //TODO 发送网络消息，请求登录

            //TO Remove
            //LoginSys.Instance.RspLogin();
        }
        else {
           // GameRoot.AddTips("账号或密码为空");
        }
    }

    public void ClicKNoticeBtn() {
        //audioSvc.PlayUIAudio(Constants.UIClickBtn);

        //GameRoot.AddTips("功能正在开发中...");
    }
}
