using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterToPet : MonoBehaviour
{
    public GameObject targetPet;
    Vector3 newDestination;
    public SpawnObject spawnObject;
    public MovetoAnimal movetoAnimal;
    public float HunterSpeed;
    private void Awake()
    {
        movetoAnimal = FindObjectOfType<MovetoAnimal>();
        spawnObject = FindObjectOfType<SpawnObject>();
        targetPet = gameObject.transform.parent.gameObject;
        newDestination = targetPet.transform.position;
        newDestination.y = transform.position.y;
        transform.LookAt(targetPet.transform);
        transform.parent = null;
        HunterSpeed = 3.25f;


    }


    // Update is called once per frame
    void Update()
    {
        if (targetPet.GetComponent<CollectedObjProperties>().isCollected)
        {
            this.gameObject.SetActive(false);
        }
        //active oldugu zaman pet'e dogru kosar
        if (gameObject.activeSelf)
        {
            speedControl();
            transform.position = Vector3.MoveTowards(transform.position, newDestination, HunterSpeed * Time.deltaTime);
        }
        

    }

    void speedControl()
    {
        if(targetPet.transform.position.x <= -4.6f || targetPet.transform.position.x >= 3.05f)
        {
            HunterSpeed=2f;
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "CollectableObj")// eger new hunter yakalar ise pet ile yok olur
        {
            collision.gameObject.GetComponent<CollectedObjProperties>().HunterCatch();
            movetoAnimal.MoveBool = false;
            movetoAnimal.toOriginBool = true;
            Destroy(this.gameObject);

        }
    }


}
