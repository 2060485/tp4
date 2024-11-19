using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour {

    NavMeshAgent agent;
    Animator anim;
    State currentState;

    public Transform player;
    public float detectionRange = 5f;
    public float damageAmount = 1f;
    public HealthBar health;
    public ClaireController claire;
    private float activationDist = 5f;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        currentState = new Idle(gameObject, agent, anim, player);
    }

    void Update() {
        currentState = currentState.Process(); 

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= activationDist && health != null) {
            health.DecreaseHealth(damageAmount * Time.deltaTime);

            if (claire.jumpParticleEffect.isPlaying) {
                StartCoroutine(DestroyNPCAfterDelay(1f));
            }
        }
    }

    private IEnumerator DestroyNPCAfterDelay(float delay) {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
