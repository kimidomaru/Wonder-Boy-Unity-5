using UnityEngine;
using System.Collections;

public class Inimigo : MonoBehaviour {
	GameObject player;
	Rigidbody2D rb2d;
	[SerializeField]
	Animator animCaracol;
	[SerializeField]
	AudioSource acertou;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		player = GameObject.FindGameObjectWithTag ("Player");
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position+=new Vector3(-0.01f*Time.deltaTime,0,0);
	
	}
	void OnTriggerEnter2D(Collider2D outro){
		if(outro.gameObject.tag.Equals("arma")){
			animCaracol.SetBool("casco",true);
			acertou.Play();
			if (player.transform.localScale.x > 0f)
			{
				rb2d.velocity = new Vector2(2f,5f);
			}
			if (player.transform.localScale.x < 0f)
			{
				rb2d.velocity = new Vector2(-2f,5f);
			}
			Destroy(gameObject,1f);
		}
	}
}
