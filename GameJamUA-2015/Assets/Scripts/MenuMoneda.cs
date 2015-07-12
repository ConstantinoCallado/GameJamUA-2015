using UnityEngine;
using System.Collections;

public class MenuMoneda : MonoBehaviour 
{
	public string monedaKey = "C1";

	// Use this for initialization
	void Start () 
	{
		if(!PlayerPrefs.HasKey(monedaKey) || PlayerPrefs.GetInt(monedaKey) == 0)
		{
			Destroy(gameObject);
		}
	}
}
