using UnityEngine;
using System.Collections;

public class Centinela : MonoBehaviour 
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Salchicha")
        {
            if (other.GetComponent<Rigidbody>().velocity.sqrMagnitude >= 0.2f)
                {
                    Debug.Log("PILLADA!!!!");
                }
        }
    }
}
