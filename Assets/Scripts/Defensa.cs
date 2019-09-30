using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defensa : MonoBehaviour
{
  private float  countTime ;
  private int hits=0;
  

    private void Update()
    {
        countTime += Time.deltaTime;
        
        if ( hits>= Player.CantDeImpactos || countTime >= Player.TiempoDevidaHabilidad)
        {
            Destroy(gameObject);
        }
        print(countTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collisionado con todo");
        if (other.tag == "Enemy")
        {
            Debug.Log("Collisionado con enemigo");
            hits++;
            
        }
        
    }




}
