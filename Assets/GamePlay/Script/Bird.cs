using UnityEngine;
using System.Collections;

public class Bird : Disturber {

	public float angle = 0f;

	int count = 0;
	Vector3 nextTargetPoint;
	Vector3 lastTargetPoint;

	public override void RushSetParam () {
		base.RushSetParam();
		lastTargetPoint = targetPoint;
		Vector3 tmp = targetPoint - transform.position;
		nextTargetPoint = Quaternion.AngleAxis(-angle, Vector3.forward) * tmp /2f +transform.position;
		targetPoint = nextTargetPoint;
		count = 0;
		isHoming = false;
	}

	public override void RushFor () {
		//
		base.RushFor();
	}

	public override void ReachTargetPoint () {
		base.ReachTargetPoint();
		if(count == 0) targetPoint = lastTargetPoint;
		count = 1 - count;
	}

}