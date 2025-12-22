using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Cysharp.Threading.Tasks;
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
        InitRDNameCfg();
        Debug.Log("InitSvc");
    }

    public Action prgCB = null;
    public async void AsyncLoadScene(string scenename, Action loaded)
    {
        GameRoot.Instance.loadingWind.SetWndState();
        await SceneManager.LoadSceneAsync(scenename).ToUniTask(
            (Progress.Create<float>((p) =>
            {
                GameRoot.Instance.loadingWind.SetProgress(p);
                Debug.Log(p);
                if (p *100>= 1)
                {
                    Debug.Log("加载完成");
                    if (loaded != null) {
                        loaded();
                    }
                    prgCB = null;
                    GameRoot.Instance.loadingWind.gameObject.SetActive(false);
                }
            })));
 
        

    }

    private void Update()
    {
        if (prgCB != null)
        {
            prgCB();
        }
    }
    private Dictionary<string, AudioClip> adDic = new Dictionary<string, AudioClip>();
    public AudioClip LoadAudio(string path, bool cache = false) {
        AudioClip au = null;
        if (!adDic.TryGetValue(path, out au)) {
            au = Resources.Load<AudioClip>(path);
            if (cache) {
                adDic.Add(path, au);
            }
        }
        return au;
    }
    #region InitCfgs
    private List<string> surnameLst = new List<string>();
    private List<string> manLst = new List<string>();
    private List<string> womanLst = new List<string>();
    private void InitRDNameCfg() {
        TextAsset xml = Resources.Load<TextAsset>(PathDefine.RDNameCfg);
        if (!xml) {
            Debug.LogError("xml file:" + PathDefine.RDNameCfg + " not exist");
        }
        else {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml.text);
    
            XmlNodeList nodLst = doc.SelectSingleNode("root").ChildNodes;
    
            for (int i = 0; i < nodLst.Count; i++) {
                XmlElement ele = nodLst[i] as XmlElement;
    
                if (ele.GetAttributeNode("ID") == null) {
                    continue;
                }
                int ID = Convert.ToInt32(ele.GetAttributeNode("ID").InnerText);
                foreach (XmlElement e in nodLst[i].ChildNodes) {
                    switch (e.Name) {
                        case "surname":
                            surnameLst.Add(e.InnerText);
                            break;
                        case "man":
                            manLst.Add(e.InnerText);
                            break;
                        case "woman":
                            womanLst.Add(e.InnerText);
                            break;
                    }
                }
    
            }
    
        }
    
    }
    
    public string GetRDNameData(bool man = true) {
        System.Random rd = new System.Random();
        string rdName = surnameLst[PETools.RDInt(0, surnameLst.Count - 1)];
        if (man) {
            rdName += manLst[PETools.RDInt(0, manLst.Count - 1)];
        }
        else {
            rdName += womanLst[PETools.RDInt(0, womanLst.Count - 1)];
        }
    
        return rdName;
    }
    #endregion
}
