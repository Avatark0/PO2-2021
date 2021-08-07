using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class _MetodoMultVar : MonoBehaviour
{
    [SerializeField] protected GameObject controllerMultiVar = default;
    [SerializeField] protected GameObject resultado = default;

    protected int varNum;

    protected string[] vars = new string[5]{"","","","",""};
    
    protected string funcao;
    
    protected double[] xIni = new double[5]{0,0,0,0,0};

    protected double epslon;
    
    protected abstract double[] Algoritmo();

    protected void Start(){
        if(InputMultiVar.AreInputsSet())
        {
            controllerMultiVar.GetComponent<ControllerMultiVar>().SetTextFields();
            GetInputValues();
        }
    }

    protected void GetInputValues()
    {
        controllerMultiVar.GetComponent<ControllerMultiVar>().SetInputs();    

        varNum = InputMultiVar.GetVarNum();
        for(int i=0; i<varNum; i++){
            vars[i]=InputMultiVar.GetVar(i+1);
        }

        funcao = InputMultiVar.GetFuncao();
        
        for(int i=0; i<varNum; i++){
            xIni[i]=InputMultiVar.GetValInicial(i+1);
        }

        epslon = InputMultiVar.GetEpslon();
    }

    public void Calcular()
    {
        GetInputValues();

        Debug.Log("VarNum = "+varNum+", var1 = "+vars[0]+", var2 = "+vars[1]+", var3 = "+vars[2]+", var4 = "+vars[3]+", var5 = "+vars[4]);
        Debug.Log("funcao = "+funcao);
        Debug.Log("x1Ini = "+xIni[0]+", x2Ini = "+xIni[1]+", x3Ini = "+xIni[2]+", x4Ini = "+xIni[3]+", x5Ini = "+xIni[4]);
        Debug.Log("epslon = "+epslon);

        double[] res = new Double[varNum];

        try{
            res = Algoritmo();
        }catch{
            Debug.Log("Erro no cálculo da função!");
        }

        for(int i=0; i<varNum; i++){
            resultado.transform.GetChild(i).GetComponent<InputField>().text = Math.Round(res[i],4).ToString();
        }

        // Debug.Log("x1otimo = "+x1otimo+", x2otimo = "+x2otimo+", x3otimo = "+x3otimo+", x4otimo = "+x4otimo+", x5otimo = "+x5otimo);
    }
}

