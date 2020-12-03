using System.Collections.Generic;
using UnityEngine;




public class SpawnObject : MonoBehaviour
{

    public const int TYPE_CAT = 0;
    public const int TYPE_DOG = 1;
    public const int TYPE_RABBIT = 2;
    public const int TYPE_MAX = 3;

    public GameObject catPrefab;
    public GameObject dogPrefab;
    public GameObject rabbitPrefab;
    public List<GameObject> Allpets;

    private Vector3 startPoint, endPoint;

    private GameObject character;

    private List<GameObject> petSpawnList;//Array of spawned objects

    private int[] counts;//Counts of each pet type
    private int[] collectedCounts;//Collected object count
    private List<int> spawnedTypes;//Array of types of spawned pets


    void Start()
    {
        counts = new int[TYPE_MAX];
        SetupObjects();
        SpawnPets();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SetupObjects()
    {

        character = GameObject.Find("Character");
        startPoint = GameObject.Find("Path/StartPosition").transform.position;
        endPoint = GameObject.Find("Path/EndPosition").transform.position;

    }

    void SpawnPets()
    {

        petSpawnList = new List<GameObject>();
        collectedCounts = new int[TYPE_MAX];
        spawnedTypes = new List<int>();
        int[] spawnedCounts = new int[TYPE_MAX];

        CalculateSpawnCount();

        spawnedCounts[TYPE_CAT] = 0;
        spawnedCounts[TYPE_DOG] = 0;
        spawnedCounts[TYPE_RABBIT] = 0;
        int totalSpawn = 0;
        int totalSpawnType = 0;
        for (int i = 0; i < TYPE_MAX; i++)
        {
            //Calculate Total animal spawn count
            totalSpawn += counts[i];

            //Calculate how much different animal types exists
            if (counts[i] > 0)
            {
                totalSpawnType++;
            }
        }

        float offset = 20.0f;

        float spawnLength = Mathf.Abs(endPoint.z - (startPoint.z + offset)) / totalSpawn;
        float posZ = character.transform.position.z;

        int spawnChanger = 0;//It is important to order spawn

        int sideCounter = 0;

        for (int i = 0; i < totalSpawn; i++)
        {
            //Prevent same distance
            float randomOffset = Random.Range(0.0f, spawnLength * 0.25f);

            float nextZ = i * spawnLength + (startPoint.z + offset) + randomOffset;
            float nextX = 0.0f;

            //Sagli sollu
            if (sideCounter == 0)
            {
                //Align left
                nextX = Random.Range(-4.0f, -2.0f);
            }
            else if(sideCounter == 1)
            {
                //Align right
                nextX = Random.Range(0.5f, 3.5f);
            }
            else
            {
                //Choose random side
                int side = Random.Range(0, 2);
                if (side == 0)
                {
                    //Left
                    nextX = Random.Range(-4f, -2.0f);
                }
                else
                {
                    //Right
                    nextX = Random.Range(0.5f, 3.5f);
                }
            }
            //Increase and reset the side conter
            sideCounter++;
            sideCounter %= 8;
            

            Vector3 petSpawnPosition = new Vector3(nextX,0 , nextZ);

            //First spawn a cat
            // Then spawn a dog
            //Then spawn a rabbit
            if (spawnedCounts[TYPE_CAT] < counts[TYPE_CAT] && spawnChanger == 0)
            {
                petSpawnPosition.y = 0.15f;
                GameObject lastPet = Instantiate(catPrefab, petSpawnPosition, Quaternion.identity);
                spawnedTypes.Add(TYPE_CAT);
                petSpawnList.Add(lastPet);
            }
            if (spawnedCounts[TYPE_DOG] < counts[TYPE_DOG] && spawnChanger == 1)
            {

                petSpawnPosition.y = 0.19f;
                GameObject lastPet = Instantiate(dogPrefab, petSpawnPosition, Quaternion.identity);
                spawnedTypes.Add(TYPE_DOG);
                petSpawnList.Add(lastPet);
            }
            if (spawnedCounts[TYPE_RABBIT] < counts[TYPE_RABBIT] && spawnChanger == 2)
            {

                petSpawnPosition.y = 0.625f;
                GameObject lastPet = Instantiate(rabbitPrefab, petSpawnPosition, Quaternion.identity);
                spawnedTypes.Add(TYPE_RABBIT);
                petSpawnList.Add(lastPet);
            }
            spawnChanger++;
            spawnChanger %= totalSpawnType;
        }
        Allpets = petSpawnList;// butun hayvanlari listeye atar
    }


    public void CalculateSpawnCount()
    {
        counts = new int[TYPE_MAX];

        counts[TYPE_CAT] = 5;//For level 1
        counts[TYPE_DOG] = 0;//For level 1
        counts[TYPE_RABBIT] = 0;//For level 1

        int level = PlayerPrefs.GetInt("CurrentLevel", 1);

        //ilk level 1 kedi
        //2.level -> 2kedi
        //3.level -> 2 kedi 1köpek
        //10.leveldan sonra tavşan

        //level 1 -> 1 spwan
        //level 20 -> 10 spawn
        //level 30 -> 15 spawn

        if (level > 1)
        {
            counts[TYPE_CAT]++;
        }
        if (level > 2)
        {
            counts[TYPE_DOG]++;
        }
        if (level > 3 && level < 10)
        {

            float perLevel = 1.0f / 4.0f;
            counts[TYPE_CAT] += (int)(perLevel * level);
            counts[TYPE_DOG] += (int)(perLevel * level);
        }

        if (level >= 10)
        {
            float perLevel = 1.0f / 8.0f;
            counts[TYPE_CAT] = 5 + (int)(perLevel * (level - 10));
            counts[TYPE_DOG] = 5 + (int)(perLevel * (level - 10));
        }

        if (level > 9)
        {
            float perLevel = 1.0f / 8.0f;
            counts[TYPE_RABBIT] = 1 + (int)(perLevel * (level - 9));
        }

        //Set maximum limit, minimum limit
        counts[TYPE_CAT] = Mathf.Clamp(counts[TYPE_CAT], 1, 20);
        counts[TYPE_DOG] = Mathf.Clamp(counts[TYPE_DOG], 0, 15);
        counts[TYPE_RABBIT] = Mathf.Clamp(counts[TYPE_RABBIT], 0, 10);
        Debug.Log("Spawned cat count=" + counts[TYPE_CAT].ToString());
        Debug.Log("Spawned dog count=" + counts[TYPE_DOG].ToString());
        Debug.Log("Spawned rabbit count=" + counts[TYPE_RABBIT].ToString());

    }

    public int[] GetSpawnCounts()
    {
        return counts;
    }

    public int[] GetCollectedCounts()
    {
        for (int i = 0; i < collectedCounts.Length; i++)
        {
            collectedCounts[i] = 0;
        }
        for (int i = 0; i < petSpawnList.Count; i++)
        {
            if (petSpawnList[i].GetComponent<CollectedObjProperties>().IsCollected())
            {
                collectedCounts[spawnedTypes[i]]++;
            }
        }
        return collectedCounts;
    }

}
