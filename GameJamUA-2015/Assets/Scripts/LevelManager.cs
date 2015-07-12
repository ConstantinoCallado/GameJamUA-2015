using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour 
{
	public static int[] toxicidades = {17, 16, 10, 100};

    public static void LoadLevel()
    {
        int nivelActual = Application.loadedLevel;

        if (nivelActual < 4)
            Application.LoadLevel(nivelActual + 1);
        else
        {
			Application.LoadLevel("NivelGanar");
        }
    }

	public static int GetToxicidad()
	{
		return toxicidades[Application.loadedLevel-1];
	}
}
