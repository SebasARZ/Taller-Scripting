using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] float speed, recolectarMonedaA, recolectarMonedaB, probabilidadMonedaA = 85f,probabilidadMonedaB = 100f;
    [SerializeField] puntodeRuta puntodeRuta;
    [SerializeField] int vidaEnemigo;
    bool mejorar = true;
    float numeroAleatorio;
    private Transform target;
    private int indicePuntodeRuta = 0;


    private void Start()
    {

        target = puntodeRuta.points[0];
        
        recolectarMonedaA = ((Level.Nivel - 1) * 10);
        recolectarMonedaB = ((Level.Nivel - 1 )* 10);


    }
    private void Update()

    {
        numeroAleatorio = Random.Range(1f, 100f);
        Mejoras();
        moverEnemigo();
    }
    private void moverEnemigo()
    {
        
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position,target.position)<=0.4f)
        {
            llevaraSiguientepunto();
        }

    }
    private void llevaraSiguientepunto()
    {
        if (indicePuntodeRuta>=puntodeRuta.points.Length-1)
        {
            waveSpawner.cantidadEnemigos --;                 
            Destroy(gameObject);
            return;
        }
        indicePuntodeRuta++;
        target = puntodeRuta.points[indicePuntodeRuta];
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Bala")
        { 
            vidaEnemigo -= other.gameObject.GetComponent<Bala>().DamaRef* Player.MejoraHabiBarrido;
            if (vidaEnemigo<=0)
            {
                Moneda();
                Level.enemigosMuertos++;
                waveSpawner.cantidadEnemigos--;
                Destroy(gameObject,0.1f);
            }
        }
        if (other.tag == "Barrera")
        {
            Moneda();
            Level.enemigosMuertos++;
            waveSpawner.cantidadEnemigos--;
            Destroy(gameObject,0.1f);
            Debug.Log("Collisionando con barrera");

        }
    }


    void Mejoras()
    {
        if(Level.Nivel > 0 && mejorar)
        {
        speed = speed *(1+Level.Nivel);
        vidaEnemigo = vidaEnemigo*(1+Level.Nivel);
        mejorar = false;
        }
    }

    public void RecibirDanno(int dmg)
    {
        vidaEnemigo -= dmg*Player.MejoraHabiBarrido;
        print("Recibiendo daño AOE");
    }
    void Moneda()
    {
        if (numeroAleatorio>0&&numeroAleatorio <= probabilidadMonedaA)
        {
            Debug.Log("Random = " + numeroAleatorio);
            Player.monedaA += recolectarMonedaA;
        }
        if (numeroAleatorio> probabilidadMonedaA&&numeroAleatorio<=probabilidadMonedaB)
        {
            Player.monedaB += recolectarMonedaB;
        }
        Debug.Log("MonedaA = " + recolectarMonedaA);
        Debug.Log("MonedaB = " + recolectarMonedaB);

    }



}
