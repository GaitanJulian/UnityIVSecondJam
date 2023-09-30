using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPops : MonoBehaviour
{
    public GameObject[] props;


    private void OnTriggerEnter(Collider other)
    {
        foreach (var prop in props)
        {
            Destroy(prop);
        }
    }
}
