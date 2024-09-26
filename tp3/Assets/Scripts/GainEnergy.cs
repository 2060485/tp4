using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainEnergy : MonoBehaviour
{

    [SerializeField] private EnergyBar _EnergyBar;

    private void OnTriggerEnter(Collider other)
    {
        // Vérifiez si l'objet qui est entré dans le trigger a le tag "Player"
        if ((other.CompareTag("Player")))
        {
            Destroy(gameObject);
            _EnergyBar.AddEnergy();
        }
    }
}
