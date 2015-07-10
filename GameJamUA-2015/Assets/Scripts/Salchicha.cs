using UnityEngine;
using System.Collections;

public class Salchicha : MonoBehaviour 
{
	public Rigidbody rigidBodyDerecha;
	public Rigidbody rigidBodyIzquierda;
    public static Salchicha playerRef;

	public float fuerza = 5;

    void Awake()
    {
        playerRef = this;
    }

	void Update () 
	{
		if(Input.GetKey(KeyCode.A))
		{
			rigidBodyIzquierda.AddForce(new Vector3(0, 0, -fuerza));
		}
		else if(Input.GetKey(KeyCode.D))
		{
			rigidBodyIzquierda.AddForce(new Vector3(0, 0, fuerza));
		}
		if(Input.GetKey(KeyCode.W))
		{
			rigidBodyIzquierda.AddForce(new Vector3(fuerza, 0, 0));
		}
		else if(Input.GetKey(KeyCode.S))
		{
			rigidBodyIzquierda.AddForce(new Vector3(-fuerza, 0, 0));
		}


		if(Input.GetKey(KeyCode.LeftArrow))
		{
			rigidBodyDerecha.AddForce(new Vector3(0, 0, -fuerza));
		}
		else if(Input.GetKey(KeyCode.RightArrow))
		{
			rigidBodyDerecha.AddForce(new Vector3(0, 0, fuerza));
		}
		if(Input.GetKey(KeyCode.UpArrow))
		{
			rigidBodyDerecha.AddForce(new Vector3(fuerza, 0, 0));
		}
		else if(Input.GetKey(KeyCode.DownArrow))
		{
			rigidBodyDerecha.AddForce(new Vector3(-fuerza, 0, 0));
		}
	}
}
