using UnityEngine.UI;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private InputField inputFuncao = default;
    [SerializeField] private InputField inputA = default;
    [SerializeField] private InputField inputB = default;
    [SerializeField] private InputField inputDelta = default;
    [SerializeField] private InputField inputEpslon = default;

    [SerializeField] private Text resultado = default;

    public void SetInputs()
    {
        try{
            InputValues.SetFuncao(inputFuncao.text);
        }catch{
            Debug.Log("InputController: Erro no input da funcao!");
        }
        try{
            InputValues.SetA(inputA.text);
        }catch{
            Debug.Log("InputController: Erro no input de A!");
        }
        try{
            InputValues.SetB(inputB.text);
        }catch{
            Debug.Log("InputController: Erro no input de B!");
        }

        if(inputDelta!=null)
        {
            try{
                InputValues.SetDelta(inputDelta.text);
            }catch{
                Debug.Log("InputController: Erro no input de Delta!");
            }
        }

        if(inputEpslon!=null)
        {
            try{
                InputValues.SetEpslon(inputEpslon.text);
            }catch{
                Debug.Log("InputController: Erro no input de Epslon!");
            }
        }

        InputValues.InputsAreSet();
    }

    public void SetTextFields()
    {
        inputFuncao.text=InputValues.GetFuncao();
        inputA.text=InputValues.GetAString();
        inputB.text=InputValues.GetBString();
        if(inputDelta!=null)inputDelta.text=InputValues.GetDeltaString();
        if(inputEpslon!=null)inputEpslon.text=InputValues.GetEpslonString();
    }

    public void LimparInputs()
    {
        inputFuncao.text="";
        inputA.text="";
        inputB.text="";
        if(inputDelta!=null)
            inputDelta.text="";
        if(inputEpslon!=null)
            inputEpslon.text="";
        
        resultado.text="";

        InputValues.ResetInputs();
    }
}
