using UnityEngine;
using System.Collections;

public class Disturber : MonoBehaviour {

	// プレイヤーにはプレイヤータグをつけておいてください
	public GameObject playerObj;
	// 突っ込むスピード
	public float speed;
	// 追尾性の有無
	public bool isHoming;

	protected bool isDisturb;
	protected Vector3 targetPoint;

	/*
	 * 継承するクラスごとに実装
	 * デフォではただ直進するだけ
	 */
	public virtual void RushFor () {
		if(isHoming) targetPoint = playerObj.transform.position;
		transform.Translate((targetPoint - transform.position).normalized * speed * Time.deltaTime);
	}

	public virtual void RushSetParam () {
		targetPoint = playerObj.transform.position;
		isDisturb = true;
	}

	public virtual void ReachTargetPoint () {
	}

	// Use this for initialization
	void Start () {
		playerObj = GameObject.FindWithTag("Player");
		targetPoint = Vector3.zero;
		if(GetComponent<Rigidbody>() == null) gameObject.AddComponent<Rigidbody>();
		rigidbody.useGravity = false;
		RushSetParam();
	}

	// Update is called once per frame
	void Update () {
		if(isDisturb) {
			RushFor();
		}
		if((targetPoint - transform.position).magnitude < 0.5f) {
			ReachTargetPoint();
		}
	}

	void OnCollisionEnter (Collision col) {
		Destroy(col.gameObject);
		isDisturb = false;
	}
}
