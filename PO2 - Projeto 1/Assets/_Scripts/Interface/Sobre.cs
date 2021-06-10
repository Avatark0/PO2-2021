using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sobre : MonoBehaviour
{
    [SerializeField] private GameObject PainelSobre = default;

    private void Start()
    {
        PainelSobre.SetActive(false);
    }

    public void Concordo()
    {
        PainelSobre.SetActive(false);
    }

    public void MostrarSobre()
    {
        PainelSobre.SetActive(true);
    }
}
