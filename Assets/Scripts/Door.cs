using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Collider collider;
    public Renderer renderer;

    public void Open()
    {
        collider.enabled = false;
        renderer.enabled = false;
    }
    public void Close()
    {
        collider.enabled = true;
        renderer.enabled = true;
    }

}
