using System;
using UnityEngine;

public class InputVariaveis
{
    private static string varNumString;

    private static int varNum;

    private static string varX1;
    private static string varX2;
    private static string varX3;
    private static string varX4;
    private static string varX5;

    private static bool varsSet;
    
    public static void ResetVars()
    {
        varNumString = "";
        varX1 = "";
        varX2 = "";
        varX3 = "";
        varX4 = "";
        varX5 = "";

        varNum=1;

        varsSet = false;
    }

    public static string GetVarNumString(){return varNumString;}

    public static int GetVarNum(){return varNum;}

    public static void SetVarNum(string _numS){
        varNumString = _numS;
        try{
            varNum = int.Parse(varNumString);
        }catch{
            Debug.Log("InputValues: Erro na conversão de varNumString para int!");
        }
    }

    public static string GetVar(int varIndex)
    {
        string var;
        switch(varIndex){
            case 1: var = varX1; break;
            case 2: var = varX2; break;
            case 3: var = varX3; break;
            case 4: var = varX4; break;
            case 5: var = varX5; break;
            default: var = ""; break;
        }
        return var;
    }

    public static void SetVar(int varIndex, string var){
        switch(varIndex){
            case 1: varX1 = var; break;
            case 2: varX2 = var; break;
            case 3: varX3 = var; break;
            case 4: varX4 = var; break;
            case 5: varX5 = var; break;
        }
    }

    public static void VarsAreSet(){
        varsSet=true;
    }

    public static bool AreVarsSet(){
        return varsSet;
    }
}
