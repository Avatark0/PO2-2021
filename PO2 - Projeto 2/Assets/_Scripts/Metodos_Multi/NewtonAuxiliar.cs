using System;
using UnityEngine;
using UnityEngine.UI;

public class NewtonAuxiliar
{
    private static string funcao;
    private static double epslon = 0.001;
    private static double startingPoint=1;
    
    private static double Algoritmo()
    {
        double x;
        double xi;
        double dx;
        double ddx;

        x = startingPoint;

        for(int i=0; i<100; i++)
        {
            //Debug.Log("NewtonAux: funcao = "+funcao+", x = "+x);
            dx = Derivadas.Dx(funcao, x);
            ddx = Derivadas.Ddx(funcao, x);
            
            xi = x;
            if(ddx!=0)
                x = xi - dx/ddx;
            else{
                //Debug.Log("NewtonAux: ddx=0, x recebeu xi");
                x = xi;
            }

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

    public static double CalcularLambda(string _funcao, double xIni)
    {
        funcao = _funcao;
        startingPoint=xIni;

        //Debug.Log("NewtonAux: Funcao = "+funcao);

        double res = 0;

        try{
            res = Algoritmo();
        }catch{
            Debug.Log("NewtonAux: Erro no cálculo da função!");
        }

        Debug.Log("NewtonAux: lambda = "+Math.Round(res,8));

        return Math.Round(res,8);
    }
}
