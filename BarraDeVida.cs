using UnityEngine;
using System.Collections;

public class BarraDeVida : MonoBehaviour {
	[SerializeField]
	float vidaMaxima = 100f;
	//[SerializeField]
	public static float curaVida = 0f;
	[SerializeField]
	GameObject barra;
	public static bool passou;

	// Use this for initialization
	void Start () {
		passou=false;
		curaVida = vidaMaxima;
		InvokeRepeating("diminuirVida",1f,1f);
	}
	
	// Update is called once per frame
	void Update () {
		if(curaVida>100)
			curaVida=100;
		if(passou==true)
			Destroy(barra,1f);
	}
	void diminuirVida(){
		curaVida-=2;
		float calcVida = curaVida/vidaMaxima;
		SetBarraDeVida(calcVida);
	}
	public void SetBarraDeVida(float vidaAtual){
		barra.transform.localScale = new Vector3(vidaAtual,barra.transform.localScale.y,
		                                         barra.transform.localScale.z);
	}
}
