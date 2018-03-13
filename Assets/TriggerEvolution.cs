using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvolution : MonoBehaviour {
	public float evolveDuration = 3.0f;
	private Animator animator;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag("Player")) {
			animator = other.gameObject.GetComponent<Animator>();

			StartCoroutine(EvolveCoroutine());
		}
	}

	IEnumerator EvolveCoroutine() {
		animator.SetTrigger("evolveTrigger");
		animator.SetBool("isEvolving", true);

		yield return new WaitForSeconds(evolveDuration);

		animator.SetBool("isEvolving", false);
	}
}