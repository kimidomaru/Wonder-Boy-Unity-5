using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class teste : MonoBehaviour {
	[SerializeField]
	Animator anim;
	[SerializeField]
	Rigidbody2D jogadorRigidbody;
	[SerializeField]
	int forçaPulo;
	[SerializeField]
	bool noChao;
	[SerializeField]
	LayerMask oQueEChao;
	[SerializeField]
	Transform ChecarChao;
	[SerializeField]
	float velocidade =1f;
	[SerializeField]
	GameObject mart,barraHP;
	bool vivo,skateOn;
	//int i=0;
	[SerializeField]
	AudioSource fogobicho,role,musica,pulo,taca,morreu,pedra,sumiu,clear,moeda;
	[SerializeField]
	Text Pontos,record;
	float pontos,recorde;
	public static int i=0;
	public static bool martelo=false;

	void Start () {
		musica.Play ();
		vivo=true;
		skateOn=false;
		pontos=0;
	}

	void Update () {
		Pontos.text = "Pontos: "+pontos.ToString();
		record.text = "Recorde: " + PlayerPrefs.GetFloat("hs").ToString();

		if (Input.GetKey (KeyCode.RightArrow)&& vivo) {
			transform.position+=new Vector3(0.1f*velocidade,0,0);
			anim.SetBool ("Direita", true);
			transform.localScale = new Vector2(0.48f, transform.localScale.y);
		} 
		else if(Input.GetKeyUp (KeyCode.RightArrow)) {
			anim.SetBool ("Direita", false);
		}
		if (Input.GetKey (KeyCode.LeftArrow) && vivo) {
			transform.localScale = new Vector2(-0.48f, transform.localScale.y);
			anim.SetBool ("Direita", true);
			transform.position+=new Vector3(-0.1f*velocidade,0,0);
		} else if(Input.GetKeyUp (KeyCode.LeftArrow)) {
			anim.SetBool ("Direita", false);
		}
		if(Input.GetKeyDown (KeyCode.S)&& noChao && Input.GetKeyDown(KeyCode.D)&& vivo==true){
			pulo.Play();
			jogadorRigidbody.AddForce(new Vector2(0,forçaPulo));
		}
		else if(Input.GetKeyDown (KeyCode.S)&& noChao && vivo==true){
			pulo.Play();
			jogadorRigidbody.AddForce(new Vector2(0,forçaPulo-100));
		}
		if(Input.GetKeyDown (KeyCode.A)&& i<2 && martelo==true){
			Instantiate(mart, new Vector3(transform.localPosition.x,transform.localPosition.y,transform.localPosition.z),Quaternion.identity);
			anim.SetBool("Atacar",true);
			i++;
		}
		else if(Input.GetKeyUp (KeyCode.A)&& martelo==true) {
			anim.SetBool ("Atacar", false);
			taca.Play();
		}
		if(barraHP.transform.localScale.x==0){
			musica.Stop();
			morreu.Play();
			anim.SetBool("morreu",true);
			if (pontos > PlayerPrefs.GetFloat ("hs")) {
				PlayerPrefs.SetFloat ("hs", pontos);
			}
			vivo=false;
			Invoke ("TrocaCena",2.3f);
		}
		if(skateOn==false){
			velocidade=1f;
		}
		
		noChao=Physics2D.OverlapCircle(ChecarChao.position,0.2f,oQueEChao);
		
		anim.SetBool ("pulo", !noChao);
	}
	void OnTriggerEnter2D(Collider2D outro){
		if(outro.gameObject.tag.Equals("skate")){
			skateOn=true;
			role.Play();
			anim.SetBool("skate",true);
			Destroy(outro.gameObject,0.1f);
			velocidade=1.3f;
		}
		if(outro.gameObject.tag.Equals("foguin") && skateOn==false){
			//Debug.Log ("Perdeu preiboy");

			//Mecanica da fruta recuperar hp
			/*barraHP.transform.localScale+=new Vector3(0.2f,0,0);
			if(barraHP.transform.localScale.x>1f)
				barraHP.transform.localScale=new Vector3(1f,barraHP.transform.localScale.y,barraHP.transform.localScale.z);
			BarraDeVida.curaVida+=20f;*/
			anim.SetBool("queimado",true);
			musica.Stop();
			morreu.Play();
			vivo=false;
			if (pontos > PlayerPrefs.GetFloat ("hs")) {
				PlayerPrefs.SetFloat ("hs", pontos);
			}
			Invoke ("TrocaCena",1.7f);
			fogobicho.Play();
		}
		else if(outro.gameObject.tag.Equals("foguin") && skateOn==true){
			anim.SetBool("skate",false);
			skateOn=false;
			sumiu.Play();
			Destroy(outro.gameObject,0.2f);
		}
		if(outro.gameObject.tag.Equals("reset")){
			if (pontos > PlayerPrefs.GetFloat ("hs")) {
				PlayerPrefs.SetFloat ("hs", pontos);
			}
			SceneManager.LoadScene("gameOver");
		}
		if(outro.gameObject.tag.Equals("pedra") && skateOn==false){
			pedra.Play ();
			anim.SetBool("tropeca",true);
			//jogadorRigidbody.AddForce(new Vector2(0,forçaPulo/3+50));
			if(noChao==true){
				jogadorRigidbody.AddForceAtPosition(new Vector2(0,forçaPulo/3+50),new Vector2(jogadorRigidbody.transform.position.x,-1.21f));
			}
			BarraDeVida.curaVida-=20f;
			if(barraHP.transform.localScale.x<0f)
				barraHP.transform.localScale=new Vector3(0f,barraHP.transform.localScale.y,barraHP.transform.localScale.z);
			Invoke ("TrocaAnimTropeca",0.4f);
		}
		else if(outro.gameObject.tag.Equals("pedra") && skateOn==true){
			anim.SetBool("skate",false);
			skateOn=false;
			sumiu.Play();
			Destroy(outro.gameObject,0.2f);
		}
		if(outro.gameObject.tag.Equals("goal")){
			Debug.Log ("Passou!");
			vivo=false;
			if (pontos > PlayerPrefs.GetFloat ("hs")) {
				PlayerPrefs.SetFloat ("hs", pontos);
			}
			musica.Stop();
			clear.Play();
			Invoke("TrocaCenaFinal",10f);
			//Destruir a barra de vida, lembre-se de calcular os pontos antes...
			pontos+=10000*barraHP.transform.localScale.x;
			moeda.Play();
			BarraDeVida.passou=true;
		}
		if(outro.gameObject.tag.Equals("fruta")){
			moeda.Play();
			pontos+=500;
		}
		if(outro.gameObject.tag.Equals("ovo")){
			taca.Play();
		}
	}
	void OnCollisionEnter2D(Collision2D outro){
		if(outro.gameObject.tag.Equals("inimigo") && skateOn==false){
			anim.SetBool("morreu",true);
			musica.Stop();
			morreu.Play();
			if (pontos > PlayerPrefs.GetFloat ("hs")) {
				PlayerPrefs.SetFloat ("hs", pontos);
			}
			vivo=false;
			Invoke ("TrocaCena",1.7f);
			//Time.timeScale=0;
			//Destroy (gameObject);
		}
		else if(outro.gameObject.tag.Equals("inimigo") && skateOn==true){
			anim.SetBool("skate",false);
			skateOn=false;
			sumiu.Play();
			Destroy(outro.gameObject,0.2f);
		}
		if(outro.gameObject.tag.Equals("pedregulho") && skateOn==false){
			anim.SetBool("morreu",true);
			musica.Stop();
			morreu.Play();
			if (pontos > PlayerPrefs.GetFloat ("hs")) {
				PlayerPrefs.SetFloat ("hs", pontos);
			}
			vivo=false;
			Invoke ("TrocaCena",1.7f);
		}
		else if(outro.gameObject.tag.Equals("pedregulho") && skateOn==true){
			anim.SetBool("skate",false);
			skateOn=false;
			sumiu.Play();
			Destroy(outro.gameObject,0.2f);
		}
	}
	void TrocaCena(){
		SceneManager.LoadScene("gameOver");
	}
	void TrocaCenaFinal(){
		SceneManager.LoadScene("menu");
	}
	void TrocaAnimTropeca(){
		anim.SetBool("tropeca",false);
	}
}
