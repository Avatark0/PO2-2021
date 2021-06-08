using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using B83.ExpressionParser;

public class Fibonacci : MonoBehaviour
{
    [SerializeField] private InputField inputFuncao = default;
    [SerializeField] private InputField inputA = default;
    [SerializeField] private InputField inputB = default;
    [SerializeField] private InputField inputEpslon = default;

    [SerializeField] private Text resultado = default;

    private string funcao;
    private string aString;
    private string bString;
    private string epslonString;

    private double a;
    private double b;
    private double epslon;
    
    public void Calcular()
    {
        funcao = inputFuncao.text;
        aString = inputA.text;
        bString = inputB.text;
        epslonString = inputEpslon.text;

        a = Convert.ToDouble(aString);
        b = Convert.ToDouble(bString);
        epslon = Convert.ToDouble(epslonString);

        Debug.Log("a = "+a+", b = "+b+", epslon = "+epslon);

        double res = Algoritmo();
        resultado.text = Math.Round(res,4).ToString();
    }

    private double Algoritmo()
    {
        double mi;
        double lamb;
        
        float fn;
        float[] fib = new float[50];
        int i;

        fn = (float)((b - a)/epslon);
        fib[0] = 1;
        fib[1] = 1;
        
        for(i=1; true; i++)
        {
            if(Convert.ToDouble(fib[i]) > fn)break;//for loop não aceita comparação entre doubles (ou floats) como condição de parada
            fib[i+1] = fib[i] + fib[i-1];
        }

        mi = a + (fib[i-2] / fib[i]) * (b-a);
        lamb = a + (fib[i-1] / fib[i]) * (b-a);

        for(int k=1; k <= i-2; k++)
        {
            if(FdeX(funcao,mi) > FdeX(funcao,lamb))
            {
                a = mi;
                mi = lamb;
                lamb = a + (fib[i-k-1] / fib[i-k]) * (b-a);
            }
            else
            {
                b = lamb;
                lamb = mi;
                mi = a + (fib[i-k-2] / fib[i-k]) * (b-a);
            }
            //DebugValores(mi,lamb);
        }

        if(FdeX(funcao,mi) > FdeX(funcao,lamb))
            a = mi;
        else
            b = lamb;

        return (a+b)/2;
    }

    private double FdeX(string _funcao, double x)
    {
        x = Math.Round(x,5);
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

    private void DebugValores(double _mi, double _lamb)
    {
        Debug.Log("a = "+a+", b = "+b+", mi = "+_mi+", lamb = "+_lamb+", F(mi) = "+FdeX(funcao,_mi)+", F(lamb) = "+FdeX(funcao,_lamb));
    }
}
