using UnityEngine;
using System.Collections;

public class Ovo : MonoBehaviour {
	GameObject player;
	Rigidbody2D rb2d;
	[SerializeField]
	GameObject skate,mart;
	[SerializeField]
	Animator animOvo;
	[SerializeField]
	AudioSource meuOvo;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D outro){
		if(outro.gameObject.tag.Equals("Player") && teste.martelo==true){
			animOvo.SetBool("quebra",true);
			meuOvo.Play();
			if (player.transform.localScale.x > 0f)
			{
				rb2d.velocity = new Vector2(2f,5f);
			}
			if (player.transform.localScale.x < 0f)
			{
				rb2d.velocity = new Vector2(-2f,5f);
			}
			Destroy(gameObject,2f);
			Invoke("SpawnSkate",1.95f);
		}
		else if(outro.gameObject.tag.Equals("Player") && teste.martelo==false){
			animOvo.SetBool("quebra",true);
			meuOvo.Play();
			if (player.transform.localScale.x > 0f)
			{
				rb2d.velocity = new Vector2(2f,5f);
			}
			if (player.transform.localScale.x < 0f)
			{
				rb2d.velocity = new Vector2(-2f,5f);
			}
			Destroy(gameObject,2f);
			Invoke("SpawnMartelo",1.95f);
		}
	}
	void SpawnSkate(){
		Instantiate(skate, new Vector3(transform.localPosition.x,transform.localPosition.y,
		                               transform.localPosition.z),Quaternion.identity);
	}
	void SpawnMartelo(){
		Instantiate(mart, new Vector3(transform.localPosition.x,transform.localPosition.y+0.4f,
			transform.localPosition.z),Quaternion.identity);
	}
}
