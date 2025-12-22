/****************************************************
    文件：CreatWnd.cs
	作者：k0itoyuu
    日期：2025/12/19 19:31:22
	功能：创建新角色
*****************************************************/
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreateWnd : WindowRoot
{
    public TMP_InputField iptName;
    
    protected override void InitWnd() {
        base.InitWnd();

        //显示一个随机名字
        iptName.text = resSvc.GetRDNameData(false);
    }

    public void ClickRandBtn() {
        audioSvc.PlayUIAudio(Constants.UIClickBtn);

        string rdName = resSvc.GetRDNameData();
        iptName.text = rdName;
    }

    public void ClickEnterBtn() {
        audioSvc.PlayUIAudio(Constants.UIClickBtn);

        if (iptName.text != "") {
            //TODO
            //发送名字数据到服务器，登录主城
        }
        else {
            GameRoot.AddTips("当前名字不符合规范");
        }
    }
}
