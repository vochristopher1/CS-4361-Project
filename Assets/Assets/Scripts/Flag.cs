using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flag : MonoBehaviour
{
    // when Flag's trigger is entered by an object with tag "Player", move to next scene
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // move to next scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
