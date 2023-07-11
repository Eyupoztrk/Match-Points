using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Material red;
    private Vector3 mousePos;
    public Vector3 GetPos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }
    

    private void OnMouseDown()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out RaycastHit hit, 20))
        {
            if(hit.transform.CompareTag("point"))
              hit.transform.GetComponent<Point>().isFull = false;
          
        }
        mousePos = Input.mousePosition - GetPos();
        
    }

    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePos);
        transform.position = new Vector3(transform.position.x, transform.position.y, -0.5f);
        transform.GetComponent<MeshRenderer>().material = red;
        // transform.position = new Vector3(transform.position.x, transform.position.y, 1.495452f);
    }
}
