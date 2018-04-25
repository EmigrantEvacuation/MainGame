using System;
using UnityEngine;

namespace UvaSimulation.Uva.Animation{
	[RequireComponent(typeof(Animator))]
	public class AileronAnimationController : MonoBehaviour {

		private Animator aileronAnimator;

		// Use this for initialization
		void Start () {
			aileronAnimator = GetComponent<Animator> ();
		}
		
		// Update is called once per frame
		void Update () {
			if (Input.GetKey(KeyCode.LeftArrow)) {
				aileronAnimator.SetBool ("AileronUp", true);
			}
			if (Input.GetKeyUp (KeyCode.LeftArrow)) {
				aileronAnimator.SetBool ("AileronUp", false);
			}
		}
	}
}
