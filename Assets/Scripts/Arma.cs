using UnityEngine;
using System.Collections;

public class Arma : MonoBehaviour {
	GameObject player;
	Rigidbody2D rb2d;
	//GameObject teste;

	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		//Debug.Log (player.transform.localScale.x);
		if (player.transform.localScale.x > 0f)
		{
			rb2d.velocity = new Vector2(7f,rb2d.velocity.x);
		}
		if (player.transform.localScale.x < 0f)
		{
			rb2d.velocity = new Vector2(-7f,rb2d.velocity.x);
		}

	}

	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D outro){
		if(outro.gameObject.tag.Equals("reset")){
			Destroy(gameObject);
			teste.i--;
		}
	}
}
