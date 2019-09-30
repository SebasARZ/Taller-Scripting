using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class  Habilidad : MonoBehaviour
{

    float tiempodeEspera=0;
   
    public abstract void EjecutarHabilidad();

    [SerializeField] float incremento = 1;
    [SerializeField] int nivel = 0;
    

    public float Incremento { get => incremento * (1 + nivel); set => incremento = value; }
    public float TiempodeEspera { get => TiempodeEspera; set => tiempodeEspera=value; }

    public int Nivel
    {
        get => nivel;
        set
        {
            nivel = nivel + value <= 3 ? value : 3;
        }
    }

    
}
