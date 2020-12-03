using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;




public class Mission : MonoBehaviour
{
    private int[] requirements;

    public Image catsImage;
    public Image dogsImage;
    public Image rabbitsImage;

    private bool requirementsSetted;

    // Start is called before the first frame update
    void Start()
    {
        requirementsSetted = false;
    }

    void Update()
    {
        if(!requirementsSetted)
        {
            SetRequirements();
            requirementsSetted = true;
        }

        UpdateResults();
    }

    //Dont run in Start()
    void SetRequirements()
    {
        requirements = new int[SpawnObject.TYPE_MAX];

        int[] spawneds =  GameObject.Find("GameManager").GetComponent<SpawnObject>().GetSpawnCounts();

        for (int i = 0; i < requirements.Length; i++)
        {
            requirements[i] = (int)(spawneds[i] * 0.75f);

            //Set at least one animal
            if(spawneds[i]>0 && requirements[i]==0)
            {
                requirements[i] = 1;
            }

        }
    }

    public bool CheckRequirementsPass()
    {

        int[] collecteds = GameObject.Find("GameManager").GetComponent<SpawnObject>().GetCollectedCounts();
        for (int i = 0; i < requirements.Length; i++)
        {
            if (collecteds[i] < requirements[i])
            {
                return false;
            }

        }
        return true;
    }

    private void UpdateResults()
    {

        int[] collecteds = GameObject.Find("GameManager").GetComponent<SpawnObject>().GetCollectedCounts();
        if (requirements[SpawnObject.TYPE_CAT] > 0)
        {
            catsImage.GetComponentInChildren<Text>().text = collecteds[SpawnObject.TYPE_CAT].ToString()
                + "/" + requirements[SpawnObject.TYPE_CAT];

            catsImage.gameObject.SetActive(true);
            
            if (collecteds[SpawnObject.TYPE_CAT]>= requirements[SpawnObject.TYPE_CAT])
            {
                catsImage.GetComponentInChildren<Text>().color = new Color(0, 1, 0);//Set it green
            }
        }
        else
        {
            catsImage.gameObject.SetActive(false);
        }

        if (requirements[SpawnObject.TYPE_DOG] > 0)
        {
            dogsImage.GetComponentInChildren<Text>().text =collecteds[SpawnObject.TYPE_DOG].ToString()
                + "/" + requirements[SpawnObject.TYPE_DOG];
            
            dogsImage.gameObject.SetActive(true);
            
            if (collecteds[SpawnObject.TYPE_DOG] >= requirements[SpawnObject.TYPE_DOG])
            {
                dogsImage.GetComponentInChildren<Text>().color = new Color(0, 1, 0);//Set it green
            }
        }
        else
        {
            dogsImage.gameObject.SetActive(false);
        }

        if (requirements[SpawnObject.TYPE_RABBIT] > 0)
        {
            rabbitsImage.GetComponentInChildren<Text>().text = collecteds[SpawnObject.TYPE_RABBIT].ToString() + 
                "/" + requirements[SpawnObject.TYPE_RABBIT];

            rabbitsImage.gameObject.SetActive(true);

            if (collecteds[SpawnObject.TYPE_RABBIT] >= requirements[SpawnObject.TYPE_RABBIT])
            {
                rabbitsImage.GetComponentInChildren<Text>().color = new Color(0, 1, 0);//Set it green
            }
        }
        else
        {
            rabbitsImage.gameObject.SetActive(false);
        }
    }

}
