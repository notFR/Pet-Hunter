using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRangeRotation : MonoBehaviour
{
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;
    
    void Start()
    {
        
    }

    
    void Update()
    {
       Rotation();
    }

    public void Rotation()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                Quaternion rotation = Quaternion.Euler(0,
                    touch.deltaPosition.x * 0.35f,
                    0);

                transform.rotation = rotation * transform.rotation;



                if (transform.localEulerAngles.y > 70 && transform.localEulerAngles.y <= 180)
                {
                    transform.eulerAngles = new Vector3(0, 70, 0);
                }

                if (transform.localEulerAngles.y > 180 && transform.localEulerAngles.y < 290)
                {
                    transform.eulerAngles = new Vector3(0, -70, 0);
                }
            }

        }
      
       
       /*if (Input.GetMouseButtonDown(0))
       {
           firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
       }

       if (Input.GetMouseButton(0))
       {
           secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
           currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

           if (firstPressPos != secondPressPos)
           {
               Quaternion rotation = Quaternion.Euler(0,
                   currentSwipe.x * 0.01f,
                   0);

               transform.rotation = rotation * transform.rotation;
               
               if (transform.localEulerAngles.y > 70 && transform.localEulerAngles.y <= 180)
               {
                   transform.eulerAngles = new Vector3(0, 70, 0);
               }

               if (transform.localEulerAngles.y > 180 && transform.localEulerAngles.y < 290)
               {
                   transform.eulerAngles = new Vector3(0, -70, 0);
               }
           }
       }*/
    }
}
