using System;
using UnityEngine;
using UnityEngine.UI;

public class Newton : _MetodoAbstrato
{
    protected override double Algoritmo()
    {
        double x;
        double xi;
        double dx;
        double ddx;

        x = a;

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

    private void DebugValores(double xi, double x, double dx, double ddx)
    {
        Debug.Log("xi = "+xi+", x = "+x+", dx = "+dx+", ddx = "+ddx);
    }
}