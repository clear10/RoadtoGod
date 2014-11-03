using UnityEngine;
using System.Collections;

public class Fuwafuwa : Disturber {

	public float angle = 0f;

	Vector3 vec;

	public override void RushSetParam () {
		base.RushSetParam();
		//isHoming = false;
	}

	public override void RushFor () {
		//
		vec = (targetPoint - transform.position).normalized;
		targetPoint = Quaternion.AngleAxis(angle, Vector3.forward) * vec + transform.position;
		base.RushFor();
	}

	public override void ReachTargetPoint () {
		base.ReachTargetPoint();
	}

}