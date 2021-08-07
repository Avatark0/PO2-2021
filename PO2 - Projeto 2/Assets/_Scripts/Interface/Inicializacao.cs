using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inicializacao
{
    private static bool inicializado;

    public static bool GetInicializado()
    {
        return inicializado;
    }

    public static void SetInicializado()
    {
        inicializado = true;
    }
}
