using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour 
{
	public static SoundManager soundManagerRef;

	public AudioSource audioElect;
	public AudioSource audioCortar;
	public AudioSource audioLimpiar;
	public AudioSource audioAplastar;
	public AudioSource audioRodar;
	public AudioSource audioCoger;

	public void Awake()
	{
		soundManagerRef = this;
	}

}
