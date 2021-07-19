using UnityEngine;

public class ToggleMenu : MonoBehaviour
{
//    [SerializeField] private GameObject	Monovar;
    [SerializeField] private GameObject	Multivar;
    
    public void ButtonMonovar(){
        Multivar.SetActive(false);    
    }

    public void ButtonMultivar(){
        Multivar.SetActive(true);    
    }
}
