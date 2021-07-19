using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class _MetodoMultVar : MonoBehaviour
{
    [SerializeField] protected GameObject controllerMultiVar = default;
    [SerializeField] protected GameObject resultado = default;

    protected int varNum;

    protected string x1;
    protected string x2;
    protected string x3;
    protected string x4;
    protected string x5;
    
    protected string funcao;
    
    protected double x1Ini;
    protected double x2Ini;
    protected double x3Ini;
    protected double x4Ini;
    protected double x5Ini;

    protected double epslon;

    protected double x1otimo;
    protected double x2otimo;
    protected double x3otimo;
    protected double x4otimo;
    protected double x5otimo;
    
    protected abstract Vector2 Algoritmo();

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
        if(varNum >= 1)
            x1 = InputMultiVar.GetVar(1);
        if(varNum >= 2)
            x2 = InputMultiVar.GetVar(2);
        if(varNum >= 3)
            x3 = InputMultiVar.GetVar(3);
        if(varNum >= 4)
            x4 = InputMultiVar.GetVar(4);
        if(varNum >= 5)
            x5 = InputMultiVar.GetVar(5);

        funcao = InputMultiVar.GetFuncao();
        
        if(varNum >= 1)
            x1Ini = InputMultiVar.GetValInicial(1);
        if(varNum >= 2)
            x2Ini = InputMultiVar.GetValInicial(2);
        if(varNum >= 3)
            x3Ini = InputMultiVar.GetValInicial(3);
        if(varNum >= 4)
            x4Ini = InputMultiVar.GetValInicial(4);
        if(varNum >= 5)
            x5Ini = InputMultiVar.GetValInicial(5);

        epslon = InputMultiVar.GetEpslon();
    }

    public void Calcular()
    {
        GetInputValues();

        Debug.Log("VarNum = "+varNum+", x1 = "+x1+", x2 = "+x2+", x3 = "+x3+", x4 = "+x4+", x5 = "+x5);
        Debug.Log("funcao = "+funcao);
        Debug.Log("x1Ini = "+x1Ini+", x2Ini = "+x2Ini+", x3Ini = "+x3Ini+", x4Ini = "+x4Ini+", x5Ini = "+x5Ini);
        Debug.Log("epslon = "+epslon);

        Vector2 res = new Vector2(0,0);

        try{
            res = Algoritmo();
        }catch{
            Debug.Log("Erro no cálculo da função!");
        }

        for(int i=0; i<varNum; i++){
            //Mudar vetor de Vector2 para double[]
            if(i==0)resultado.transform.GetChild(i).GetComponent<InputField>().text = Math.Round(res.x,4).ToString();
            else resultado.transform.GetChild(i).GetComponent<InputField>().text = Math.Round(res.y,4).ToString();
        }

        Debug.Log("x1otimo = "+x1otimo+", x2otimo = "+x2otimo+", x3otimo = "+x3otimo+", x4otimo = "+x4otimo+", x5otimo = "+x5otimo);
    }
}

