using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadUniforme()
    {
        SceneManager.LoadScene("Uniforme");
    }
    
    public void LoadDicotomica()
    {
        SceneManager.LoadScene("Dicotomica");
    }
    
    public void LoadAurea()
    {
        SceneManager.LoadScene("Aurea");       
    }

    public void LoadFibonacci()
    {
        SceneManager.LoadScene("Fibonacci");
    }
    
    public void LoadBissecao()
    {
        SceneManager.LoadScene("Bissecao");
    }
        
    public void LoadNewton()
    {
        SceneManager.LoadScene("Newton");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Sair()
    {
        Debug.Log("Exit application.");
        Application.Quit();
    }
}
