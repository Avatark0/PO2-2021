using UnityEngine;
using UnityEngine.UI;

public class OcultaInputs : MonoBehaviour
{
    [SerializeField] private GameObject ocultaX3;
    [SerializeField] private GameObject ocultaX4;
    [SerializeField] private GameObject ocultaX5;

    [SerializeField] private InputField numeroDeVariaveis;

    private string numVarString;
    private int varNum;

    private void Start()
    {
        numVarString = numeroDeVariaveis.text;
        if(int.TryParse(numeroDeVariaveis.text, out varNum)){
            //varNum = int.Parse(numeroDeVariaveis.text);
            Toggle(varNum);
        }
        else
            Toggle(2);
    }

    private void Update()
    {
        string newVar = numeroDeVariaveis.text;
        if(numVarString != newVar){
            numVarString = newVar;
            
            if(int.TryParse(numeroDeVariaveis.text, out varNum)){
                //varNum = int.Parse(numeroDeVariaveis.text);
                Toggle(varNum);
            }
        }
    }

    public void Toggle(int varNum){
        if(varNum<3)
            ocultaX3.SetActive(true);
        else
            ocultaX3.SetActive(false);
            
        if(varNum<4)
            ocultaX4.SetActive(true);
        else
            ocultaX4.SetActive(false);
        
        if(varNum<5)
            ocultaX5.SetActive(true);
        else
            ocultaX5.SetActive(false);

    }
}
