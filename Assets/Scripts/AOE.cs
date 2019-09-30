using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AOE : Bala
{
    [SerializeField] float radio = 3;

    public float Radio { get => radio; set => radio = value; }

    public override void OnTriggerEnter(Collider collision)
    {
        
        
        List<Collider> hits = Physics.OverlapSphere(transform.position, radio).ToList();
        

        for (int i = 0; i < hits.Count; i++)
        {
            float damage = DamaRef * ((hits[i].transform.position - transform.position).magnitude / radio);
            try
            {
                hits[i].gameObject.GetComponent<Enemigo>().RecibirDanno(DamaRef);
            }
            catch (System.Exception error)
            {
                
            }
        }
        Destroy(gameObject);
    }
    void Update()
    {
        print("radio : " + radio);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, radio);
    }

}
