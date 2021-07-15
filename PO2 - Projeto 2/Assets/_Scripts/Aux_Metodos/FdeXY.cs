using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using B83.ExpressionParser;

public class FdeXY
{
    public static double Calc(string var, string funcao, double val)
    {
        val = Math.Round(val,5);
        string equacao = funcao.Replace(var, FormatarNum.DecToString(val));
        var parser = new ExpressionParser();
        Expression exp = parser.EvaluateExpression(equacao);
        return Math.Round(exp.Value,5);
    }
}