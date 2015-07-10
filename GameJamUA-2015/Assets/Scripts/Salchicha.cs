using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Salchicha : MonoBehaviour 
{
	public Rigidbody rigidBodyDerecha;
	public Rigidbody rigidBodyIzquierda;
    public static Salchicha playerRef;

	const float fuerza = 200;

	const float toxicidadMaxima = 100; 
	public float toxicidadActual = 0;

	public Slider sliderToxicidad;

	public Renderer rendererSalchicha;

    void Awake()
    {
        playerRef = this;
    }

	void Update () 
	{
		sliderToxicidad.value = toxicidadActual / toxicidadMaxima;
		checkUserInput();
	}

	private void checkUserInput()
	{
		if(Input.GetKey(KeyCode.A))
		{
			rigidBodyIzquierda.AddForce(new Vector3(0, 0, -fuerza * Time.deltaTime));
		}
		else if(Input.GetKey(KeyCode.D))
		{
			rigidBodyIzquierda.AddForce(new Vector3(0, 0, fuerza * Time.deltaTime));
		}
		if(Input.GetKey(KeyCode.W))
		{
			rigidBodyIzquierda.AddForce(new Vector3(-fuerza * Time.deltaTime, 0, 0));
		}
		else if(Input.GetKey(KeyCode.S))
		{
			rigidBodyIzquierda.AddForce(new Vector3(fuerza * Time.deltaTime, 0, 0));
		}
		
		
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			rigidBodyDerecha.AddForce(new Vector3(0, 0, -fuerza * Time.deltaTime));
		}
		else if(Input.GetKey(KeyCode.RightArrow))
		{
			rigidBodyDerecha.AddForce(new Vector3(0, 0, fuerza * Time.deltaTime));
		}
		if(Input.GetKey(KeyCode.UpArrow))
		{
			rigidBodyDerecha.AddForce(new Vector3(-fuerza * Time.deltaTime, 0, 0));
		}
		else if(Input.GetKey(KeyCode.DownArrow))
		{
			rigidBodyDerecha.AddForce(new Vector3(fuerza * Time.deltaTime, 0, 0));
		}
	}
}
