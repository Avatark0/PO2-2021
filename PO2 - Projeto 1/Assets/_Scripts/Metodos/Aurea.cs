using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using B83.ExpressionParser;

public class Aurea : MonoBehaviour
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

        resultado.text = Math.Round(Algoritmo(),4).ToString();
    }

    private double Algoritmo()
    {
        double alfa;
        double beta;
        double mi;
        double lamb;

        alfa = (-1 + Math.Sqrt(5))/2;
        beta = 1 - alfa;
        mi = a + beta * (b-a);
        lamb = a + alfa * (b-a);

        for(int i=0; (b-a) > epslon; i++)
        {
            if(FdeX(funcao,mi) > FdeX(funcao,lamb))
            {
                a = mi;
                mi = lamb;
                lamb = a + alfa * (b-a);
            }
            else
            {
                b = lamb;
                lamb = mi;
        	    mi = a + beta * (b-a);
            }
            //Debugando(mi, lamb);
        }

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

    private void Debugando(double _mi, double _lamb)
    {
        Debug.Log("a = "+a+", b = "+b+", mi = "+_mi+", lamb = "+_lamb+", F(mi) = "+FdeX(funcao,_mi)+", F(lamb) = "+FdeX(funcao,_lamb));
    }
}
