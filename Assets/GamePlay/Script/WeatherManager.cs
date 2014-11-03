using UnityEngine;
using System.Collections;

public class WeatherManager : MonoBehaviour {

	private GameObject rain;
	private GameObject snow;
	private GameObject meteo;
	private GameObject sky;

	ScoreBehivior sb;

	//private GameObject camera;
	//private int counter = 0;
	//private Vector3 weatherPos = new Vector3(0,0,0);
	//float startTime;
	//float timeLag;
	
	// Use this for initialization
	void Start () {
		//camera = GameObject.Find("CameraPoint");
		rain = GameObject.Find("WeatherManager/Rain");
		snow = GameObject.Find("WeatherManager/Snow");
		meteo = GameObject.Find("WeatherManager/Meteo");
		sky = GameObject.Find("WeatherManager/ScrollingSky");

		rain.SetActive(false);
		snow.SetActive(false);
		meteo.SetActive(false);
		sky.SetActive (true);

		sb = GameObject.Find("ScoreManager").GetComponent<ScoreBehivior>();
	}
	
	// Update is called once per frame
	void Update () {
		//weatherPos = camera.transform.position

		if(sb.NowScore > 900) {
			rain.SetActive(false);
			snow.SetActive(false);
			meteo.SetActive(true);
		}
		else if(sb.NowScore > 600) {
			rain.SetActive(true);
			snow.SetActive(false);
			meteo.SetActive(false);
		}
		else if(sb.NowScore > 300) {
			rain.SetActive(false);
			snow.SetActive(true);
			meteo.SetActive(false);
		}


	}
}
