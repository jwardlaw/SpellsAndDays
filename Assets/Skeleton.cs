using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour {

    public Transform Player;
    Animator animator;
    NavMeshAgent agent;
    

	// Use this for initialization
	void Start () {
        animator = GetComponentInChildren<Animator>();
        animator.SetBool("Moving", true);
        Player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(Player.position);
	}

    IEnumerator Die()
    {
        Debug.Log("Dying");
        animator.SetTrigger("Death");
        animator.SetBool("Moving", false);
        agent.enabled = false;
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Explosion"))
        {
            StartCoroutine(Die());
        }
    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
