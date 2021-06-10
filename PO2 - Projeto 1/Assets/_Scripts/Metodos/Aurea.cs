using System;
using UnityEngine;
using UnityEngine.UI;

public class Aurea : _MetodoAbstrato
{
    protected override double Algoritmo()
    {
        double alfa;
        double beta;
        double mi;
        double lamb;

        alfa = (-1 + Math.Sqrt(5))/2;
        beta = 1 - alfa;
        mi = a + beta * (b-a);
        lamb = a + alfa * (b-a);

        for(int i=0; (b-a) > epslon; i++)
        {
            if(FdeX.Calc(funcao,mi) > FdeX.Calc(funcao,lamb))
            {
                a = mi;
                mi = lamb;
                lamb = a + alfa * (b-a);
            }
            else
            {
                b = lamb;
                lamb = mi;
        	    mi = a + beta * (b-a);
            }
            //DebugValores(mi, lamb);
        }

        return (a+b)/2;
    }

    private void DebugValores(double _mi, double _lamb)
    {
        Debug.Log("a = "+a+", b = "+b+", mi = "+_mi+", lamb = "+_lamb+", F(mi) = "+FdeX.Calc(funcao,_mi)+", F(lamb) = "+FdeX.Calc(funcao,_lamb));
    }
}
