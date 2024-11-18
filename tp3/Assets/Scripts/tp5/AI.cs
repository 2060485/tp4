using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour {

    // Composants NavMeshAgent et Animator pour le mouvement et l'animation
    NavMeshAgent agent;      // Référence à l'agent de navigation
    Animator anim;           // Référence à l'animateur pour les animations du NPC
    State currentState;      // État actuel du NPC

    public Transform player; // Référence au joueur pour interagir avec le NPC
    public float detectionRange = 5f; // Distance à laquelle le NPC commence à attaquer
    public float damageAmount = 1f;   // Quantité de dégâts infligée
    public HealthBar health;

    // Initialisation au démarrage de la scène
    void Start() {
        agent = GetComponent<NavMeshAgent>();    // Initialisation de l'agent de navigation
        anim = GetComponent<Animator>();         // Initialisation de l'animateur
        currentState = new Idle(gameObject, agent, anim, player); // Le NPC commence en état "Idle"
        
        // Assurez-vous que le joueur a un HealthBar et obtenez la référence
    }

    // Mise à jour à chaque frame pour traiter l'état actuel
    void Update() {
        currentState = currentState.Process(); // Mise à jour de l'état actuel du NPC
        
        // Vérifiez la distance entre l'AI et le joueur
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Si le joueur est assez proche et que la barre de vie existe
        if (distanceToPlayer <= detectionRange && health != null) {
            // Réduisez la barre de vie du joueur
            health.DecreaseHealth(damageAmount * Time.deltaTime); // Réduisez progressivement selon le temps
        }
    }
}
