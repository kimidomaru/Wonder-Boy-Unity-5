using UnityEngine;
using System.Collections;

public class Pedrao : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position+=new Vector3(-2f*Time.deltaTime,0,0);
	}
	void OnTriggerEnter2D(Collider2D outro){
		if(outro.gameObject.tag.Equals ("limite")){
			Destroy(gameObject);
		}
	}
}
