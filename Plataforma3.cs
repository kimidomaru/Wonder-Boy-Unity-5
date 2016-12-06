using UnityEngine;
using System.Collections;

public class Plataforma3 : MonoBehaviour {
	GameObject plataforma;
	Rigidbody2D rb2d;
	float i=0;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		plataforma = GameObject.FindGameObjectWithTag ("Plataforma3");
	}
	
	// Update is called once per frame
	void Update () {
		if(i<0.5f)
			rb2d.isKinematic=true;
		else if(i>=0.5f && i<1.5f){
			float speed = 2*Time.deltaTime;
			Vector3 temp = new Vector3(187f,plataforma.transform.position.y,
			                           plataforma.transform.position.z);
			
			plataforma.transform.position = Vector3.MoveTowards(plataforma.transform.position,temp,speed);
		}
		else if(i>=1.5f && i<2.5f){
			float speed = 2*Time.deltaTime;
			Vector3 temp2 = new Vector3(184f,plataforma.transform.position.y,
			                            plataforma.transform.position.z);
			plataforma.transform.position = Vector3.MoveTowards(plataforma.transform.position,temp2,speed);
		}
		else if(i>=2.5f){
			rb2d.isKinematic=false;
		}
	}
	void OnCollisionEnter2D(Collision2D outro){
		if(outro.gameObject.tag.Equals("Player")){
			i=Random.Range(0f,3f);
		}
	}
	void OnTriggerEnter2D(Collider2D outro){
		if(outro.gameObject.tag.Equals("reset")){
			Destroy(gameObject);
		}
	}
}

