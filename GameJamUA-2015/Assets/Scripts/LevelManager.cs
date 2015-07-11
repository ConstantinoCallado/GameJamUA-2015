using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static void LoadLevel()
    {
        int nivelActual = Application.loadedLevel;

        if (nivelActual < 3)
            Application.LoadLevel(nivelActual + 1);
        else
        {
            //Finalizar juego
        }
    }
}
