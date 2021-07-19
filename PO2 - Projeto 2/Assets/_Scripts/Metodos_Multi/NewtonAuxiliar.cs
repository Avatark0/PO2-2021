using System;
using UnityEngine;
using UnityEngine.UI;

public class NewtonAuxiliar
{
    private static string funcao;
    private static double epslon = 0.001;
    private static double startingPoint = 1;
    
    private static double Algoritmo()
    {
        double x;
        double xi;
        double dx;
        double ddx;

        x = startingPoint;

        for(int i=0; i<100; i++)
        {
            dx = Derivadas.Dx(funcao, x);
            ddx = Derivadas.Ddx(funcao, x);
            
            xi = x;
            x = xi - dx/ddx;

            //DebugValores(xi, x, dx, ddx);

            if(Math.Abs(dx) < epslon ) break;
            if((Math.Abs(x - xi) / Math.Max(x, 1)) < epslon) break;
        }

        return x;
    }

    private static void DebugValores(double xi, double x, double dx, double ddx)
    {
        Debug.Log("NewtonAux: xi = "+xi+", x = "+x+", dx = "+dx+", ddx = "+ddx);
    }

    public static double CalcularLambda(string _funcao)
    {
        funcao = _funcao;

        Debug.Log("Funcao = "+funcao);

        double res = 0;

        try{
            res = Algoritmo();
        }catch{
            Debug.Log("Erro no cálculo da função!");
        }

        Debug.Log("lambda = "+res);

        return Math.Round(res,4);
    }
}
