using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instrucoes : MonoBehaviour
{
    [SerializeField] private GameObject PainelInstrucoes = default;
    [SerializeField] private GameObject PainelTextoPg1 = default;
    [SerializeField] private GameObject PainelTextoPg2 = default;
    [SerializeField] private GameObject btEntendido = default;
    [SerializeField] private GameObject btAnterior = default;
    [SerializeField] private GameObject btProxima = default;

    private bool leuPg2 = false;

    private void Start()
    {
        if(!Inicializacao.GetInicializado())
        {
            PainelInstrucoes.SetActive(true);

            PainelTextoPg1.SetActive(true);
            PainelTextoPg2.SetActive(false);
            btEntendido.SetActive(false);
            btAnterior.SetActive(false);
            btProxima.SetActive(true);

            Inicializacao.SetInicializado();
        }
        else
        {
            PainelInstrucoes.SetActive(false);

            PainelTextoPg1.SetActive(true);
            PainelTextoPg2.SetActive(false);
            btEntendido.SetActive(true);
            btAnterior.SetActive(false);
            btProxima.SetActive(true);
        }
    }

    private void Update()
    {
        if(leuPg2)btEntendido.SetActive(true);
    }

    public void Entendido()
    {
        PainelInstrucoes.SetActive(false);
    }

    public void MostrarInstrucoes()
    {
        PainelInstrucoes.SetActive(true);

        PainelTextoPg1.SetActive(true);
        PainelTextoPg2.SetActive(false);
        btAnterior.SetActive(false);
        btProxima.SetActive(true);
    }

    public void PgProxima()
    {
        PainelTextoPg1.SetActive(false);
        PainelTextoPg2.SetActive(true);
        btAnterior.SetActive(true);
        btProxima.SetActive(false);

        leuPg2=true;
    }

    public void PgAnterior()
    {
        PainelTextoPg1.SetActive(true);
        PainelTextoPg2.SetActive(false);
        btAnterior.SetActive(false);
        btProxima.SetActive(true);
    }
}
