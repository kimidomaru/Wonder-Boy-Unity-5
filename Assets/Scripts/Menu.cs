using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
	GameObject camera;

	// Use this for initialization
	void Start () {
		camera=GameObject.FindGameObjectWithTag("MainCamera");
	
	}
	
	// Update is called once per frame
	void Update () {
		InvokeRepeating("DesceMenu",4f,0.5f);
		if(Input.GetKeyDown(KeyCode.Return)){
			SceneManager.LoadScene("wb");
		}
			
	}
	void DesceMenu(){
		if(camera.transform.position.y>-6.2f)
			camera.transform.position+=new Vector3(0,-1*Time.deltaTime,0);
	}
}
