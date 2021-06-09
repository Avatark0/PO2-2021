using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using B83.ExpressionParser;

public class Newton : MonoBehaviour
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
        double x;
        double xi;
        double dx;
        double ddx;

        x = a;

        for(int i=0; i<20; i++)
        {
            dx = Derivada(funcao, x);
            ddx = DerivadaSegunda(funcao, x);
            
            xi = x;
            x = xi - dx/ddx;

            DebugValores(xi, x, dx, ddx);

            if(Math.Abs(dx) < epslon ) break;
            if((Math.Abs(x - xi) / Math.Max(x, 1)) < epslon) break;
        }

        return x;
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

    private double DerivadaSegunda(string funcao, double x)
    {
        double h = 0.01 * x;
        double xh = x + h;
        double x2h = x + 2*h;

        double fx2h = FdeX(funcao, x2h);
        double fxh = FdeX(funcao, xh);
        double fx = FdeX(funcao, x);

        double dx1 = (fx2h-fxh)/h;
        double dx2 = (fxh-fx)/h;
        double ddx = (dx1 - dx2)/h;
        //Debug.Log("dx1 = "+dx1+", dx2 = "+dx2+", ddx = "+ddx);
        
        return ddx;
    }

    private double FdeX(string _funcao, double x)
    {
        x = Math.Round(x,10);
        string val = funcao.Replace("x", FormatarNum(x));
        var parser = new ExpressionParser();
        Expression exp = parser.EvaluateExpression(val);
        return Math.Round(exp.Value,10);
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

    private void DebugValores(double xi, double x, double dx, double ddx)
    {
        Debug.Log("xi = "+xi+", x = "+x+", dx = "+dx+", ddx = "+ddx);
    }
}