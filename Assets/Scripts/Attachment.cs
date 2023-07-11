using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Attachment : MonoBehaviour
{
    public Material green;
    [FormerlySerializedAs("partnerAttachments")] public List<Attachment> neighbourAttachments;

    public GameObject pointObj;


    private void OnMouseUp()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out RaycastHit hit, 20))
        {
            if (!hit.transform.GetComponent<Point>().isFull)
            {
                transform.position = hit.transform.position;
                transform.position =
                    new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.1f);
                hit.transform.GetComponent<Point>().isFull = true;
                CheckAllIsFull();
                transform.GetComponent<MeshRenderer>().material = green;

                pointObj = hit.transform.gameObject;
                pointObj.GetComponent<Point>().mainAttachment = this;
            }
            
        }
    }

    public void CheckAllIsFull()
    {
        var list = GameManager.instance.points;
        foreach (var item in list)
        {
            if (!item.isFull)
            {
                GameManager.instance.canCheck = false;
                return;
            }
                
        }

        GameManager.instance.canCheck = true;

    }
}
