using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Derivadas
{
    public static double Dx(string funcao, double x)
    {
        //Debug.Log("Dx: funcao = "+funcao);
        
        double h = 0.0001 * x;
        if(x==0)h=0.0001;
        double xUp = x + h;
        double xDw = x - h;

        //Debug.Log("Dx pt1, xup = "+xUp+", xdw = "+xDw);

        xUp = FdeX.PreciseLambda(funcao, xUp);
        xDw = FdeX.PreciseLambda(funcao, xDw);

        //Debug.Log("Dx pt2, xup = "+xUp+", xdw = "+xDw);

        double dx = (xUp - xDw) / (2*h);

        return dx;
    }

    public static double Ddx(string funcao, double x)
    {
        //Debug.Log("Ddx: funcao = "+funcao);

        double h = 0.01 * x;
        if(x==0)h=0.01;
        double xh = x + h;
        double x2h = x + 2*h;

        double fx2h = FdeX.PreciseLambda(funcao, x2h);
        double fxh = FdeX.PreciseLambda(funcao, xh);
        double fx = FdeX.PreciseLambda(funcao, x);

        double dx1 = (fx2h-fxh)/h;
        double dx2 = (fxh-fx)/h;
        double ddx = (dx1 - dx2)/h;
        
        return ddx;
    }
}
