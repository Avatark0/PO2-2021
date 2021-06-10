using System;
using UnityEngine;
using UnityEngine.UI;

public class Dicotomica : _MetodoAbstrato
{
    protected override double Algoritmo()
    {
        double x;
        double z;

        for(int i=0; i<1000000; i++)
        {
            if((b-a) >= epslon)break;

            x=((a+b)/2)-delta;
            z=((a+b)/2)+delta;
            if(FdeX.Calc(funcao,x) > FdeX.Calc(funcao,z))
            {
                a=x;
                Debug.Log("f(x) > f(z)");
            }
            else
            {
                b=z;
                Debug.Log("f(x) <= f(z)");
            }

            DebugValores(x, z);
        }

        return (a+b)/2;
    }

    private void DebugValores(double _x, double _z)
    {
        Debug.Log("a = "+a+", b = "+b+", x = "+_x+", z = "+_z+", F(x) = "+FdeX.Calc(funcao,_x)+", F(z) = "+FdeX.Calc(funcao,_z));
    }
}
