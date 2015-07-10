using UnityEngine;
using System.Collections;

public class CameraTracker : MonoBehaviour 
{
	void LateUpdate () 
	{
		transform.position = new Vector3(transform.position.x, transform.position.y, 
		                                 (Salchicha.playerRef.rigidBodyDerecha.transform.position.z + Salchicha.playerRef.rigidBodyIzquierda.transform.position.z) /2);
	}
}
