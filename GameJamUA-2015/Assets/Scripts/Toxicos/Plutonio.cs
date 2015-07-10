using UnityEngine;
using System.Collections;

public class Plutonio  : Toxico 
{
	public Color colorPlutonio;
	public Light luzPlutonio;
	public ParticleSystem particulasPlutonio;

	public override void Pegarse(Collider other)
	{
		particulasPlutonio.gameObject.SetActive(true);
		particulasPlutonio.transform.parent = null;
		Salchicha.playerRef.rendererSalchicha.material.color = colorPlutonio;
		luzPlutonio.transform.parent = other.transform;
		luzPlutonio.transform.localPosition = Vector3.zero;

		Destroy(gameObject);
	}}
