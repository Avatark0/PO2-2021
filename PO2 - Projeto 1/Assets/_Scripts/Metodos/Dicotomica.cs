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
            if((b-a) < epslon)break;

            x=((a+b)/2)-delta;
            z=((a+b)/2)+delta;

            DebugValores(x, z);

            if(FdeX.Calc(funcao,x) > FdeX.Calc(funcao,z))
            {
                a=x;
            }
            else
            {
                b=z;
            }
        }

        return (a+b)/2;
    }

    private void DebugValores(double _x, double _z)
    {
        float ba = (float)b-(float)a;
        Debug.Log("a = "+a+", b = "+b+", b-a = "+ba+", x = "+_x+", z = "+_z+", F(x) = "+FdeX.Calc(funcao,_x)+", F(z) = "+FdeX.Calc(funcao,_z));
    }
}
