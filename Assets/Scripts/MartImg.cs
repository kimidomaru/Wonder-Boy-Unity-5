using UnityEngine;
using System.Collections;

public class MartImg : MonoBehaviour {

	void Start () {
	}

	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D outro){
		if(outro.gameObject.tag.Equals("Player")){
			teste.martelo=true;
			Destroy(gameObject,0.1f);
		}
	}
}
