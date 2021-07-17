using UnityEngine.UI;
using UnityEngine;

public class ControllerVariaveis : MonoBehaviour
{
    [SerializeField] private InputField varNum = default;
    [SerializeField] private InputField x1 = default;
    [SerializeField] private InputField x2 = default;
    [SerializeField] private InputField x3 = default;
    [SerializeField] private InputField x4 = default;
    [SerializeField] private InputField x5 = default;

    public void SetVars()
    {
        try{
            InputVariaveis.SetVarNum(varNum.text);
        }catch{
            Debug.Log("InputVariaveis: Erro no input de varNum!");
        }

        int n = InputVariaveis.GetVarNum();
        
        if(n>=1){
            try{
                InputVariaveis.SetVar(1, x1.text);
            }catch{
                Debug.Log("InputVariaveis: Erro no input de x1!");
            }
        }
        if(n>=2){
            try{
                InputVariaveis.SetVar(2, x2.text);
            }catch{
                Debug.Log("InputVariaveis: Erro no input de x2!");
            }
        }
        if(n>=3){
            try{
                InputVariaveis.SetVar(3, x3.text);
            }catch{
                Debug.Log("InputVariaveis: Erro no input de x3!");
            }
        }
        if(n>=4){
            try{
                InputVariaveis.SetVar(4, x4.text);
            }catch{
                Debug.Log("InputVariaveis: Erro no input de x4!");
            }
        }
        if(n>=5){
            try{
                InputVariaveis.SetVar(5, x5.text);
            }catch{
                Debug.Log("InputVariaveis: Erro no input de x5!");
            }
        }

        InputVariaveis.VarsAreSet();
    }

    public void SetTextFields()
    {
        varNum.text = InputVariaveis.GetVarNumString();
        int n = InputVariaveis.GetVarNum();
        for(int i=1; i<=n; i++){
            switch(i){
                case 1: x1.text = InputVariaveis.GetVar(i); ; break;
                case 2: x2.text = InputVariaveis.GetVar(i); ; break;
                case 3: x3.text = InputVariaveis.GetVar(i); ; break;
                case 4: x4.text = InputVariaveis.GetVar(i); ; break;
                case 5: x5.text = InputVariaveis.GetVar(i); ; break;
            }
        }
    }

    public void LimparVars()
    {
        varNum.text="";
        x1.text="";
        x2.text="";
        x3.text="";
        x4.text="";
        x5.text="";

        InputVariaveis.ResetVars();
    }
}
