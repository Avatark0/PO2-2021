using System;
using UnityEngine;
using UnityEngine.UI;

public class Fibonacci : _MetodoAbstrato
{
    protected override double Algoritmo()
    {
        double mi;
        double lamb;
        
        float fn;
        float[] fib = new float[50];
        int i;

        fn = (float)((b - a)/epslon);
        fib[0] = 1;
        fib[1] = 1;
        
        for(i=1; true; i++)
        {
            if(Convert.ToDouble(fib[i]) > fn)break;//for loop não aceita comparação entre doubles (ou floats) como condição de parada
            fib[i+1] = fib[i] + fib[i-1];
        }

        mi = a + (fib[i-2] / fib[i]) * (b-a);
        lamb = a + (fib[i-1] / fib[i]) * (b-a);

        for(int k=1; k <= i-2; k++)
        {
            if(FdeX.Calc(funcao,mi) > FdeX.Calc(funcao,lamb))
            {
                a = mi;
                mi = lamb;
                lamb = a + (fib[i-k-1] / fib[i-k]) * (b-a);
            }
            else
            {
                b = lamb;
                lamb = mi;
                mi = a + (fib[i-k-2] / fib[i-k]) * (b-a);
            }
            //DebugValores(mi,lamb);
        }

        if(FdeX.Calc(funcao,mi) > FdeX.Calc(funcao,lamb))
            a = mi;
        else
            b = lamb;

        return (a+b)/2;
    }

    private void DebugValores(double _mi, double _lamb)
    {
        Debug.Log("a = "+a+", b = "+b+", mi = "+_mi+", lamb = "+_lamb+", F(mi) = "+FdeX.Calc(funcao,_mi)+", F(lamb) = "+FdeX.Calc(funcao,_lamb));
    }
}
