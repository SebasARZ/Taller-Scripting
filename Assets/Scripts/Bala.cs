using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int damaRef;

   


    private Rigidbody rb;
    private Transform target;



    public float Speed { get => speed; set => speed = value; }
    public int DamaRef
    {
        get
        {
            return damaRef;
        }
        set
        {
            damaRef = value;
        }
    }

    

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        print(damaRef*Player.MejoraHabiBarrido);
        rb.velocity = transform.up * Speed;
    }
    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Enemy"||other.tag=="Limite")
        {
            Destroy(gameObject);
        }
    }
    
   
     

    
}
