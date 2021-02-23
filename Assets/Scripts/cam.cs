using UnityEngine;
using System.Collections;

public class cam : MonoBehaviour {
	Transform personagem;
	[SerializeField]
	Camera CameraP;
	[SerializeField]
	Camera CameraSubida;
	// Use this for initialization
	void Start () {
		personagem = GameObject.FindGameObjectWithTag ("Player").transform;
		CameraSubida.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(personagem.transform.position.x>102f){
			CameraP.enabled = false;
			CameraSubida.enabled = true;
		}
		else{
			CameraP.enabled = true;
			CameraSubida.enabled = false;
		}
		if(CameraSubida.enabled==false)
			transform.position = new Vector3 (personagem.position.x, 0, -10);
		else
			transform.position = new Vector3 (personagem.position.x, 3, -10);
	}
}
