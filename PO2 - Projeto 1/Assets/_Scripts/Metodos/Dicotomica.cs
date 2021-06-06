using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using B83.ExpressionParser;

public class Dicotomica : MonoBehaviour
{
    [SerializeField] private InputField inputFuncao = default;
    [SerializeField] private InputField inputA = default;
    [SerializeField] private InputField inputB = default;
    [SerializeField] private InputField inputDelta = default;
    [SerializeField] private InputField inputEpslon = default;

    [SerializeField] private Text resultado = default;

    private string funcao;
    private string aString;
    private string bString;
    private string deltaString;
    private string epslonString;

    private double a;
    private double b;
    private double delta;
    private double epslon;
    
    public void Calcular()
    {
        funcao = inputFuncao.text;
        aString = inputA.text;
        bString = inputB.text;
        deltaString = inputDelta.text;
        epslonString = inputEpslon.text;

        a = Convert.ToDouble(aString);
        b = Convert.ToDouble(bString);
        delta = Convert.ToDouble(deltaString);
        epslon = Convert.ToDouble(epslonString);

        Debug.Log("a = "+a+", b = "+b+", delta = "+delta+", epslon = "+epslon);

        double res = Algoritmo();
        resultado.text = Math.Round(res,4).ToString();
    }

    private double Algoritmo()
    {
        double x;
        double z;

        for(int i=0; (b-a) >= epslon; i++)
        {
            x=((a+b)/2)-delta;
            z=((a+b)/2)+delta;
            if(FdeX(funcao,x) > FdeX(funcao,z))
            {
                a=x;
                Debug.Log("f(x) > f(z)");
            }
            else
            {
                b=z;
                Debug.Log("f(x) <= f(z)");
            }
            //DebugValores(x, z);
        }

        return (a+b)/2;
    }

    private double FdeX(string _funcao, double x)
    {
        Math.Round(x,5);
        string val = funcao.Replace("x", FormatarNum(x));
        var parser = new ExpressionParser();
        Expression exp = parser.EvaluateExpression(val);
        return Math.Round(exp.Value,5);
    }

    private string FormatarNum(double num)
    {
        string sNum = num.ToString();
        if(sNum.Contains(","))
        {
            string[] frac = sNum.Split(',');
            double dec = frac[1].Length;
            sNum = frac[0] + frac[1] + "/" + (Math.Pow(10,dec)).ToString();
        }
        sNum = "(" + sNum + ")";
        return sNum;
    }

    private void DebugValores(double _x, double _z)
    {
        Debug.Log("a = "+a+", b = "+b+", x = "+_x+", z = "+_z+", F(x) = "+FdeX(funcao,_x)+", F(z) = "+FdeX(funcao,_z));
    }
}
