using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class SingleIKCtrl : MonoBehaviour {

	protected Animator animator;
	public bool activateIK = false;
	public AvatarIKGoal avatarIK = AvatarIKGoal.RightHand;
	public Transform goalTarget = null;

	void Awake() {
		animator = this.GetComponent<Animator>();
	}

	void OnAnimatorIK() {
		if (animator != null) {
			if (activateIK && goalTarget != null) {
				setIKWeight(1.0f);
				setIKTransform(goalTarget);
			} else {
				setIKWeight(0f);
			}
		}
	}

	void setIKWeight(float weight) {
		animator.SetIKPositionWeight(avatarIK, weight);
		animator.SetIKRotationWeight(avatarIK, weight);
	}

	void setIKTransform(Transform goal) {
		animator.SetIKPosition(avatarIK, goal.position);
		animator.SetIKRotation(avatarIK, goal.rotation);
	}
}

