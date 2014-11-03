using UnityEngine;
using System.Collections;

public class SceneManager_Play : MonoBehaviour {
	private bool game_clear;
	private bool game_over;
	private GameObject result;

	void Start ()
	{
		// Titleゲームオブジェクトを検索し取得する
		result = GameObject.Find ("Result_gameover");
	}
	
	// Update is called once per frame
	void Update () {
		result.SetActive (false);

		if (Input.GetKeyDown (KeyCode.O)) game_over = true;
		if (Input.GetKeyDown (KeyCode.C)) game_clear = true;
		
		if ( game_over ){
			result.SetActive (true);
			
			if ( Input.GetKeyDown(KeyCode.P) ) {
				Application.LoadLevel("Title");
			}
			if ( Input.GetKeyDown(KeyCode.Space) ) {
				Application.LoadLevel("Title");
			}
		}

		if ( game_over == false && game_clear ){
			Application.LoadLevel("GameClear");
		}
	
	}
}
