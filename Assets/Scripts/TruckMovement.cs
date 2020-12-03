using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMovement : MonoBehaviour
{
    public float smoothSpeed;
    public Vector3 offset;
    public GameObject Character;
    
    
    void Start()
    {
        Character=GameObject.Find("Character");
        offset = transform.position - Character.transform.position;
    }
    void LateUpdate()
    {
     
        Vector3 desiredPos = Character.transform.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
        transform.position = new Vector3(transform.position.x, transform.position.y, smoothedPos.z);
        
        
               
    }
}
