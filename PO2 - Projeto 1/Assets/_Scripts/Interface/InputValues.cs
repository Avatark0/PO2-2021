using System;
using UnityEngine;

public class InputValues
{
    private static string funcao;
    private static string aString;
    private static string bString;
    private static string deltaString;
    private static string epslonString;

    private static double a;
    private static double b;
    private static double delta;
    private static double epslon;

    private static bool inputsSet;

    public static void ResetInputs()
    {
        funcao = "";
        aString = "";
        bString = "";
        deltaString = "";
        epslonString = "";

        a=0;
        b=0;
        delta=0;
        epslon=0;

        inputsSet = false;
    }

    public static string GetFuncao(){return funcao;}
    public static string GetAString(){return aString;}
    public static string GetBString(){return bString;}
    public static string GetDeltaString(){return deltaString;}
    public static string GetEpslonString(){return epslonString;}
    public static double GetA(){return a;}
    public static double GetB(){return b;}
    public static double GetDelta(){return delta;}
    public static double GetEpslon(){return epslon;}


    public static void SetFuncao(string _funcao){funcao = _funcao;}
    
    public static void SetA(string _aString){
        aString = _aString;
        try{
            a = Convert.ToDouble(aString);
        }catch{
            Debug.Log("InputValues: Erro na conversão de A para double!");
        }
    }

    public static void SetB(string _bString){
        bString = _bString;
        try{
            b = Convert.ToDouble(bString);
        }catch{
            Debug.Log("InputValues: Erro na conversão de B para double!");
        }
    }

    public static void SetDelta(string _deltaString){
        deltaString = _deltaString;
        try{
            delta = Convert.ToDouble(deltaString);
        }catch{
            Debug.Log("InputValues: Erro na conversão de Delta para double!");
        }
    }

    public static void SetEpslon(string _epslonString){
        epslonString = _epslonString;
        try{
            epslon = Convert.ToDouble(epslonString);
        }catch{
            Debug.Log("InputValues: Erro na conversão de Epslon para double!");
        }
    }

    public static void InputsAreSet(){
        inputsSet=true;
    }

    public static bool AreInputsSet(){
        return inputsSet;
    }
}
