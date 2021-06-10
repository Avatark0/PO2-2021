using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instrucoes : MonoBehaviour
{
    [SerializeField] private GameObject PainelInstrucoes = default;

    private void Start()
    {
        if(!Inicializacao.GetInicializado())
        {
            PainelInstrucoes.SetActive(true);
            Inicializacao.SetInicializado();
        }
        else
        {
            PainelInstrucoes.SetActive(false);
        }
    }

    public void Entendido()
    {
        PainelInstrucoes.SetActive(false);
    }

    public void MostrarInstrucoes()
    {
        PainelInstrucoes.SetActive(true);
    }
}
