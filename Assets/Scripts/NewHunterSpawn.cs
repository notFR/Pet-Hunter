using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewHunterSpawn : MonoBehaviour
{
    public SpawnObject spawnObject;
    public GameObject Character;
    private int closestPetIndex;
    private float rightOrleft;
    
    // Start is called before the first frame update
    void Start()
    {
        closestPetIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // en yakin kediyi tespit et ve hunter'i active et
        if(closestPetIndex < spawnObject.Allpets.Count && spawnObject.Allpets[closestPetIndex].transform.position.z - Character.transform.position.z < 10f)
        {           
            GameObject ClosestPet = spawnObject.Allpets[closestPetIndex];
            GameObject Hunter = spawnObject.Allpets[closestPetIndex].transform.GetChild(0).gameObject;

            rightOrleft = ClosestPet.transform.position.x - Character.transform.position.x;
            // sag sol kontrolu yapar
            if (rightOrleft >= 0)
            {
                Hunter.transform.position = new Vector3(6.5f, 0.439f, ClosestPet.transform.position.z+3f);
            }
            else
            {
                Hunter.transform.position = new Vector3(-6.5f, 0.439f, ClosestPet.transform.position.z+3f);
            }                  
            Hunter.SetActive(true);
            closestPetIndex++;
            
        }
    }
   

}
