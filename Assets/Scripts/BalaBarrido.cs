using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BalaBarrido : Bala
{
    Vector3 areaEfecto = new Vector3(19, 1, 1);

    public override void OnTriggerEnter(Collider other)
    {
        if ( other.tag == "Limite")
        {
            Destroy(gameObject);
        }
        List<Collider> hits = Physics.OverlapBox(transform.position, areaEfecto).ToList();


        for (int i = 0; i < hits.Count; i++)
        {
            float damage = DamaRef * ((hits[i].transform.position - transform.position).magnitude);
            try
            {
                hits[i].gameObject.GetComponent<Enemigo>().RecibirDanno(DamaRef);
            }
            catch (System.Exception error)
            {

            }
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawCube(transform.position, areaEfecto);
    }
}
