using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeDoor : MonoBehaviour
{

    Animator doorAnimator;

    void Start()
    {
        doorAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Player")))
        {
            //Fermeture de la porte
            doorAnimator.SetBool("doorClosed",true);
            Debug.Log("Le joueur est entré dans la zone de trigger!");
        }
    }
}
