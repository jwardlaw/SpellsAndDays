using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour {

    Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponentInChildren<Animator>();
        animator.SetBool("Moving", true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
