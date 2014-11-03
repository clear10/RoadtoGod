using UnityEngine;

public class SceneManager: MonoBehaviour
{	

	public bool GameOverFlag=false;
	GameObject ScoreMan;
	ScoreBehivior S_ScoreMan;

	void Awake()
	{
//		if(GameObject.Find("SceneManager")!=this.gameObject)
//		{
//			Destroy(this.gameObject);
//		}
		DontDestroyOnLoad(this.gameObject);
		ScoreMan=GameObject.Find("ScoreManager");
		S_ScoreMan=ScoreMan.GetComponent<ScoreBehivior>();
	}

	void OnLevelWasLoaded()
	{
		GameOverFlag=false;
	}

	void Update ()
	{
		// scene:Title
		if (Application.loadedLevelName == "Title") {
			//game_over = false;
			//game_clear = false;
			GameOverFlag=false;

			if ( Input.GetKeyDown(KeyCode.Space) ) {
				GameOverFlag=false;
			    Application.LoadLevel("Test");
			}
			if(Input.GetKeyDown(KeyCode.Return)) {
				Application.LoadLevel("expository");
			}
		}

		//scene:Test
		if(Application.loadedLevelName=="Test")
		{
			/*
			if ( Input.GetKeyDown(KeyCode.C) ) {
				Application.LoadLevel("GameClear");
				GameOverFlag=false;
			}
			 */
			if(GameOverFlag)
			{
				if(Input.GetKeyDown(KeyCode.Space))
				{
					GameOverFlag=false;
					S_ScoreMan.LoadTrigger=false;
					Application.LoadLevel("Test");
				}
				else if(Input.GetKeyDown(KeyCode.Return))
				{
					Application.LoadLevel("Title");
				}
				else if(Input.GetKeyDown(KeyCode.R))
				{
					Application.LoadLevel("Ranking");
				}
			}
		}

		// scene:GameClear
		if ( Application.loadedLevelName == "GameClear" ) {
			if ( Input.GetKeyDown(KeyCode.Space) ) {
				Application.LoadLevel("Title");
			}
		}

		if(Application.loadedLevelName == "Ranking")
		{
			if(Input.GetKeyDown(KeyCode.Return))
			{
				Application.LoadLevel("Title");
			}
			else if(Input.GetKeyDown(KeyCode.Space))
			{
				GameOverFlag=false;
				Application.LoadLevel("Test");
			}
		}

	}
}