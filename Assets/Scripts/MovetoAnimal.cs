using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovetoAnimal : MonoBehaviour
{
    
    public List<GameObject> CollectedObjectsList = new List<GameObject>();
    public ParticleSystem particlePrefab;
    public GameObject Character,FireRange,Target,Truck;
    public bool MoveBool,toOriginBool;
    public GameObject flash;
    public GameManager gameManager;
    public GameObject lastPet;
    public Animator animator;

    void Start()
    {
        
        Character = GameObject.Find("Character");
        FireRange=GameObject.Find("FireRange");
        Truck=GameObject.Find("Truck");
        
        
        SetTrailRenderer(false);
      
    }
    
    void Update()
    {
        if (MoveBool)
        {
            MovetoAnimals();
        }

        if (toOriginBool)
        {
            MovetoOrigin();
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "CollectableObj") // CollectedObj collision detect
        {

            //Stop Animation
            if (collision.gameObject.GetComponent<Animator>() != null)
            {
                collision.gameObject.GetComponent<Animator>().speed = 0.0f;
                collision.gameObject.GetComponent<Animator>().Play("Walk", 0, 0);
            }

            SpawnParticle(collision.gameObject.transform.position);
            CollectedObjectsList.Add(collision.gameObject);// CollectedObj listeye eklendi 
            collision.gameObject.transform.SetParent(Truck.transform);
            collision.gameObject.GetComponent<ObjectMovement>().enabled = false;
            collision.gameObject.transform.rotation = Quaternion.Euler(0f, 90f, 0f);

            collision.gameObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);           
            collision.gameObject.transform.GetComponent<CollectedObjProperties>().isCollected = true;
            collision.gameObject.GetComponent<BoxCollider>().enabled = false;

            if (CollectedObjectsList.Count == 1)
            {
              /*  CollectedObjectsList[CollectedObjectsList.Count - 1].transform.localPosition = new Vector3(
                    0, -collision.gameObject.GetComponent<Renderer>().bounds.size.y / 1200f,
                    0.00768f);
               */
              CollectedObjectsList[CollectedObjectsList.Count - 1].transform.localPosition = new Vector3(
                  0, -collision.gameObject.GetComponent<Renderer>().bounds.size.y / 1200f,
                  0.013f);
            }
            else if (CollectedObjectsList.Count > 1)
            {
                CollectedObjectsList[CollectedObjectsList.Count - 2].transform.localPosition = 
                    new Vector3(0, -collision.gameObject.GetComponent<Renderer>().bounds.size.y / 1200f,
                    0.015f);
                CollectedObjectsList[CollectedObjectsList.Count-1].transform.localPosition= 
                    new Vector3(0, -collision.gameObject.GetComponent<Renderer>().bounds.size.y / 1200f, 0.013f);
                
                if (CollectedObjectsList.Count > 2)
                {
                    CollectedObjectsList[CollectedObjectsList.Count - 3].SetActive(false);
                }
            }

            
            AddScore(collision);
            
            MoveBool = false;
            toOriginBool = true;
        }
    }
    void SpawnParticle(Vector3 spawnPos)
    {
        spawnPos += new Vector3(0f, 2.5f, 0f);
        ParticleSystem particle = Instantiate(particlePrefab, spawnPos, Quaternion.identity);
        particle.Play();
    }

    public void MovetoAnimals()
    {
        FireRange.SetActive(false);
        MoveCharacter(Target.transform.position);
        
        transform.LookAt(Target.transform);
        
        SetTrailRenderer(true);

        if (Target.transform.position.z < transform.position.z)
        {
            
            MoveBool = false;
            toOriginBool = true;
        }

    }

    public void MovetoOrigin()
    {
        Vector3 origin=new Vector3(-0.675f,Character.transform.position.y,Character.transform.position.z);
        MoveCharacter(origin);
        
        transform.LookAt(origin);
       
        SetTrailRenderer(true);
            
            if ((Character.transform.position - origin).magnitude < 0.0001f)
            {
                
                toOriginBool = false;
                
                Quaternion org=Quaternion.Euler(0,0,0);
                transform.rotation = org;

                SetFireRangetoOrjinalPosition(org);
                
                SetTrailRenderer(false);
            }
    }

    public void MoveCharacter(Vector3 tr)
    {
        tr.y = 0.19f;
        Character.transform.position =
            Vector3.MoveTowards(Character.transform.position, tr, 0.275f);
        
    }

    public void SetTrailRenderer(bool boolean)
    {
        foreach (Transform child in flash.transform)
        {
            child.gameObject.GetComponent<TrailRenderer>().enabled = boolean;
        }
    }

    public void AddScore(Collision col)
    {
        switch (col.gameObject.GetComponent<CollectedObjProperties>().animalType)
        {
            case SpawnObject.TYPE_DOG:
                gameManager.gameObject.GetComponent<GameManager>().Score += 1000;
                gameManager.gameObject.GetComponent<GameManager>().scoreText.text =  gameManager.gameObject.GetComponent<GameManager>().Score.ToString();
                break;
                
            case SpawnObject.TYPE_CAT:
                gameManager.gameObject.GetComponent<GameManager>().Score += 2000;
                gameManager.gameObject.GetComponent<GameManager>().scoreText.text =  gameManager.gameObject.GetComponent<GameManager>().Score.ToString();
                break;
                
            case SpawnObject.TYPE_RABBIT:
                gameManager.gameObject.GetComponent<GameManager>().Score += 3000;
                gameManager.gameObject.GetComponent<GameManager>().scoreText.text =  gameManager.gameObject.GetComponent<GameManager>().Score.ToString();
                break;
                
            default:
                break;
        }
    }

    public void SetFireRangetoOrjinalPosition(Quaternion quar)
    {
        FireRange.transform.rotation = quar;
        FireRange.SetActive(true);
    }
}
