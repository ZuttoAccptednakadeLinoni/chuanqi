/****************************************************
    文件：DynamicWnd.cs
	作者：k0itoyuu
    日期：2025/12/17 22:37:42
	功能：动态UI元素界面
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DynamicWnd : WindowRoot
{
    public Animation tipsAni;
    public  TextMeshProUGUI txtTips;
    
    private bool isTipsShow = false;
    private Queue<string> tipsQue = new Queue<string>();
    protected override void InitWnd() {
        base.InitWnd();

        SetActive(txtTips, false);
    }

    public void AddTips(string tips) {
        lock (tipsQue) {
            tipsQue.Enqueue(tips);
        }
    }
    private void Update() {
        if (tipsQue.Count > 0 && isTipsShow == false) {
            lock (tipsQue) {
                string tips = tipsQue.Dequeue();
                isTipsShow = true;
                SetTips(tips);
            }
        }
    }
    private void SetTips(string tips) {
        Debug.Log(txtTips==null);
        SetActive(txtTips);
        SetText(txtTips, tips);

        AnimationClip clip = tipsAni.GetClip("New Animation");
        tipsAni.Play();
        //延时关闭激活状态

        StartCoroutine(AniPlayDone(clip.length, () => {
            SetActive(txtTips, false);
            isTipsShow = false;
        }));
    }
    private IEnumerator AniPlayDone(float sec, Action cb) {
        yield return new WaitForSeconds(sec);
        if (cb != null) {
            cb();
        }
    }
}
