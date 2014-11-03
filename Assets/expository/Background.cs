using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {
	public Texture texture1;
	public Texture texture2;
	public Texture texture3;
	public Texture texture4;
	int i = 0;
	void Update () {

		if(Input.GetKeyDown(KeyCode.RightArrow)) {
			if(i == 0) this.guiTexture.texture = texture2;
			if(i == 1) this.guiTexture.texture = texture3;
			if(i == 2) this.guiTexture.texture = texture4;
			if(i<3) i++;
		}

		if(Input.GetKeyDown(KeyCode.LeftArrow)) {
			if(i == 1) this.guiTexture.texture = texture1;
			if(i == 2) this.guiTexture.texture = texture2;
			if(i == 3) this.guiTexture.texture = texture3;
			if(i>0) i--;
		}

		if(i == 3 && Input.GetKeyDown(KeyCode.Space)) {
			Application.LoadLevel("Title");
		}
	}
}
