using UnityEngine;
using System.Collections;

public class Plutonio  : Toxico 
{
	public Color colorPlutonio;
	public Light luzPlutonio;

	public override void Pegarse(Collider other)
	{
		Salchicha.playerRef.rendererSalchicha.material.color = colorPlutonio;
		luzPlutonio.transform.parent = other.transform;
		luzPlutonio.transform.localPosition = Vector3.zero;

		Destroy(gameObject);
	}}
