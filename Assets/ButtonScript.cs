using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

	
	public void ClickHouses(){
		Application.LoadLevel ("TDM");
	}
	
	public void ClickPaintBall(){
		Application.LoadLevel ("CTF");
	}
	
	public void ClickControls(){
		Application.LoadLevel ("Controls");
	}
	
	public void ClickBack(){
		Application.LoadLevel ("WelcomeScreen");
	}
	
	public void ClickExit(){
		Application.Quit();
	}
	
	public void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}
	}
}
