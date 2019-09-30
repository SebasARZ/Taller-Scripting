using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotacionTorreta : MonoBehaviour
{
    private Rigidbody rb;
    private int floorMask;
    private float camRayLenght = 100f;
    
    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rotacionCañon();
    }

    void rotacionCañon()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;        
            if (Physics.Raycast(camRay, out floorHit, camRayLenght, floorMask))
            {
                Vector3 playerToMouse = floorHit.point - transform.position;
                playerToMouse.z = 0f;                      
                Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
                rb.MoveRotation(newRotation);
            }                    
    }


}
