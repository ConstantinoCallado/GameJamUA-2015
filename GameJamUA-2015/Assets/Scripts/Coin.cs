using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Salchicha")
        {
            
            switch (Application.loadedLevel)
            {
                case 1: PlayerPrefs.SetInt("C1", 1);
                    break;
                case 2:PlayerPrefs.SetInt("C2", 1);
                    break;
                case 3: PlayerPrefs.SetInt("C3", 1);
                    break;
                case 4: PlayerPrefs.SetInt("C4", 1);
                    break;

            }
			transform.parent = other.transform;
        }
    }
}
