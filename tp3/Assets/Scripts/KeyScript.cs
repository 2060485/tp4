using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public Animator doorAnimator;
    int keyCount = 0;

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player")
        {
            //Calcul du nombre de clés trouvées
            keyCount = doorAnimator.GetInteger("keysTaken");
            //Code inspiré de l'api unity https://docs.unity3d.com/ScriptReference/Animator.GetInteger.html
            doorAnimator.SetInteger("keysTaken", keyCount + 1);

            //Destruction de l'objet Clé lors du contact avec le joueur
            Destroy(gameObject);
            Debug.Log("Key collected!");
        }
    }
}
