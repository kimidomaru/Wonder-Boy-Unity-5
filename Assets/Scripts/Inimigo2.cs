using UnityEngine;
using System.Collections;

public class Inimigo2 : MonoBehaviour {
	GameObject player;
	Rigidbody2D rb2d;
	[SerializeField]
	Animator animPiton;
	[SerializeField]
	AudioSource acertou;
	
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void OnTriggerEnter2D(Collider2D outro){
		if(outro.gameObject.tag.Equals("arma")){
			animPiton.SetBool("morreu",true);
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
