using UnityEngine.UI;
using UnityEngine;

public class ControllerMultiVar : MonoBehaviour
{
    [SerializeField] private InputField varNum = default;

    [SerializeField] private InputField varX1 = default;
    [SerializeField] private InputField varX2 = default;
    [SerializeField] private InputField varX3 = default;
    [SerializeField] private InputField varX4 = default;
    [SerializeField] private InputField varX5 = default;

    [SerializeField] private InputField inputFuncao = default;

    [SerializeField] private InputField x1Ini = default;
    [SerializeField] private InputField x2Ini = default;
    [SerializeField] private InputField x3Ini = default;
    [SerializeField] private InputField x4Ini = default;
    [SerializeField] private InputField x5Ini = default;

    [SerializeField] private InputField inputEpslon = default;

    [SerializeField] private InputField x1Fin = default;
    [SerializeField] private InputField x2Fin = default;
    [SerializeField] private InputField x3Fin = default;
    [SerializeField] private InputField x4Fin = default;
    [SerializeField] private InputField x5Fin = default;


    public void SetInputs()
    {
        try{
            InputMultiVar.SetVarNum(varNum.text);
        }catch{
            Debug.Log("InputMultiVar: Erro no input de varNum!");
        }

        int n = InputMultiVar.GetVarNum();
        
        if(n>=1){
            try{
                InputMultiVar.SetVar(1, varX1.text);
            }catch{
                Debug.Log("InputMultiVar: Erro no input de x1!");
            }
        }
        if(n>=2){
            try{
                InputMultiVar.SetVar(2, varX2.text);
            }catch{
                Debug.Log("InputMultiVar: Erro no input de x2!");
            }
        }
        if(n>=3){
            try{
                InputMultiVar.SetVar(3, varX3.text);
            }catch{
                Debug.Log("InputMultiVar: Erro no input de x3!");
            }
        }
        if(n>=4){
            try{
                InputMultiVar.SetVar(4, varX4.text);
            }catch{
                Debug.Log("InputMultiVar: Erro no input de x4!");
            }
        }
        if(n>=5){
            try{
                InputMultiVar.SetVar(5, varX5.text);
            }catch{
                Debug.Log("InputMultiVar: Erro no input de x5!");
            }
        }

        try{
            InputMultiVar.SetFuncao(inputFuncao.text);
        }catch{
            Debug.Log("ControllerValues: Erro no input da funcao!");
        }

        if(n>=1){
            try{
                InputMultiVar.SetValInicial(1, x1Ini.text);
            }catch{
                Debug.Log("InputMultiVar: Erro no input de x1!");
            }
        }
        if(n>=2){
            try{
                InputMultiVar.SetValInicial(2, x2Ini.text);
            }catch{
                Debug.Log("InputMultiVar: Erro no input de x2!");
            }
        }
        if(n>=3){
            try{
                InputMultiVar.SetValInicial(3, x3Ini.text);
            }catch{
                Debug.Log("InputMultiVar: Erro no input de x3!");
            }
        }
        if(n>=4){
            try{
                InputMultiVar.SetValInicial(4, x4Ini.text);
            }catch{
                Debug.Log("InputMultiVar: Erro no input de x4!");
            }
        }
        if(n>=5){
            try{
                InputMultiVar.SetValInicial(5, x5Ini.text);
            }catch{
                Debug.Log("InputMultiVar: Erro no input de x5!");
            }
        }

        if(inputEpslon!=null)
        {
            try{
                InputMultiVar.SetEpslon(inputEpslon.text);
            }catch{
                Debug.Log("ControllerValues: Erro no input de Epslon!");
            }
        }


        InputMultiVar.InputsAreSet();
    }

    public void SetTextFields()
    {
        varNum.text = InputMultiVar.GetVarNumString();
        int n = InputMultiVar.GetVarNum();
        for(int i=1; i<=n; i++){
            switch(i){
                case 1: varX1.text = InputMultiVar.GetVar(i); break;
                case 2: varX2.text = InputMultiVar.GetVar(i); break;
                case 3: varX3.text = InputMultiVar.GetVar(i); break;
                case 4: varX4.text = InputMultiVar.GetVar(i); break;
                case 5: varX5.text = InputMultiVar.GetVar(i); break;
            }
        }
        
        inputFuncao.text=InputMultiVar.GetFuncao();
        
        for(int i=1; i<=n; i++){
            switch(i){
                case 1: x1Ini.text = InputMultiVar.GetVar(i); break;
                case 2: x2Ini.text = InputMultiVar.GetVar(i); break;
                case 3: x3Ini.text = InputMultiVar.GetVar(i); break;
                case 4: x4Ini.text = InputMultiVar.GetVar(i); break;
                case 5: x5Ini.text = InputMultiVar.GetVar(i); break;
            }
        }

        inputEpslon.text=InputMultiVar.GetEpslonString();
    }

    public void LimparInputs()
    {
        varNum.text="";

        varX1.text="";
        varX2.text="";
        varX3.text="";
        varX4.text="";
        varX5.text="";
        
        inputFuncao.text="";

        x1Ini.text ="";
        x2Ini.text ="";
        x3Ini.text ="";
        x4Ini.text ="";
        x5Ini.text ="";

        inputEpslon.text="";

        x1Fin.text ="";
        x2Fin.text ="";
        x3Fin.text ="";
        x4Fin.text ="";
        x5Fin.text ="";

        InputMultiVar.ResetInputs();
    }
}
