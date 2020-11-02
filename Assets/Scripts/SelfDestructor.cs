using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructor : MonoBehaviour
{
    [SerializeField] float destroyDelay = 5f;//TODO allow for customizable from parent

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyDelay); 
    }

}
