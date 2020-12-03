using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapToStartGame : MonoBehaviour
{
    public GameObject TaptoScreen;
    void Start()
    {
      DisabledMovement();
      TaptoScreen.SetActive(true);
    }

   
    void Update()
    {
   /*     if (Input.touchCount > 0)
        {
           EnabledMovement();
        }  */
       
       if (Input.GetMouseButtonDown(0))
       {
           EnabledMovement();
       }
    }

    public void DisabledMovement()
    {
        GameObject.Find("Character").GetComponent<CharacterMovement>().enabled = false;
        GameObject.Find("Character").GetComponent<Animator>().enabled = false;
        GameObject.Find("FireRange").GetComponent<FireRangeRotation>().enabled = false;
    }

    public void EnabledMovement()
    {
        GameObject.Find("Character").GetComponent<CharacterMovement>().enabled = true;
        GameObject.Find("Character").GetComponent<Animator>().enabled = true;
        GameObject.Find("FireRange").GetComponent<FireRangeRotation>().enabled = true;
        
        
        TaptoScreen.SetActive(false);
        
    }
}
