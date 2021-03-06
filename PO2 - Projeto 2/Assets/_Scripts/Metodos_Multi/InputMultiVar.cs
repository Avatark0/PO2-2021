using System;
using UnityEngine;

public class InputMultiVar
{
    private static string varNumString;

    private static int varNum;

    private static string var1;
    private static string var2;
    private static string var3;
    private static string var4;
    private static string var5;

    private static string funcao;

    private static string x1IniString;
    private static string x2IniString;
    private static string x3IniString;
    private static string x4IniString;
    private static string x5IniString;
    private static double x1Ini;
    private static double x2Ini;
    private static double x3Ini;
    private static double x4Ini;
    private static double x5Ini;

    private static string epslonString;
    private static double epslon;

    private static bool inputsSet;
    
    public static void ResetInputs()
    {
        varNumString = "";
        varNum=2;

        var1 = "";
        var2 = "";
        var3 = "";
        var4 = "";
        var5 = "";

        funcao= "";

        x1IniString = "";
        x2IniString = "";
        x3IniString = "";
        x4IniString = "";
        x5IniString = "";

        x1Ini = 0;
        x2Ini = 0;
        x3Ini = 0;
        x4Ini = 0;
        x5Ini = 0;

        epslonString = "";
        epslon=0.001;

        inputsSet = false;
    }

    public static string GetVarNumString(){return varNumString;}

    public static int GetVarNum(){return varNum;}

    public static string GetVar(int varIndex)
    {
        string var;
        switch(varIndex){
            case 1: var = var1; break;
            case 2: var = var2; break;
            case 3: var = var3; break;
            case 4: var = var4; break;
            case 5: var = var5; break;
            default: var = ""; break;
        }
        return var;
    }


    public static string GetFuncao(){return funcao;}

    public static string GetValInicialString(int valIndex)
    {
        string val;
        switch(valIndex){
            case 1: val = x1IniString; break;
            case 2: val = x2IniString; break;
            case 3: val = x3IniString; break;
            case 4: val = x4IniString; break;
            case 5: val = x5IniString; break;
            default: val = ""; break;
        }
        return val;
    }

    public static double GetValInicial(int valIndex)
    {
        double val;
        switch(valIndex){
            case 1: val = x1Ini; break;
            case 2: val = x2Ini; break;
            case 3: val = x3Ini; break;
            case 4: val = x4Ini; break;
            case 5: val = x5Ini; break;
            default: val = 0; break;
        }
        return val;
    }

    public static string GetEpslonString(){return epslonString;}
    public static double GetEpslon(){return epslon;}

    public static void SetVarNum(string _numS){
        varNumString = _numS;
        try{
            varNum = int.Parse(varNumString);
        }catch{
            Debug.Log("InputMultiVar: Erro na convers??o de varNumString para int!");
        }
    }

    public static void SetVar(int varIndex, string var){
        switch(varIndex){
            case 1: var1 = var; break;
            case 2: var2 = var; break;
            case 3: var3 = var; break;
            case 4: var4 = var; break;
            case 5: var5 = var; break;
        }
    }

    public static void SetFuncao(string _funcao){funcao = _funcao;}

    public static void SetValInicial(int valIndex, string valString){
        switch(valIndex){
            case 1:{
                try{
                    x1Ini = Convert.ToDouble(valString);
                }catch{
                    Debug.Log("InputMultiVar: Erro na convers??o de x1IniString para double!");
                }
                break;
            }
            case 2:{
                try{
                    x2Ini = Convert.ToDouble(valString);
                }catch{
                    Debug.Log("InputMultiVar: Erro na convers??o de x2IniString para double!");
                }
                break;
            }
            case 3:{
                try{
                    x3Ini = Convert.ToDouble(valString);
                }catch{
                    Debug.Log("InputMultiVar: Erro na convers??o de x3IniString para double!");
                }
                break;
            }
            case 4:{
                try{
                    x4Ini = Convert.ToDouble(valString);
                }catch{
                    Debug.Log("InputMultiVar: Erro na convers??o de x4IniString para double!");
                }
                break;
            }
            case 5:{
                try{
                    x5Ini = Convert.ToDouble(valString);
                }catch{
                    Debug.Log("InputMultiVar: Erro na convers??o de x5IniString para double!");
                }
                break;
            }
        }
    }

    public static void SetEpslon(string _epslonString){
        epslonString = _epslonString;
        try{
            epslon = Convert.ToDouble(epslonString);
        }catch{
            Debug.Log("InputMultiVar: Erro na convers??o de Epslon para double!");
        }
    }

    public static void InputsAreSet(){
        inputsSet=true;
    }

    public static bool AreInputsSet(){
        return inputsSet;
    }
}
