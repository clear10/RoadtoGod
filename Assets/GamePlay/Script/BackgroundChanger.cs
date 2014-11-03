using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackgroundChanger : MonoBehaviour {

	public List<Texture> backgrounds;
	public GameObject scoreManager;

	ScoreBehivior sb;
	float score;

	// Use this for initialization
	void Start () {
		if(backgrounds != null) {
		}
		sb = scoreManager.GetComponent<ScoreBehivior>();
		score = sb.NowScore;
		StartCoroutine("ChangeTexture");
	}
	
	// Update is called once per frame
	void Update () {
		//score = sb.NowScore;
	}

	IEnumerator ChangeTexture () {
		int num;
		while(true) {
			num = Random.Range(0, backgrounds.Count);
			if(num > backgrounds.Count) yield return null;
			renderer.material.mainTexture = backgrounds[num];
			yield return new WaitForSeconds(20f);
		}

	}
	void OnDestroy () { StopAllCoroutines(); }
}
