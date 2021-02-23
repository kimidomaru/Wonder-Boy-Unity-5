using UnityEngine;
using System.Collections;

public class Fruta : MonoBehaviour {
	GameObject barraHP;

	// Use this for initialization
	void Start () {
		barraHP = GameObject.FindGameObjectWithTag ("Vida");
		Destroy (gameObject, 5f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D outro){
		if(outro.gameObject.tag.Equals ("Player")){
			barraHP.transform.localScale+=new Vector3(0.2f,0,0);
			if(barraHP.transform.localScale.x>1f)
				barraHP.transform.localScale=new Vector3(1f,barraHP.transform.localScale.y,barraHP.transform.localScale.z);
			BarraDeVida.curaVida+=20f;
			Destroy(gameObject,0.2f);
		}
	}
}
