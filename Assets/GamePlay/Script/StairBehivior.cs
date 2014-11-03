using UnityEngine;
using System.Collections;

public class StairBehivior : MonoBehaviour {

	GameObject CameraPoint;
	GameObject StairCreator;
	bool CreateTrigger=false;//Kaidan wo Tukuru Toki no Flag desu.
	float Counter=0;//Object wo Haiki Suru Made no Jikan desu.
	public float FallTime=0;//Kaidan ga Otiru Made no Jikan desu.
	float FallTimeCounter=0;

	// Use this for initialization
	void Start () {
		CameraPoint=GameObject.Find("CameraPoint");
		StairCreator=GameObject.Find("StairCreator");
	}
	
	// Update is called once per frame
	void Update () {
		if(this.transform.position.x<CameraPoint.transform.position.x&&CreateTrigger==false)
		{
			FallTimeCounter+=Time.deltaTime;
			if(FallTime<FallTimeCounter)
			{
				this.GetComponent<Rigidbody>().isKinematic=false;
				rigidbody.AddForce(Vector3.forward);
			}
		}
		if(CreateTrigger)
		{
			Counter+=Time.deltaTime;
			if(Counter>2)
			{
				Destroy(this.gameObject);
			}
		}
	}
}
