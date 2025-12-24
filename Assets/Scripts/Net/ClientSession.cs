/****************************************************
    文件：ClientSession.cs
	作者：k0itoyuu
    日期：2025/12/23 22:20:2
	功能：Nothing
*****************************************************/
using System.Collections;
using System.Collections.Generic;
using PENet;
using PErotocol;
using UnityEngine;

public class ClientSession : PESession<GameMsg>
{
    protected override void OnConnected() {
        GameRoot.AddTips("连接服务器成功");
        PECommon.Log("Connect To Server Succ");
    }

    protected override void OnReciveMsg(GameMsg msg) {
        PECommon.Log("RcvPack CMD:" + (msg.cmd).ToString());
        NetSvc.Instance.AddNetPkg(msg);
    }

    protected override void OnDisConnected() {
        GameRoot.AddTips("服务器断开连接");
        PECommon.Log("DisConnect To Server");
    }
}
