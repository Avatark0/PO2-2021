using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Derivadas
{
    public static double Dx(string funcao, double x)
    {
        double h = 0.0001 * x;
        double xUp = x + h;
        double xDw = x - h;

        xUp = FdeX.Precise(funcao, xUp);
        xDw = FdeX.Precise(funcao, xDw);

        double dx = (xUp - xDw) / (2*h);
        
        return dx;
    }

    public static double Ddx(string funcao, double x)
    {
        double h = 0.01 * x;
        double xh = x + h;
        double x2h = x + 2*h;

        double fx2h = FdeX.Precise(funcao, x2h);
        double fxh = FdeX.Precise(funcao, xh);
        double fx = FdeX.Precise(funcao, x);

        double dx1 = (fx2h-fxh)/h;
        double dx2 = (fxh-fx)/h;
        double ddx = (dx1 - dx2)/h;
        
        return ddx;
    }
}
