/****************************************************
    文件：PETools.cs
	作者：k0itoyuu
    日期：2025/12/22 15:49:1
	功能：工具类
*****************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PETools {
    public static int RDInt(int min, int max, System.Random rd = null) {
        if (rd == null) {
            rd = new System.Random();
        }
        int val = rd.Next(min, max + 1);
        return val;
    }
}

