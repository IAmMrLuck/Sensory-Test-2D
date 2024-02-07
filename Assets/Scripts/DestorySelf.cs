using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestorySelf : MonoBehaviour
{
    void Start()
    {
        Invoke("KillYourself", 1.2f);
    }

    void KillYourself()
    {
        Destroy(this.gameObject);
    }
 
}
