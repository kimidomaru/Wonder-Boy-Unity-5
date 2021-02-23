using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Continue : MonoBehaviour {

	public void CliqueContinue(){
		SceneManager.LoadScene("wb");
	}
	public void CliqueDesistir(){
		SceneManager.LoadScene("menu");
	}
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
