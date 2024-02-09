using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(message:$"{gameObject.name} collided with {other.gameObject.name}");
        Destroy(gameObject);
        
        //Debug.Log(message:$"{gameObject.name} collided with {other.gameObject.name}");
        //DestroyImmediate(gameObject);
    }
}
