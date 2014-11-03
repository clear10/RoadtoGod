using UnityEngine;
using System.Collections;

public class StairCreate : MonoBehaviour {

	public float offset_X=0;
	public float offset_Y=0;//Seiseiji no offset desu.
	public GameObject Stair;
	Vector3 nextStairPos=new Vector3(0,0,0);//Kaidan no Tsugi no Iti desu.
	public GameObject Chapy;
	public GameObject Meteorite;
	public GameObject Meteorite2;
	public GameObject Shikigami;
	public GameObject Morimoto;
	public GameObject Shima;
	public GameObject Ishigami;
	float CreateCounter=0;
	float CreateEnemyCounter=0;
	bool[] EnemyCreateFlag=new bool[7];
	float[] EnemyCreateCounter=new float[7];

	// Use this for initialization
	void Start () {
		Instantiate(Stair,nextStairPos,Quaternion.identity);
		for(int i=1;i<30;i++)
		{
			Vector3 tmp=new Vector3(nextStairPos.x+offset_X,nextStairPos.y+offset_Y,0);
			nextStairPos=tmp;
			Instantiate(Stair,nextStairPos,Quaternion.identity);
		}
	}

	public void Create()
	{
		Vector3 tmp=new Vector3(nextStairPos.x+offset_X,nextStairPos.y+offset_Y,0);
		nextStairPos=tmp;
		/*tmp=new Vector3(nextStairPos.x+offset_X,nextStairPos.y+offset_Y,0);
		Vector3 nextStairPos_2=tmp;
		tmp=new Vector3(nextStairPos_2.x+offset_X,nextStairPos_2.y+offset_Y,0);
		Vector3 nextStairPos_3=tmp;*/
		if(Random.Range(1,11)%7!=0)
		{
			Instantiate(Stair,nextStairPos,Quaternion.identity);
			/*Instantiate(Stair,nextStairPos_2,Quaternion.identity);
			Instantiate(Stair,nextStairPos_3,Quaternion.identity);*/
		}
		//nextStairPos=nextStairPos_3;
		if(CreateEnemyCounter>1)
		{
			Create_Enemy();
			CreateEnemyCounter=0;
		}
		EnemyTimer();
	}

	void EnemyTimer()
	{
		if(EnemyCreateFlag[0])
		{
			EnemyCreateCounter[0]+=Time.deltaTime;
			if(EnemyCreateCounter[0]>3)
			{
				EnemyCreateFlag[0]=false;
				EnemyCreateCounter[0]=0;
			}
		}
		if(EnemyCreateFlag[1])
		{
			EnemyCreateCounter[1]+=Time.deltaTime;
			if(EnemyCreateCounter[1]>3)
			{
				EnemyCreateFlag[1]=false;
				EnemyCreateCounter[1]=0;
			}
		}
		if(EnemyCreateFlag[2])
		{
			EnemyCreateCounter[2]+=Time.deltaTime;
			if(EnemyCreateCounter[2]>3)
			{
				EnemyCreateFlag[2]=false;
				EnemyCreateCounter[2]=0;
			}
		}
		if(EnemyCreateFlag[3])
		{
			EnemyCreateCounter[3]+=Time.deltaTime;
			if(EnemyCreateCounter[3]>3)
			{
				EnemyCreateFlag[3]=false;
				EnemyCreateCounter[3]=0;
			}
		}
		if(EnemyCreateFlag[4])
		{
			EnemyCreateCounter[4]+=Time.deltaTime;
			if(EnemyCreateCounter[4]>3)
			{
				EnemyCreateFlag[4]=false;
				EnemyCreateCounter[4]=0;
			}
		}
		if(EnemyCreateFlag[5])
		{
			EnemyCreateCounter[5]+=Time.deltaTime;
			if(EnemyCreateCounter[5]>3)
			{
				EnemyCreateFlag[5]=false;
				EnemyCreateCounter[5]=0;
			}
		}
		if(EnemyCreateFlag[6])
		{
			EnemyCreateCounter[6]+=Time.deltaTime;
			if(EnemyCreateCounter[6]>3)
			{
				EnemyCreateFlag[6]=false;
				EnemyCreateCounter[6]=0;
			}
		}
	}

	public void Create_Enemy()
	{

		int i=Random.Range(0,40);
		if(0<=i&&i<5&&!EnemyCreateFlag[0])
		{
			Instantiate(Chapy,new Vector3(nextStairPos.x,nextStairPos.y+5,nextStairPos.z),Quaternion.Euler(new Vector3(90,180,0)));
			EnemyCreateFlag[0]=true;
		}
		else if(5<=i&&i<10&&!EnemyCreateFlag[1])
		{
			Instantiate(Meteorite,new Vector3(nextStairPos.x,nextStairPos.y+5,nextStairPos.z),Quaternion.identity);
			EnemyCreateFlag[1]=true;
		}
		else if(10<=i&&i<15&&!EnemyCreateFlag[2])
		{
			Instantiate(Meteorite2,new Vector3(nextStairPos.x,nextStairPos.y+10,nextStairPos.z),Quaternion.identity);
			EnemyCreateFlag[2]=true;
		}
		else if(15<=i&&i<20&&!EnemyCreateFlag[3])
		{
			Instantiate(Shikigami,new Vector3(nextStairPos.x,nextStairPos.y+5,nextStairPos.z),Quaternion.Euler(new Vector3(90,0,0)));
			EnemyCreateFlag[3]=true;
		}
		else if(20<=i&&i<25&&!EnemyCreateFlag[4])
		{
			Instantiate(Morimoto,new Vector3(nextStairPos.x,nextStairPos.y+10,nextStairPos.z),Quaternion.Euler(new Vector3(90,0,0)));
			EnemyCreateFlag[4]=true;
		}
		else if(15<=i&&i<20&&!EnemyCreateFlag[5])
		{
			Instantiate(Shima,new Vector3(nextStairPos.x,nextStairPos.y+0.5f,nextStairPos.z),Quaternion.Euler(new Vector3(0,180,0)));
			EnemyCreateFlag[5]=true;
		}
		else if(20<=i&&i<25&&!EnemyCreateFlag[6])
		{
			Instantiate(Ishigami,new Vector3(nextStairPos.x,nextStairPos.y-0.5f,nextStairPos.z),Quaternion.Euler(new Vector3(0,180,0)));
			EnemyCreateFlag[6]=true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		CreateCounter+=Time.deltaTime;
		CreateEnemyCounter+=Time.deltaTime;
		if(CreateCounter>0.1f)
		{
			Create();
			CreateCounter=0;
		}
	}
}
