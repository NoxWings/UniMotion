 /**
 * UniMotion 
 * Copyright (c) 2014, 
 * David 'NoxWings' Garcia Miguel, 
 * All rights reserved.
 * 
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 3.0 of the License, or (at your option) any later version.
 * 
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 * 
 * You should have received a copy of the GNU Lesser General Public
 * License along with this library.
 **/

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

