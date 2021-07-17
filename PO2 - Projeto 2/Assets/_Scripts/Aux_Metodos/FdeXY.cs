using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using B83.ExpressionParser;

public class FdeXY
{
    public static string SubstituiVars(string funcao, string var, string y)
    {
        string equacao = funcao.Replace(var, y);
        
        return equacao;
    }

    public static double Calc(string funcao, string var1, double val1)
    {
        val1 = Math.Round(val1,5);
        string equacao = funcao.Replace(var1, FormatarNum.DecToString(val1));
        
        var parser = new ExpressionParser();
        Expression exp = parser.EvaluateExpression(equacao);
        return Math.Round(exp.Value,5);
    }

    public static double Calc(string funcao, string var1, double val1, string var2, double val2)
    {
        val1 = Math.Round(val1,5);
        string equacao = funcao.Replace(var1, FormatarNum.DecToString(val1));

        val2 = Math.Round(val2,5);
        equacao = equacao.Replace(var2, FormatarNum.DecToString(val2));
        
        var parser = new ExpressionParser();
        Expression exp = parser.EvaluateExpression(equacao);
        return Math.Round(exp.Value,5);
    }

    public static double Calc(string funcao, string var1, double val1, string var2, double val2, string var3, double val3)
    {
        val1 = Math.Round(val1,5);
        string equacao = funcao.Replace(var1, FormatarNum.DecToString(val1));

        val2 = Math.Round(val2,5);
        equacao = equacao.Replace(var2, FormatarNum.DecToString(val2));
        
        val3 = Math.Round(val3,5);
        equacao = equacao.Replace(var3, FormatarNum.DecToString(val3));
        
        var parser = new ExpressionParser();
        Expression exp = parser.EvaluateExpression(equacao);
        return Math.Round(exp.Value,5);
    }

    public static double Calc(string funcao, string var1, double val1, string var2, double val2, string var3, double val3, string var4, double val4)
    {
        val1 = Math.Round(val1,5);
        string equacao = funcao.Replace(var1, FormatarNum.DecToString(val1));

        val2 = Math.Round(val2,5);
        equacao = equacao.Replace(var2, FormatarNum.DecToString(val2));
        
        val3 = Math.Round(val3,5);
        equacao = equacao.Replace(var3, FormatarNum.DecToString(val3));

        val4 = Math.Round(val4,5);
        equacao = equacao.Replace(var4, FormatarNum.DecToString(val4));
        
        var parser = new ExpressionParser();
        Expression exp = parser.EvaluateExpression(equacao);
        return Math.Round(exp.Value,5);
    }

    public static double Calc(string funcao, string var1, double val1, string var2, double val2, string var3, double val3, string var4, double val4, string var5, double val5)
    {
        val1 = Math.Round(val1,5);
        string equacao = funcao.Replace(var1, FormatarNum.DecToString(val1));

        val2 = Math.Round(val2,5);
        equacao = equacao.Replace(var2, FormatarNum.DecToString(val2));
        
        val3 = Math.Round(val3,5);
        equacao = equacao.Replace(var3, FormatarNum.DecToString(val3));

        val4 = Math.Round(val4,5);
        equacao = equacao.Replace(var4, FormatarNum.DecToString(val4));

        val5 = Math.Round(val5,5);
        equacao = equacao.Replace(var5, FormatarNum.DecToString(val5));
        
        var parser = new ExpressionParser();
        Expression exp = parser.EvaluateExpression(equacao);
        return Math.Round(exp.Value,5);
    }
}