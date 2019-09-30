using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveSpawner : MonoBehaviour
{




    [SerializeField] Transform prefabEnemigo;
    [SerializeField] Transform prefabEnemigo2;
    [SerializeField] Transform prefabEnemigo3;
    [SerializeField] float tiemponetreOleadas = 3f;
    [SerializeField] Transform puntodeOleada;
    [SerializeField] Transform puntodeOleada2;
    [SerializeField] Transform puntodeOleada3;

    private bool enemigo1 = true;
    private bool enemigo2 = false;
    private bool enemigo3 = false;

    private float countDown = 3f;
    private int numOla = 1;

    public static int cantidadEnemigos = 0;

    private void Update()
    {
        if (countDown <= 0f)
        {
            generarOla();
            countDown = tiemponetreOleadas;
        }
        countDown -= Time.deltaTime;
    }
    void generarOla()
    {
        for (int i = 0; i < numOla; i++)
        {
            generarEnemigo();
        }

        numOla++;
    }
    void generarEnemigo()
    {
        if (cantidadEnemigos < 6)
        {
            if (enemigo1 == true)
            {

                Instantiate(prefabEnemigo, puntodeOleada.position, puntodeOleada.rotation);
                enemigo1 = false;
                enemigo2 = true;
                cantidadEnemigos++;
            }
        }
        if (cantidadEnemigos < 6)
        {
            if (enemigo2 == true)
            {
                Instantiate(prefabEnemigo2, puntodeOleada2.position, puntodeOleada2.rotation);
                enemigo2 = false;
                enemigo3 = true;
                cantidadEnemigos++;

            }
        }
        if (cantidadEnemigos < 6)
        {
            if (enemigo3 == true)
            {
                Instantiate(prefabEnemigo3, puntodeOleada3.position, puntodeOleada3.rotation);
                enemigo3 = false;
                enemigo1 = true;
                cantidadEnemigos++;
            }
        }
            

        

    }
    
    


}
    





