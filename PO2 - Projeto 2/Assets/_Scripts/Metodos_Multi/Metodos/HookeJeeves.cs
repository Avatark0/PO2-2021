using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace multiVar{
    public class HookeJeeves : _MetodoMultVar
    {
        protected override Vector2 Algoritmo()
        {
            int k=1, j=1, n=2;
            double lambda;
            Vector2 y2 = new Vector2((float)x1Ini, (float)x2Ini);
            Vector2 y1 = y2;

            Vector2 resultado;

            for(k=1;k<10;k++){
                //Busca Exploratória (CC)
                for(j=1; j<=n; j++){
                    y1=y2;

                    if(j==1){
                        //construir funcao (string) de lambda
                        string y = "(" + y1.x.ToString() + " + x)";
                        string fDeY = FdeXY.SubstituiVars(funcao, x1, y);                

                        y = "(" + y1.y.ToString() + ")";
                        fDeY = FdeXY.SubstituiVars(fDeY, x2, y);

                        //utilizar um metodo monovariavel para minimizar lambda
                        Debug.Log("HookeJeeves: funcao j1 = "+fDeY);
                        lambda = NewtonAuxiliar.CalcularLambda(fDeY);
                        
                        y2 = new Vector2(y1.x + (float)lambda, y1.y);
                    }
                    else if(j==2){
                        //construir funcao (string) de lambda
                        string y = "(" + y1.x.ToString() + ")";
                        string fDeY = FdeXY.SubstituiVars(funcao, x1, y);                

                        y =  "(" + y1.y.ToString() + " + x)";
                        fDeY = FdeXY.SubstituiVars(fDeY, x2, y);

                        //utilizar um metodo monovariavel para minimizar lambda
                        Debug.Log("HookeJeeves: funcao j2 = "+fDeY);
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
                string yConj = "(" + y2.x.ToString() + " + x * " + dir.x.ToString() + ")";
                string fDeYConj = FdeXY.SubstituiVars(funcao, "x", yConj);       

                yConj = "(" + y1.y.ToString() + " + x * " + dir.x.ToString() + ")";
                fDeYConj = FdeXY.SubstituiVars(fDeYConj, "x", yConj);

                //utilizar um metodo monovariavel para minimizar lambda
                Debug.Log("HookeJeeves: funcao conj = "+fDeYConj);
                lambda = NewtonAuxiliar.CalcularLambda(fDeYConj);

                y2.x = y2.x + (float)lambda * dir.x;
                y2.y = y2.y + (float)lambda * dir.y;

                //Metodo de parada? 
            }

            resultado = new Vector2(y2.x, y2.y);
            
            return resultado;
        }
    }
}
