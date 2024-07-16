using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{

    void OnCollisionEnter(Collision other)
    {
        PlayerStats pStats;
        if (other.collider.TryGetComponent<PlayerStats>(out pStats)){
            Debug.Log("Other object has playerStats");
            pStats.coinCount += 1;
            Debug.Log(pStats.coinCount + " " + pStats.gameObject.name);
            Destroy(gameObject);
        } else{
            Debug.Log("No playerStats");
        }
    }

}
