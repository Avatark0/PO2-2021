using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using B83.ExpressionParser;

/*
var parser = new ExpressionParser();
Expression exp = parser.EvaluateExpression("(5+3)*8^2-5*(-2)");
Debug.Log("Result: " + exp.Value);  // prints: "Result: 522"
*/

public class PassExpressionButton : MonoBehaviour
{
    [SerializeField] private InputField myIF = default;
    [SerializeField] private Text resultado = default;
    
    [SerializeField] private string myExpression;

    public void PassExpressionToParser()
    {
        myExpression = myIF.text;
        Debug.Log(myExpression);

        //f(x) = x+x^2+x^3
        //a = 3 e b = 6, delta = 0.1, lambda = 0.2;
        //f(3) = 3+3^2+3^3 = 
        
        var parser = new ExpressionParser();
        Expression exp = parser.EvaluateExpression(myExpression);
        Debug.Log("Result: " + exp.Value);

        resultado.text = exp.Value.ToString();
    }

    //public static void  
}
