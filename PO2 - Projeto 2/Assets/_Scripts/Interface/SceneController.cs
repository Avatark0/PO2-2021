using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadMenu()
    {
        SceneManager.LoadScene("_Menu");
    }

    public void Sair()
    {
        Debug.Log("Exit application.");
        Application.Quit();
    }

    //Metodos Monovariáveis
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

    //Metodos Multivariáveis
    public void LoadHookeJeeves()
    {
        SceneManager.LoadScene("HookeJeeves");
    }

    public void LoadGradiente()
    {
        SceneManager.LoadScene("Gradiente");
    }

    public void LoadFletcherReeves()
    {
        SceneManager.LoadScene("FletcherReeves");
    }

    public void LoadNewtonMulti()
    {
        SceneManager.LoadScene("NewtonMulti");
    }

    public void LoadDavidonFletcherPowell()
    {
        SceneManager.LoadScene("DavidonFletcherPowell");
    }
}
