using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using B83.ExpressionParser;

public class PassExpressionButton : MonoBehaviour
{
    [SerializeField] private InputField myIF = default;
    [SerializeField] private Text resultado = default;
    
    [SerializeField] private string myExpression;

    public void PassExpressionToParser()
    {
        myExpression = myIF.text;
        Debug.Log(myExpression);
        
        var parser = new ExpressionParser();
        Expression exp = parser.EvaluateExpression(myExpression);

        resultado.text = exp.Value.ToString();
    }
}
