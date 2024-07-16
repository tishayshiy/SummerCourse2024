using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    public GameObject template;
    public Vector3 offset;
    public int objectCount;
    void Start()
    {
        for (int i = 0; i <= objectCount; i++){
            Vector3 newPosition = transform.position + offset * i;
            Instantiate(template, newPosition, Quaternion.identity);
        }
    }
}
