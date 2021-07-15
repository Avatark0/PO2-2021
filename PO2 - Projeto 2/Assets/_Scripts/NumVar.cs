using System;
using UnityEngine;

public class NumVar
{
    private static string numS;

    private static int numI;

    public static int GetNumS(){return numI;}

    public static void SetNum(string _numS){
        numS = _numS;
        try{
            numI = int.Parse(numS);
        }catch{
            Debug.Log("InputValues: Erro na conversão de numI para int!");
        }
    }
}
