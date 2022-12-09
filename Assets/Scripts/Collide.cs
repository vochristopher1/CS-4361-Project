using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collide : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Block"))
        {
            var enemy = other.gameObject.GetComponent<Enemy>();
            enemy.Kill();
        }
    }
}
