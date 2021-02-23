using UnityEngine;
using System.Collections;

public class SpawnPedra : MonoBehaviour {
	[SerializeField]
	GameObject pedra;
	GameObject spawn;
	// Use this for initialization
	void Start () {
		spawn=GameObject.FindGameObjectWithTag("spawn");
		InvokeRepeating ("SpawnPedregulho",0f,3f);
		//Instantiate(pedra,new Vector3(transform.position.x,transform.position.y,transform.position.z),Quaternion.identity);
	}	

	// Update is called once per frame
	void Update () {
		/*if(Input.GetKeyDown(KeyCode.S))
		   Instantiate(pedra,new Vector3(transform.position.x,transform.position.y,transform.position.z),Quaternion.identity);*/
	}
	void SpawnPedregulho(){
		Instantiate(pedra,new Vector3(transform.position.x,transform.position.y,transform.position.z),Quaternion.identity);
	}
}
