using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public static int Nivel = 1;
    public static int enemigosMuertos = 0;
    [SerializeField] public static int enemyPlus = 100;
    [SerializeField] Text lvlTxt;

    private void Update()
    {
        if (enemigosMuertos >= enemyPlus)
        {
            subirNivel();
            enemigosMuertos = 0;
        }
        lvlTxt.text="Nivel: "+ Nivel;

    }

    void subirNivel()
    {
            Nivel++;
        Debug.Log("Nivel" + Nivel);
    }

        
}
