using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tienda : MonoBehaviour
{



    Player player;
    private bool barrDisponible = true;
    private float Tespera = 0;
    private int contMaxMejora=0;
    private float tiempoMaximoEsperaBarrera = 8f;
    private float tiempoMaximoEsperaBerserk = 4f;
    private float tiempoMaximoEsperaBarrido = 5f;
    
    private void Start()
    {
        player = Player.instance;
        

    }
    void Update()
    {
        print(Player.TiempoDevidaHabilidad);
       
        Tespera += Time.deltaTime;
    }
    public void AddMejora(int index)
    {
        switch (index)
        {
            case 0:
                GameObject p = GameObject.FindWithTag("Player");
                Component c = p.GetComponent<incrementoDaño>();
                if (c != null)
                {
                    ((incrementoDaño)c).Nivel++;
                }
                else
                {
                    c = p.AddComponent(typeof(incrementoDaño));
                }

                break;
            case 1:
                GameObject a = GameObject.FindWithTag("Player");
                Component co = a.GetComponent<velocidadProyectilMejora>();
                if (co != null)
                {
                    ((velocidadProyectilMejora)co).Nivel++;
                }
                else
                {
                    co = a.AddComponent(typeof(velocidadProyectilMejora));
                }


                break;
            case 2:
                GameObject b = GameObject.FindWithTag("Player");
                Component com = b.GetComponent<MejoraAOE>();
                if (com != null)
                {
                    ((MejoraAOE)com).Nivel++;
                }
                else
                {
                    com = b.AddComponent(typeof(MejoraAOE));
                }

                break;
            default:
                break;
        } 
    }
   public void UsarHabilidad(int index)
    {
        switch (index)
        {
            case 0:
                GameObject p = GameObject.FindWithTag("Player");
                Component c = p.GetComponent<Berserk>();                              
                c = p.AddComponent(typeof(Berserk));


                break;
            case 1:
                GameObject a = GameObject.FindWithTag("Player");
                Component co = a.GetComponent<Barrido>();             
                co = a.AddComponent(typeof(Barrido));             
                
                if (barrDisponible= true &&Tespera>= tiempoMaximoEsperaBarrido)
                {
                    player.ShotBarrido();
                    barrDisponible = false;
                    Tespera = 0f;                    
                }
                
                if (Tespera<= tiempoMaximoEsperaBarrido)
                {                    
                    barrDisponible = true;
                }



                break;
            case 2:
                GameObject b = GameObject.FindWithTag("Player");
                Component com = b.GetComponent<Barrera>();
                com = b.AddComponent(typeof(Barrera));
                Barrera defensa = GetComponent<Barrera>();                              
                player.ActivarBarrera();            

                break;
            default:
                break;
                
        }

        
    }
    public void MejorarHabilidad(int index)
    {
        switch (index)
        {
            case 0:
                if (contMaxMejora < 3)
                {
                    Player.MejoraHabiBarrido += 5;
                    contMaxMejora++;
                    tiempoMaximoEsperaBarrido -=Player.MejoraTiempoUsoBarrido;
                }               
                
                break;

            case 1://Corregir
                if (contMaxMejora < 3)
                {
                    Player.TiemorVidaHabilidadBerserk += 3;
                   tiempoMaximoEsperaBerserk += Player.TiemorVidaHabilidadBerserk;
                    contMaxMejora++;
                   
                }
                break;

            case 2:
                if (contMaxMejora < 3)
                {
                    Player.CantDeImpactos += 3;
                    //tiempoMaximoEsperaBarrera -= Player.MejoraTiempoUsoBarrido;
                    Player.TiempoDevidaHabilidad += 3;
                    contMaxMejora++;
                    
                }

                break;
                
            default:
                break;
        }
    }
        

}
