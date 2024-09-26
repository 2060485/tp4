using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainFood : MonoBehaviour
{
    [SerializeField] private FoodBar _FoodBar;

    private void OnTriggerEnter(Collider other)
    {
        // Vérifiez si l'objet qui est entré dans le trigger a le tag "Player"
        if ((other.CompareTag("Player")))
        {
            Destroy(gameObject);
            _FoodBar.AddEnergy();
        }
    }
}
