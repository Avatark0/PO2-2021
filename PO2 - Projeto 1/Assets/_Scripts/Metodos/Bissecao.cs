using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using B83.ExpressionParser;

public class Bissecao : MonoBehaviour
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
        double ai;
        double bi;
        double xi;
        double dx;
        
        ai = a;
        bi = b;
        xi = (ai+bi)/2;

        for(int i=0; true; i++)
        {
            if((bi - ai) < epslon)break;

            dx = Derivada(funcao, xi);
            
            if(dx == 0) return xi;
            else if(dx > 0)
            {
                bi = xi;
                xi = (ai+bi)/2;
            }
            else
            {
                ai = xi;
                xi = (ai+bi)/2;
            }

            DebugValores(ai, bi, xi, dx);
        }

        return xi;
    }

    private double Derivada(string funcao, double x)
    {
        double h = 0.0001 * x;
        double xUp = x + h;
        double xDw = x - h;

        xUp = FdeX(funcao, xUp);
        xDw = FdeX(funcao, xDw);

        double dx = (xUp - xDw) / (2*h);
        
        return dx;
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

    private void DebugValores(double ai, double bi, double xi, double dx)
    {
        Debug.Log("ai = "+ai+", bi = "+bi+", xi = "+xi+", dx = "+dx);
    }
}