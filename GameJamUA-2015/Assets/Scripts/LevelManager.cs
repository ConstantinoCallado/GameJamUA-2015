using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour 
{
	public int[] toxicidades = {10, 10, 10, 10};

    public static void LoadLevel()
    {
        int nivelActual = Application.loadedLevel;

        if (nivelActual < 4)
            Application.LoadLevel(nivelActual + 1);
        else
        {
            //Finalizar juego
        }
    }
}
