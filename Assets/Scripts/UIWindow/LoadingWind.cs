

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingWind : MonoBehaviour
{
    public TextMeshProUGUI txtTips;
    public Image ImgFG;
    public Image imgPoint;
    public TextMeshProUGUI txtprg;

    private float fgWidth;
    public void InitWind()
    {
        fgWidth = ImgFG.GetComponent<RectTransform>().sizeDelta.x;
        txtprg.text = "这是一个提示";
        txtprg.text = "0%";
        ImgFG.fillAmount = 0;
        imgPoint.transform.localPosition = new Vector3(-545f, 0, 0);
        
    }

    public void SetProgress(float prg)
    {
        txtprg.text = (int)(prg * 100) + "%";
        ImgFG.fillAmount = prg;
        
        float posx=prg * fgWidth - 545;
        imgPoint.GetComponent<RectTransform>().anchoredPosition = new Vector2(posx, 0);
    }
}
