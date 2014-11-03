using UnityEngine;
using System.Collections;
using System;

public class RankingBehivior : MonoBehaviour {
	public float[] Ranker=new float[6];
	GameObject[] Scores=new GameObject[5];
	TextMesh[] Scores_Text=new TextMesh[5];
	bool LoadTrigger=false;
	// Use this for initialization
	void Awake () {
		if(PlayerPrefs.HasKey("First")==false)
		{
			PlayerPrefs.SetFloat("First",100);
			PlayerPrefs.SetFloat("Second",90);
			PlayerPrefs.SetFloat("Third",80);
			PlayerPrefs.SetFloat("Fourth",70);
			PlayerPrefs.SetFloat("Fifth",60);
		}
	}
	void Start()
	{
		Ranker[5]=PlayerPrefs.GetFloat("First");
		Ranker[4]=PlayerPrefs.GetFloat("Second");
		Ranker[3]=PlayerPrefs.GetFloat("Third");
		Ranker[2]=PlayerPrefs.GetFloat("Fourth");
		Ranker[1]=PlayerPrefs.GetFloat("Fifth");
		Ranker[0]=0;
	}


	
	// Update is called once per frame
	void Update () {
		if(Application.loadedLevelName=="Ranking")
		{
			if(!LoadTrigger)
			{
				Scores[0]=GameObject.Find("Text/Score/First");
				Scores[1]=GameObject.Find("Text/Score/Second");
				Scores[2]=GameObject.Find("Text/Score/Third");
				Scores[3]=GameObject.Find("Text/Score/Fourth");
				Scores[4]=GameObject.Find("Text/Score/Fifth");
				Scores_Text[0]=Scores[0].GetComponent<TextMesh>();
				Scores_Text[1]=Scores[1].GetComponent<TextMesh>();
				Scores_Text[2]=Scores[2].GetComponent<TextMesh>();
				Scores_Text[3]=Scores[3].GetComponent<TextMesh>();
				Scores_Text[4]=Scores[4].GetComponent<TextMesh>();
				Ranker[5]=PlayerPrefs.GetFloat("First");
				Ranker[4]=PlayerPrefs.GetFloat("Second");
				Ranker[3]=PlayerPrefs.GetFloat("Third");
				Ranker[2]=PlayerPrefs.GetFloat("Fourth");
				Ranker[1]=PlayerPrefs.GetFloat("Fifth");
				Ranker[0]=0;
				LoadTrigger=true;
			}
			else
			{
				for(int i=0;i<Scores_Text.Length;i++)
				{
					Scores_Text[i].text=Ranker[5-i].ToString();
				}
			}
		}
		else
		{
			LoadTrigger=false;
		}
	}

	public void CheckRank(float Score)
	{
		Ranker[0]=Score;
		Array.Sort(Ranker);
		PlayerPrefs.SetFloat ("First",Ranker[5]);
		PlayerPrefs.SetFloat ("Second",Ranker[4]);
		PlayerPrefs.SetFloat ("Third",Ranker[3]);
		PlayerPrefs.SetFloat ("Fourth",Ranker[2]);
		PlayerPrefs.SetFloat ("Fifth",Ranker[1]);
		PlayerPrefs.Save();
	}
}
