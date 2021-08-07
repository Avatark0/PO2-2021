using System;
using UnityEngine;

namespace multiVar{
    public class HookeJeeves : _MetodoMultVar
    {
        protected override double[] Algoritmo()
        {
            int k=1, j=0, n=varNum;
            double lambda;

            double[] y2 = new double[n];
            for(int i=0; i<n; i++){
                y2[i]=xIni[i];
            }

            double[] y1 = y2;
            double[] resultado = new double[n];

            for(k=1;k<10;k++){
                //Busca Exploratória (CC):
                for(j=0; j<n; j++){
                    y1=y2;

                    //construir funcao (string) de lambda (lambda é representado por l na string)
                    string aux;
                    string fDeY = "";

                    for(int i=0; i<n; i++){
                        if(i==j){
                            aux = "(" + y1[i].ToString() + " + l)";
                            fDeY = FdeXY.SubstituiVars(funcao, vars[i], aux);
                        }
                    }

                    for(int i=0; i<n; i++){
                        if(i!=j){
                            aux = "(" + y1[i].ToString() + ")";
                            fDeY = FdeXY.SubstituiVars(fDeY, vars[i], aux);
                        } 
                    }

                    //utilizar um metodo monovariavel para minimizar lambda (xj inicial utilizado como ponto inicial de Newton)
                    lambda = NewtonAuxiliar.CalcularLambda(fDeY, y1[j]);
                    
                    for(int i=0; i<n; i++){
                        y2[i] = y1[i];
                        if(i==j) y2[i] += lambda;
                    }
                }

                //Condicao de Parada:
                double cp=0;
                for(int i=0; i<varNum; i++){
                    cp += Math.Pow(y2[i]-y1[i],2);
                } 
                cp = Math.Sqrt(cp);
                if(cp < epslon){
                    break;
                } 

                //Busca Conjugada:
                double[] dir = new double[varNum];
                for(int i=0; i<varNum; i++){
                    dir[i]=y2[i]-y1[i];
                }

                //construir funcao (string) de lambda
                string yConj;
                string fDeYConj = "";

                for(int i=0; i<varNum; i++){
                    yConj = "((" + y2[i].ToString() + ") + (l * " + dir[i].ToString() + "))";
                    fDeYConj = FdeXY.SubstituiVars(funcao, vars[i], yConj);
                }

                //utilizar um metodo monovariavel para minimizar lambda
                lambda = NewtonAuxiliar.CalcularLambda(fDeYConj, y2[0]);

                for(int i=0; i<varNum; i++){
                    y2[i] += lambda*dir[i];
                }
            }

            resultado = y2;
            
            return resultado;
        }
    }
}
