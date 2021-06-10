using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using B83.ExpressionParser;

public class FdeX
{
    public static double Calc(string funcao, double x)
    {
        x = Math.Round(x,5);
        string val = funcao.Replace("x", FormatarNum.DecToString(x));
        var parser = new ExpressionParser();
        Expression exp = parser.EvaluateExpression(val);
        return Math.Round(exp.Value,5);
    }

    public static double Precise(string funcao, double x)
    {
        x = Math.Round(x,10);
        string val = funcao.Replace("x", FormatarNum.DecToString(x));
        var parser = new ExpressionParser();
        Expression exp = parser.EvaluateExpression(val);
        return Math.Round(exp.Value,10);
    }
}
