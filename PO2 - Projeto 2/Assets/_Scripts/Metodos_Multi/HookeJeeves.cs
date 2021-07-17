using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookeJeeves : _MetodoMultVar
{
    protected override double Algoritmo()
    {
        int k=1, j=1, n=2;
        double lambda;
        Vector2 y2 = new Vector2((float)a, (float)b);
        Vector2 y1 = y2;

        for(k=1;k<3;k++){
            //Busca Exploratória (CC)
            for(j=1; j<=2; j++){
                y1=y2;

                if(j==1){
                    //construir funcao (string) de lambda
                    string y = y1.x.ToString() + " + " + x1;
                    string fDeY = FdeXY.SubstituiVars(funcao, x1, y);                

                    y = y1.y.ToString();
                    fDeY = FdeXY.SubstituiVars(fDeY, x2, y);

                    //utilizar um metodo monovariavel para minimizar lambda
                    lambda = NewtonAuxiliar.CalcularLambda(fDeY);
                    
                    y2 = new Vector2(y1.x + (float)lambda, y1.y);
                }
                else if(j==2){
                    //construir funcao (string) de lambda
                    string y = y1.x.ToString();
                    string fDeY = FdeXY.SubstituiVars(funcao, x1, y);                

                    y = y1.y.ToString() + " + " + x2;
                    fDeY = FdeXY.SubstituiVars(fDeY, x2, y);

                    //utilizar um metodo monovariavel para minimizar lambda
                    lambda = NewtonAuxiliar.CalcularLambda(fDeY);

                    y2 = new Vector2(y1.x, y1.y + (float)lambda);
                }
            }

            //Condicao de Parada
            double cp = Math.Sqrt(Math.Pow(y2.x-y1.x,2) + Math.Pow(y2.y-y1.y,2));
            if(cp < epslon) break;

            //Busca Conjugada
            Vector2 dir = new Vector2(y2.x-y1.x, y2.y-y1.y);

            //construir funcao (string) de lambda
            string yConj = y2.x.ToString() + " + L * " + dir.x.ToString();
            string fDeYConj = FdeXY.SubstituiVars(funcao, "L", yConj);       

            yConj = y1.y.ToString() + " + L * " + dir.x.ToString();
            fDeYConj = FdeXY.SubstituiVars(fDeYConj, "L", yConj);

            //utilizar um metodo monovariavel para minimizar lambda
            lambda = NewtonAuxiliar.CalcularLambda(fDeYConj);

            y2.x = y2.x + (float)lambda * dir.x;
            y2.y = y2.y + (float)lambda * dir.y;

            //Metodo de parada? 
        }
        
        return 0;
    }
}
