using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormatarNum
{
    public static string DecToString(double num)
    {
        string sNum = num.ToString();
        if(sNum.Contains("."))Debug.Log("FORMATAR NUM CONTEM '.'!!! string do numero = "+sNum);
        if(sNum.Contains(","))
        {
            string[] frac = sNum.Split(',');
            double dec = frac[1].Length;
            sNum = frac[0] + frac[1] + "/" + (Math.Pow(10,dec)).ToString();
        }
        sNum = "(" + sNum + ")";
        return sNum;
    }
}
