using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRangeController : MonoBehaviour
{

    private List<GameObject> CollectedObjectsList=new List<GameObject>();
    private List<GameObject> AlreadyCollectedObjectsList = new List<GameObject>();
    [SerializeField]
    private GameObject Truck;
    private GameManager gameManager;
    public  ParticleSystem particlePrefab;
    private bool isTransport;

    public MovetoAnimal movetoAnimal;

    public GameObject parentObj;
    public Animator animator;

 
    private void Awake()
    {
        parentObj = this.gameObject.transform.root.gameObject;
        isTransport = true;
        gameManager = FindObjectOfType<GameManager>();

        movetoAnimal = GameObject.Find("Character").GetComponent<MovetoAnimal>();
        animator =GameObject.Find("Character").GetComponent<Animator>();

    }

    public void Update()
    {
       
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.transform.position.z - parentObj.transform.position.z >=4f && collision.gameObject.tag == "CollectableObj")// CollectedObj collision detect
        {
            animator.Play("Snatch");
            Debug.Log(collision.gameObject.transform.position.z - parentObj.transform.position.z);
            movetoAnimal.Target = collision.gameObject;
            movetoAnimal.MoveBool = true;

           /* for (int i = 0; i < CollectedObjectsList.Count; i++)
            {
                if (CollectedObjectsList[i].name == collision.gameObject.name)
                {
                    isTransport = false;   
                }
            }

           
          
            if (isTransport)
            {
                SpawnParticle(collision.gameObject.transform.position);
                CollectedObjectsList.Add(collision.gameObject);// CollectedObj listeye eklendi 
                collision.gameObject.transform.SetParent(Truck.transform);
                collision.gameObject.GetComponent<ObjectMovement>().enabled = false;
                collision.gameObject.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                collision.gameObject.transform.localPosition = new Vector3(0, 0, 0.012f);
                gameManager.gameObject.GetComponent<GameManager>().Score += 1000;
                gameManager.gameObject.GetComponent<GameManager>().scoreText.text = "SCORE : " + gameManager.gameObject.GetComponent<GameManager>().Score.ToString();
            }
            else
            {            
                AlreadyCollectedObjectsList.Add(collision.gameObject);
                collision.gameObject.SetActive(false);
                SpawnParticle(collision.gameObject.transform.position);
                gameManager.gameObject.GetComponent<GameManager>().Score += 1000;
                gameManager.gameObject.GetComponent<GameManager>().scoreText.text = "SCORE : " + gameManager.gameObject.GetComponent<GameManager>().Score.ToString();
            }

            */


        }      

    }
    
    void SpawnParticle(Vector3 spawnPos)
    {
        spawnPos += new Vector3(0f, 4f, 0f);
        ParticleSystem particle=Instantiate(particlePrefab,spawnPos,Quaternion.identity);
        particle.Play();
    }
}
