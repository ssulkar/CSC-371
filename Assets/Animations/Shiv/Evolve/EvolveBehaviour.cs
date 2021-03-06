﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvolveBehaviour : StateMachineBehaviour {
	public GameObject particlePrefab;
	public float evolveDuration = 5.0f;
	
	private float duration = 0.0f;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		duration = 0.0f;
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		duration += Time.deltaTime;
		
		if (duration > evolveDuration) {
			animator.SetTrigger("done");
			return;
		}

		animator.SetFloat("speed", Mathf.Max(1.0f, duration));
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		Transform t = animator.gameObject.GetComponent<Transform>();
		Object o = Instantiate(particlePrefab, t.position, t.rotation);
		Destroy(o, 5.0f);
	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
