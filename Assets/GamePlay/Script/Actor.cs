using UnityEngine;
using System.Collections;


/*
 * 操作キャラスクリプト
 */
public class Actor : MonoBehaviour {

	public float speed;
	public float jumpPower;
	public AudioClip clip;
	public bool isGround;
	public CharacterController Controller;
	Vector3 MovVec=new Vector3(0,0,0);
	GameObject GameOverSp;
	GameObject CamPos;
	GameObject SceneMan;
	SceneManager S_SceneMan;
	Animator Anim;
	RankingBehivior RankScript;
	GameObject ScoreMan;
	ScoreBehivior S_ScoreMan;
	bool SendTrigger=false;

	const float DEFAULT_SPEED = 5f;
	const float DEFAULT_POWER = 5f;
	const float DEFAULT_JUMP = 10f;
	const float DEFAULT_G = 20f;

	AudioSource source;

	// Use this for initialization
	void Start () {
		Anim=this.gameObject.GetComponent<Animator>();
		CamPos=GameObject.Find("CameraPoint");
		GameOverSp=GameObject.Find("Result_gameover");
		SceneMan=GameObject.Find("SceneManager");
		S_SceneMan=SceneMan.GetComponent<SceneManager>();
		GameOverSp.SetActive(false);
		Controller=GetComponent<CharacterController>();
		ScoreMan=GameObject.Find("ScoreManager");
		RankScript=ScoreMan.GetComponent<RankingBehivior>();
		S_ScoreMan=ScoreMan.GetComponent<ScoreBehivior>();
		/*if(GetComponent<Rigidbody>() == null) {
			gameObject.AddComponent<Rigidbody>();
		}*/
		if(GetComponent<AudioSource>() == null) {
			gameObject.AddComponent<AudioSource>();
		}
		if(speed <= 0) speed = DEFAULT_SPEED;
		if(jumpPower <= 0) jumpPower = DEFAULT_POWER;
		//rigidbody2D.velocity = new Vector2(speed, 0);
		if(clip == null) clip = (AudioClip)Resources.Load("Jump 8.wav");
		source = GetComponent<AudioSource>();
		source.clip = clip;
	}

	void OnLevelWasLoaded()
	{
		SendTrigger=false;
	}
	
	// Update is called once per frame
	void Update () {
//		transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
		Vector3 tmp=Vector3.right*speed;
		MovVec.x=tmp.x;
		if(Input.GetKeyDown(KeyCode.Space) && Controller.isGrounded) {
			source.PlayOneShot(clip);
			MovVec.y=DEFAULT_JUMP;
			source.PlayOneShot(clip);
		}
		MovVec.y-=Time.deltaTime*DEFAULT_G;
		MovVec.y=Mathf.Clamp(MovVec.y,-10,Mathf.Infinity);
		if(Vector3.Distance(this.transform.position,CamPos.transform.position)>10f&&SendTrigger==false)
		{
			GameOverSp.SetActive(true);
			S_SceneMan.GameOverFlag=true;
			RankScript.CheckRank(S_ScoreMan.NowScore);
			SendTrigger=true;
		}
		Anim.SetBool("isG",Controller.isGrounded);
		if(S_SceneMan.GameOverFlag)
		{
			Controller.Move(new Vector3(-3,MovVec.y,0)*Time.deltaTime);
		}
		else
		{
			Controller.Move(MovVec*Time.deltaTime);
		}
	}
	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if(hit.gameObject.tag=="Enemy"&&SendTrigger==false)
		{
			GameOverSp.SetActive(true);
			S_SceneMan.GameOverFlag=true;
			RankScript.CheckRank(S_ScoreMan.NowScore);
			Anim.SetBool("isDied",true);
			SendTrigger=true;
		}
	}
}
