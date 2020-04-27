using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    void Update()
    {
        Destroy(gameObject, 2f);
    }

}
