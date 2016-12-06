using UnityEngine;
using System.Collections;

public class SpawnFruta : MonoBehaviour {
	[SerializeField]
	GameObject fruta;
	[SerializeField]
	GameObject spawn;

	// Use this for initialization
	void Start () {
		//spawn = GameObject.FindGameObjectWithTag ("SpawnFruta");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D outro){
		if(outro.gameObject.tag.Equals("Player")){
			Instantiate(fruta,new Vector3(spawn.transform.position.x,spawn.transform.position.y,spawn.transform.position.z),Quaternion.identity);
			Destroy(gameObject,1f);
		}
	}
}
