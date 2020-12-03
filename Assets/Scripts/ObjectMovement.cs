using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float PosX;
    public float Timer;
    void Start()
    {
        PosX = Random.Range(transform.position.x - 1f, transform.position.x + 1f);
        SetRotationOfObject();
    }

    void Update()
    {
        Timer += Time.deltaTime;
        SetTargetOfObject();
        MoveObject();
    }

    public void SetRotationOfObject()
    {
        if (transform.position.x > PosX)
        {
            Quaternion rotation = Quaternion.Euler(0, -90, 0);
            transform.rotation = rotation;
        }
        else
        {
            Quaternion rotation = Quaternion.Euler(0, 90, 0);
            transform.rotation = rotation;
        }
    }

    public void SetTargetOfObject()
    {
        if (Timer >= 2)
        {
            PosX = Random.Range(transform.position.x - 1.5f, transform.position.x + 1.5f);
            SetRotationOfObject();
            Timer -= 3;
        }

    }

    public void MoveObject()
    {
        if (PosX > -4.25f && PosX < 3.75f)
        {
            
            transform.position = Vector3.MoveTowards(transform.position,
                new Vector3(PosX, transform.position.y, transform.position.z),
                0.0125f);

            if (Mathf.Abs(transform.position.x - PosX) > 0.05f)
            {
                if (gameObject.GetComponent<Animator>() != null)
                {
                    gameObject.GetComponent<Animator>().speed = 6.0f;
                }
            }
            else
            {
                if (gameObject.GetComponent<Animator>() != null)
                {
                    gameObject.GetComponent<Animator>().speed = 0.0f;
                    gameObject.GetComponent<Animator>().Play("Walk", 0, 0);
                }
            }
        }
        else
        {
            if (gameObject.GetComponent<Animator>() != null)
            {
                gameObject.GetComponent<Animator>().speed = 0.0f;
                gameObject.GetComponent<Animator>().Play("Walk", 0, 0);
            }
        }
    }
}