using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CollectedObjProperties : MonoBehaviour
{
  
    //public ParticleSystem collectParticle;
    private ParticleSystem collectParticle;
    public bool isCollected;

    private Image catchImage;

    private bool collected;

    public int animalType;
    private void Start()
    {

        isCollected = false;
        collectParticle = GameObject.Find("Character").GetComponentInChildren<ParticleSystem>();

        catchImage = GameObject.Find("CatchImage").GetComponent<Image>();

        collected = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collected = true;

            StartCoroutine(WaitText());
        }
        
    }

    public void catchText()
    {
        StartCoroutine(WaitText());
    }
    IEnumerator WaitText()
    {

        catchImage.enabled = true;
        yield return new WaitForSeconds(0.5f);
        catchImage.enabled = false;
    }
    public void HunterCatch()
    {
        this.gameObject.transform.tag = "Hunted";
        this.gameObject.SetActive(false);
    }
    

    public bool IsCollected()
    {
        return collected;
    }
}
