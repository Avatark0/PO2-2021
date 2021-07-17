using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class _MetodoMultVar : MonoBehaviour
{
    [SerializeField] protected GameObject InputController = default;
    [SerializeField] protected GameObject VariaveisController = default;
    [SerializeField] protected Text resultado = default;

    protected int varNum;
    protected string x1;
    protected string x2;
    protected string x3;
    protected string x4;
    protected string x5;
    
    protected string funcao;
    protected double a;
    protected double b;
    protected double delta;
    protected double epslon;
    
    protected abstract double Algoritmo();

    protected void Start(){
        if(InputValues.AreInputsSet())
        {
            InputController.GetComponent<ControllerValues>().SetTextFields();
            GetInputValues();
        }
    }

    protected void GetInputValues()
    {
        InputController.GetComponent<ControllerValues>().SetInputs();    

        funcao = InputValues.GetFuncao();
        a = InputValues.GetA();
        b = InputValues.GetB();
        delta = InputValues.GetDelta();
        epslon = InputValues.GetEpslon();
    }

    protected void GetVariaveis()
    {
        VariaveisController.GetComponent<ControllerVariaveis>().SetVars();    

        varNum = InputVariaveis.GetVarNum();
        if(varNum >= 1)
            x1 = InputVariaveis.GetVar(1);
        if(varNum >= 2)
            x2 = InputVariaveis.GetVar(2);
        if(varNum >= 3)
            x3 = InputVariaveis.GetVar(3);
        if(varNum >= 4)
            x4 = InputVariaveis.GetVar(4);
        if(varNum >= 5)
            x5 = InputVariaveis.GetVar(5);
    }

    public void Calcular()
    {
        GetVariaveis();
        GetInputValues();

        Debug.Log("VarNum = "+varNum+", x1 = "+x1+", x2 = "+x2+", x3 = "+x3+", x4 = "+x4+", x5 = "+x5);
        Debug.Log("Funcao = "+funcao+", a = "+a+", b = "+b+", delta = "+delta+", epslon = "+epslon);

        double res = 0;

        try{
            res = Algoritmo();
        }catch{
            Debug.Log("Erro no cálculo da função!");
        }

        resultado.text = Math.Round(res,4).ToString();
    }
}

