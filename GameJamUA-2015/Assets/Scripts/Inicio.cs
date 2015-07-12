using UnityEngine;
using System.Collections;

public class Inicio : MonoBehaviour {

	
	void Awake () {

        if (!(PlayerPrefs.HasKey("C1") && PlayerPrefs.HasKey("C2") && PlayerPrefs.HasKey("C3") && PlayerPrefs.HasKey("C4")))
        {
            PlayerPrefs.SetInt("C1", 0);
            PlayerPrefs.SetInt("C2", 0);
            PlayerPrefs.SetInt("C3", 0);
            PlayerPrefs.SetInt("C4", 0);
        }
	}
	

}
