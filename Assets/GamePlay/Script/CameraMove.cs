using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	public float MoveSpeed_X=0;
	public float MoveSpeed_Y=0;//Idouryou dsu.
	public bool LoadTrigger=false;

	GameObject SceneMan;
	SceneManager S_SceneMan;

	// Use this for initialization
	void Start () {
		SceneMan=GameObject.Find("SceneManager");
		S_SceneMan=SceneMan.GetComponent<SceneManager>();
	}
	
	// Update is called once per frame
	void Update () {
		SceneMan=GameObject.Find("SceneManager");
		S_SceneMan=SceneMan.GetComponent<SceneManager>();
		LoadTrigger=S_SceneMan.GameOverFlag;
		if(!S_SceneMan.GameOverFlag)
		{
			Vector3 tmp=new Vector3(MoveSpeed_X*Time.deltaTime,MoveSpeed_Y*Time.deltaTime,0);
			this.transform.position+=tmp;
			Debug.Log ("HAHAHA");
		}
	}
}
