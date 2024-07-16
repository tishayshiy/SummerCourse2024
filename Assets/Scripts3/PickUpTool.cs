using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickUpTool : MonoBehaviour
{
    public GameObject camera;
    public float distance = 15f;
    private GameObject currentTool;
    bool canPickUp;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            PickUp();
        }

        if(Input.GetKeyDown(KeyCode.Q)){
            Drop();
        }
    }

    void PickUp()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, distance)){
            if(hit.transform.tag == "Tool"){
                if (canPickUp){
                    Drop();
                } 
                currentTool = hit.transform.gameObject;
                currentTool.GetComponent<Rigidbody>().isKinematic = true;
                currentTool.transform.parent = transform;
                currentTool.transform.localPosition = Vector3.zero;
                currentTool.transform.localEulerAngles = new Vector3(-10f, 0f, 60f);
                canPickUp = true;
            }
        }
    }

    void Drop()
    {
        currentTool.transform.parent = null;
        currentTool.GetComponent<Rigidbody>().isKinematic = false;
        canPickUp = false;
        currentTool = null;
    }
}
