using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    private const float Lifetime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, Lifetime);
    }
}