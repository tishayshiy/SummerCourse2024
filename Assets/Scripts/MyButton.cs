using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MyButton : MonoBehaviour
{
    public Door door;

    private void OnCollisionEnter(Collision other)
    {
        door.Open();
    }
    private void OnCollisionExit(Collision other)
    {
        door.Close();
    }
}
