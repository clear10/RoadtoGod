using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public float power = 6f;
	public float time = 3f;

	// Use this for initialization
	void Start () {
		if(GetComponent<Rigidbody>() == null) gameObject.AddComponent<Rigidbody>();
		rigidbody.useGravity = true;
		rigidbody.isKinematic = false;
		rigidbody.AddForce(new Vector3(-power, power, 0), ForceMode.Impulse);
		StartCoroutine("DestroyAfterStart");
	}

	IEnumerator DestroyAfterStart () {
		yield return new WaitForSeconds(time);
		Destroy(this.gameObject);
	}
}
