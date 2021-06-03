using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using B83.ExpressionParser;

public class Uniforme : MonoBehaviour
{
    [SerializeField] private string funcao;
    [SerializeField] private string aString;
    [SerializeField] private string bString;
    [SerializeField] private string deltaString;

    private double a;
    private double b;
    private double delta;
    private double[] res;

    [SerializeField] private InputField inputFuncao = default;
    [SerializeField] private InputField inputA = default;
    [SerializeField] private InputField inputB = default;
    [SerializeField] private InputField inputDelta = default;

    private void Awake()
    {
        res = new double[100000];
    }

    public void Calcular()
    {
        funcao = inputFuncao.text;
        aString = inputA.text;
        bString = inputB.text;
        deltaString = inputDelta.text;

        var parser = new ExpressionParser();
        Expression exp;
        exp = parser.EvaluateExpression(aString);
        a=exp.Value;
        Debug.Log("minha rola mede: "+a);
        
        exp = parser.EvaluateExpression(bString);
        b=exp.Value;
        exp = parser.EvaluateExpression(deltaString);
        delta=exp.Value;

        Debug.Log(Algoritmo());
    }

    private double SubstituiAeRetornaVal(string _funcao, double x)
    {
        string val = funcao.Replace("x", x.ToString());
        var parser = new ExpressionParser();
        Expression exp = parser.EvaluateExpression(val);
        return exp.Value;
    }

    private double Algoritmo()
    {
        double x0 = SubstituiAeRetornaVal(funcao, a);
        double x1 = SubstituiAeRetornaVal(funcao, a+delta);
        int i;

        //Aproximacao Inicial
        for(i=0; a+delta < b; i++)
        {
            Debugando(x0, x1);
            x0 = SubstituiAeRetornaVal(funcao, a);
            x1 = SubstituiAeRetornaVal(funcao, a+delta);
            res[i]=x0;
            if(x1 < x0)
            {
                a=a+delta;
            }
            else break;
        }

        //Refinamento
        delta/=10;
        a=res[i-1];
        for(i=0; a+delta < b; i++)
        {
            Debugando(x0, x1);
            x0 = SubstituiAeRetornaVal(funcao, a);
            x1 = SubstituiAeRetornaVal(funcao, a+delta);
            res[i]=x0;
            if(x1 < x0)
            {
                a=a+delta;
            }
            else break;
        }

        return res[i];
    }

    private void Debugando(double _x0, double _x1)
    {
        Debug.Log("a = "+a);
        Debug.Log("delta = "+delta);
        Debug.Log("x0 = "+_x0);
        Debug.Log("x1 = "+_x1);
    }

    //1
    //calcular f(a)
    //calcular f(a+delta)
    //se a+delta < b,
        //se f(a) < f(a+delta), a=a+delta, retorna para 1
    //else
        //voltar 2 aproximações
    



    //quando não for:

}
