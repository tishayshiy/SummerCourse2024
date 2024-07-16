using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Entered trigger");
    }
    private void OnTriggerStay(Collider collider)
    {
        Debug.Log("Stayed on trigger");
    }
    private void OnTriggerExit(Collider collider)
    {
        Debug.Log("Exited trigger");
    }
}
