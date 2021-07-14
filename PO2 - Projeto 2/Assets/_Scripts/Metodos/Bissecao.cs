using System;
using UnityEngine;
using UnityEngine.UI;

public class Bissecao : _MetodoAbstrato
{
    protected override double Algoritmo()
    {
        double ai;
        double bi;
        double xi;
        double dx;
        
        ai = a;
        bi = b;
        xi = (ai+bi)/2;

        DebugValores(ai, bi, 0, 0);

        for(int i=0; true; i++)
        {
            if((bi - ai) < epslon)break;

            dx = Derivadas.Dx(funcao, xi);

            if(dx == 0) return xi;
            else if(dx > 0)
            {
                bi = xi;
                xi = (ai+bi)/2;
            }
            else
            {
                ai = xi;
                xi = (ai+bi)/2;
            }

            DebugValores(ai, bi, xi, dx);
        }

        return xi;
    }

    private void DebugValores(double ai, double bi, double xi, double dx)
    {
        Debug.Log("ai = "+ai+", bi = "+bi+", xi = "+xi+", dx = "+dx);
    }
}