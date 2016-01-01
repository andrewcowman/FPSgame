using UnityEngine;
using System.Collections;

public class OnScreenGUI : MonoBehaviour {

	public int enleft=5;

	void OnGUI(){
		enleft = GameObject.FindGameObjectsWithTag("Enemy").Length;
		GUI.BeginGroup (new Rect (10, 10, Screen.width, Screen.height));
		GUI.Label(new Rect(0,0,100,100),"Enemies Left: "+enleft);
		GUI.EndGroup();
	}

	void Update(){
		if (enleft == 0) {
			Application.LoadLevel("Win");	
		}
	}


}
