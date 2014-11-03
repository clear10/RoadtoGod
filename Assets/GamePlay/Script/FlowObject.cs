using UnityEngine;
using System.Collections;

public class FlowObject : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(0, Mathf.Sin(Time.time) * 0.005f, 0));
	}
}
