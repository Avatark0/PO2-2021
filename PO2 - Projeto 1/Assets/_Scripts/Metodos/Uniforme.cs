using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using B83.ExpressionParser;

public class Uniforme : MonoBehaviour
{
    [SerializeField] private InputField inputFuncao = default;
    [SerializeField] private InputField inputA = default;
    [SerializeField] private InputField inputB = default;
    [SerializeField] private InputField inputDelta = default;

    [SerializeField] private Text resultado = default;

    private string funcao;
    private string aString;
    private string bString;
    private string deltaString;

    private double a;
    private double b;
    private double delta;
    
    public void Calcular()
    {
        funcao = inputFuncao.text;
        aString = inputA.text;
        bString = inputB.text;
        deltaString = inputDelta.text;

        a = Convert.ToDouble(aString);
        b = Convert.ToDouble(bString);
        delta = Convert.ToDouble(deltaString);

        Debug.Log("Resultado é = " + Algoritmo());
        resultado.text = Algoritmo().ToString();
    }

    private double Algoritmo()
    {
        double x0;
        double x1;
        int i;

        //Aproximacao Inicial
        for(i=0; a+delta < b; i++)
        {
            x0 = SubstituiAeRetornaVal(funcao, a);
            x1 = SubstituiAeRetornaVal(funcao, a+delta);
            
            Debugando(x0, x1);
            
            if(x1 < x0)
            {
                a=a+delta;
            }
            else break;
        }

        //Refinamento
        if(i>1)a-=delta;
        delta/=10;
        
        for(i=0; a+delta < b; i++)
        {
            x0 = SubstituiAeRetornaVal(funcao, a);
            x1 = SubstituiAeRetornaVal(funcao, a+delta);
            
            Debugando(x0, x1);
            
            if(x1 < x0)
            {
                a=a+delta;
            }
            else break;
        }

        return a;
    }

    private double SubstituiAeRetornaVal(string _funcao, double x)
    {
        string val = funcao.Replace("x", FormatarNum(x));
        var parser = new ExpressionParser();
        Expression exp = parser.EvaluateExpression(val);
        return exp.Value;
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

    private void Debugando(double _x0, double _x1)
    {
        Debug.Log("a = x ="+a);
        Debug.Log("x0 = f(x) = "+_x0);
        Debug.Log("a+delta = xk = "+(a+delta));
        Debug.Log("x1 = f(xk) = "+_x1);
        Debug.Log("delta = "+delta);
        Debug.Log("b = "+b);
    }
}
