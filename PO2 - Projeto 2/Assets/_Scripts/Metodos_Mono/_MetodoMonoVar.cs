using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class _MetodoMonoVar : MonoBehaviour
{
    [SerializeField] protected GameObject InputController = default;
    [SerializeField] protected Text resultado = default;
    
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

    public void Calcular()
    {
        GetInputValues();

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
