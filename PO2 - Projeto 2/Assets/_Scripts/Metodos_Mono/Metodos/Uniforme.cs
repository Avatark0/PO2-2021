using System;
using UnityEngine;
using UnityEngine.UI;

namespace MonoVar{
    public class Uniforme : _MetodoMonoVar
    {
        protected override double Algoritmo()
        {
            double x0;
            double x1;
            int i;

            //Aproximacao Inicial
            for(i=0; a+delta < b; i++)
            {
                x0 = FdeX.Calc(funcao, a);
                x1 = FdeX.Calc(funcao, a+delta);
                
                DebugValores(x0, x1);
                
                if(x1 < x0)
                {
                    a=a+delta;
                }
                else break;
            }

            //Refinamento
            if(i>1)a-=delta;
            delta/=10;
            
            for(i=0; a+delta < b; i++)
            {
                x0 = FdeX.Calc(funcao, a);
                x1 = FdeX.Calc(funcao, a+delta);
                
                DebugValores(x0, x1);
                
                if(x1 < x0)
                {
                    a=a+delta;
                }
                else break;
            }

            return a;
        }

        private void DebugValores(double _x0, double _x1)
        {
            Debug.Log("x ="+a+", f(x) = "+_x0+", xk = "+(a+delta)+", f(xk) = "+_x1);
        }
    }
}