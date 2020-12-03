using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalTruckOrder : MonoBehaviour
{
    public MovetoAnimal moveToAnimal;
    void Start()
    {
        moveToAnimal = GameObject.Find("Character").GetComponent<MovetoAnimal>();
    }

    
    void Update()
    {
        if (this.gameObject == moveToAnimal.CollectedObjectsList[moveToAnimal.CollectedObjectsList.Count - 1])
        {
            transform.localPosition = new Vector3(
                0, 1,
                0.00768f);
        }
        else if (this.gameObject == moveToAnimal.CollectedObjectsList[moveToAnimal.CollectedObjectsList.Count - 2])
        {
            transform.localPosition = 
                new Vector3(0, 1,
                    0.013f);
        }
        else if (this.gameObject == moveToAnimal.CollectedObjectsList[moveToAnimal.CollectedObjectsList.Count - 3])
        {
            gameObject.SetActive(false);
        }
    }
}
