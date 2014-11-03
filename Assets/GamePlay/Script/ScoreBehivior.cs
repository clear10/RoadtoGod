using UnityEngine;
using System.Collections;

public class ScoreBehivior : MonoBehaviour {
	GameObject Writer;
	TextMesh WriterText;
	GameObject CamPos;
	public float NowScore;
	public bool LoadTrigger=false;
	// Use this for initialization
	void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
	}
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(Application.loadedLevelName=="Test")
		{
			if(!LoadTrigger)
			{
				CamPos=GameObject.Find("CameraPoint");
				Writer=GameObject.Find("UI/Score/Writer");
				WriterText=Writer.GetComponent<TextMesh>();
				LoadTrigger=true;
			}
			NowScore=CamPos.transform.position.y;
			NowScore*=10;
			NowScore=Mathf.Floor(NowScore);
			WriterText.text=NowScore.ToString();
		}
		else
		{
			LoadTrigger=false;
		}
	}
}
