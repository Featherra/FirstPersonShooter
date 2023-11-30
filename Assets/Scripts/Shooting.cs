using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Shooting : MonoBehaviour
{
    public Camera Cam;

    private Ray ray;
    private RaycastHit hit;

    
    void Update()
    {
      if (Input.GetMouseButtonDown(0))
      {
             ray = Cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit) )
            {
                if (hit.collider.tag.Equals("Npc"))
                {
                   Destroy(hit.collider.gameObject);
                } 
           
            }

      }  

    }
}
