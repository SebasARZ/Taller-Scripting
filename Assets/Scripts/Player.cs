using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float salud;
    [SerializeField] GameObject shot;
    [SerializeField] GameObject shotAOE;
    [SerializeField] GameObject shotBarrido;
    [SerializeField] GameObject Barrera;
    [SerializeField] Transform shotSpaw;
    [SerializeField] Transform shotSpawBarrido;
    [SerializeField] Transform spawBarrera;
    [SerializeField] float fireRate;
    [SerializeField] GameObject End;
    [SerializeField] public static float monedaA = 0, monedaB = 0;

    static int mejoraHabiBarrido=1;
    static int mejoraTiempoUso = 1;
    static int mejoraTiempoUsoBerserk = 1;
    static int mejorTiempoUsoBarrera = 1;
    static int tiempoDevidaHabilidad=5;
    static int tiemorVidaHabilidadBerserk = 5;
    static int cantDeImpactos=0;


    private float nextFire;
    private Rigidbody rb;
    private Transform target;
    private bool barrDisponible = true;
    private float contTiempoDeVida;

    public static Player instance;

    public static int MejoraHabiBarrido { get => mejoraHabiBarrido; set => mejoraHabiBarrido = value; }
    public static int MejoraTiempoUsoBarrido { get => mejoraTiempoUso; set => mejoraTiempoUso = value; }
    public static int TiempoDevidaHabilidad { get => tiempoDevidaHabilidad; set => tiempoDevidaHabilidad = value; }
    public static int MejoraTiempoUsoBerserk { get => mejoraTiempoUsoBerserk; set => mejoraTiempoUsoBerserk = value; }
    public static int CantDeImpactos { get => cantDeImpactos; set => cantDeImpactos = value; }
    public static int MejorTiempoUsoBarrera { get => mejorTiempoUsoBarrera; set => mejorTiempoUsoBarrera = value; }
    public static int TiemorVidaHabilidadBerserk { get => tiemorVidaHabilidadBerserk; set => tiemorVidaHabilidadBerserk = value; }

    private void Awake()
    {
        tiemorVidaHabilidadBerserk = 5;
        tiempoDevidaHabilidad = 5;
        cantDeImpactos = 5;
        mejoraHabiBarrido = 1;
        tiempoDevidaHabilidad = 5;
        contTiempoDeVida = 0;
        if (instance != null)
        {
            Debug.LogError("More than one disparoAutomatico in scene");
            return;
            
        }
        instance = this;
        
    }

    private void Update()
    {
        Debug.Log("MonedaA = " + monedaA);
        Debug.Log("MonedaB = " + monedaB);
        print(cantDeImpactos);
        disparo();
        disparoAumentado();
        contTiempoDeVida += Time.deltaTime;
       
    }

    void disparo()
    {
        if (Time.time > nextFire)
        {
           nextFire = Time.time + fireRate;
           GameObject proyectil = null;

            MejoraAOE mejAOE = GetComponent<MejoraAOE>();
            if (mejAOE!=null)
            {
                proyectil = Instantiate(shotAOE, shotSpaw.position, shotSpaw.rotation);
                proyectil.GetComponent<AOE>().Radio *= mejAOE.Incremento;
            }
            else
            {
                proyectil = Instantiate(shot, shotSpaw.position, shotSpaw.rotation);
            }

            velocidadProyectilMejora vel = GetComponent<velocidadProyectilMejora>();
            if (vel != null)
            {
                proyectil.GetComponent<Bala>().Speed += vel.Incremento;
            }
            incrementoDaño increDano = GetComponent<incrementoDaño>();
            if (increDano!=null)
            {
                proyectil.GetComponent<Bala>().DamaRef += (int)increDano.Incremento;
            }
            Berserk tripleVel = GetComponent<Berserk>();
            if (tripleVel!=null)
            {
                if (contTiempoDeVida<=tiemorVidaHabilidadBerserk)
                {
                    proyectil.GetComponent<Bala>().Speed *= 3;                    
                    
                }
                if (contTiempoDeVida >= tiempoDevidaHabilidad)
                {
                    contTiempoDeVida = 0;
                }

            }
           
        }
    }
    void disparoAumentado()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            nextFire = nextFire / 5;
        }
    }



    public void ShotBarrido()
    {
        GameObject balaBarrido;
        Barrido disBarrido = GetComponent<Barrido>();
        


        if (disBarrido != null)
        {
            balaBarrido = Instantiate(shotBarrido, shotSpawBarrido.position, shotSpawBarrido.rotation);
            //proyectil.GetComponent<Bala>().DamaRef += (int)increDano.Incremento;

        }
               
        

    }
      public void ActivarBarrera()
    {
        GameObject barrera;
        Barrera actBarrera = GetComponent<Barrera>();
        if (actBarrera != null)
        {
            barrera = Instantiate(Barrera, spawBarrera.position, spawBarrera.rotation);
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            waveSpawner.cantidadEnemigos--;
            salud--;
            Debug.Log("Salud = " + salud);
            if (salud <= 0)
            {
                End.SetActive(true);
                salud = 0;
            }
        }

    }
}
