using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private float movementSpeed = 7.5f;

    void Start()
    {
    }

    void Update()
    {
        transform.position += new Vector3(0, 0, Time.deltaTime * movementSpeed);
    }
    
}



