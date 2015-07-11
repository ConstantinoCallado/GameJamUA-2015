using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class Salchicha : MonoBehaviour 
{
	public Rigidbody rigidBodyDerecha;
	public Rigidbody rigidBodyIzquierda;
    public static Salchicha playerRef;
    public ArrayList listaSucia;
	const float fuerza = 300;

	const float toxicidadMaxima = 100; 
	public float toxicidadActual = 0;

	public Slider sliderToxicidad;

	public Renderer rendererSalchicha;

	public Texture spriteWASD;
	public Texture spriteFlechas;

	public Transform centroTextoL;
	public Transform centroTextoR;

    void Awake()
    {
        playerRef = this;
        listaSucia = new ArrayList();
    }

	void Update () 
	{
		sliderToxicidad.value = toxicidadActual / toxicidadMaxima;
		checkUserInput();

		if(rigidBodyDerecha.transform.position.y < -10)
		{
			Bandeja.bandejaRef.Respawn();
			DestroyImmediate(gameObject);
		}
	}

	private void checkUserInput()
	{
		if(Input.GetKey(KeyCode.A))
		{
			rigidBodyIzquierda.AddForce(new Vector3(0, 0, fuerza * Time.deltaTime));
		}
		else if(Input.GetKey(KeyCode.D))
		{
			rigidBodyIzquierda.AddForce(new Vector3(0, 0, -fuerza * Time.deltaTime));
		}
		if(Input.GetKey(KeyCode.W))
		{
			rigidBodyIzquierda.AddForce(new Vector3(fuerza * Time.deltaTime, 0, 0));
		}
		else if(Input.GetKey(KeyCode.S))
		{
			rigidBodyIzquierda.AddForce(new Vector3(-fuerza * Time.deltaTime, 0, 0));
		}
		
		
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			rigidBodyDerecha.AddForce(new Vector3(0, 0, fuerza * Time.deltaTime));
		}
		else if(Input.GetKey(KeyCode.RightArrow))
		{
			rigidBodyDerecha.AddForce(new Vector3(0, 0, -fuerza * Time.deltaTime));
		}
		if(Input.GetKey(KeyCode.UpArrow))
		{
			rigidBodyDerecha.AddForce(new Vector3(fuerza * Time.deltaTime, 0, 0));
		}
		else if(Input.GetKey(KeyCode.DownArrow))
		{
			rigidBodyDerecha.AddForce(new Vector3(-fuerza * Time.deltaTime, 0, 0));
		}
	}

    public void RemoveRandomShit()
    {
        if(listaSucia.Capacity>0)
            listaSucia.RemoveAt(Random.Range(0, listaSucia.Capacity));
    }

	public void OnGUI()
	{
		float scale = Screen.width / 1500;
		Vector2 position = Camera.main.WorldToScreenPoint(centroTextoL.position);
		GUI.DrawTexture(new Rect(position.x - (scale * spriteWASD.width / 2) , Screen.height - (position.y + (scale * spriteWASD.height /2)), scale * spriteWASD.width, scale * spriteWASD.height), spriteWASD);
	
		position = Camera.main.WorldToScreenPoint(centroTextoR.position);
		GUI.DrawTexture(new Rect(position.x - (scale * spriteFlechas.width / 2), Screen.height - (position.y + (scale * spriteFlechas.height / 2)), scale * spriteFlechas.width, scale * spriteFlechas.height), spriteFlechas);
	}
}
