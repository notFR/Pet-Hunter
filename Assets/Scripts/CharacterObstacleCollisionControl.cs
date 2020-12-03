using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterObstacleCollisionControl : MonoBehaviour
{
    [SerializeField]
    private GameObject GameOverPanel;
    [SerializeField]
    private Text GameOverScore;
    [SerializeField]
    private Text Score;

    private void Start()
    {
        GameOverPanel.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "ObstacleObj")// Player ile ObstacleObj arasında carpisma olursa
        {                                            
            Debug.Log("GameOver");
            // GameOver paneline skor yaz
            GameOverScore.text = Score.text;
            GameObject.Find("Character").GetComponent<CharacterMovement>().enabled = false;
            GameObject.Find("Character").GetComponent<Animator>().enabled = false;
            GameOverPanel.SetActive(true); //Game Over panel ac


        }
        //if (collision.gameObject.tag == "CrashedObstacleObj")
        //{
        //    if (transform.position.x >= collision.gameObject.transform.position.x) // carptigi CrashedObstacleObj solunda ise sola dogru addforce uygula
        //    {
        //        collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.left * 15f);
        //    }
        //    else if (transform.position.x < collision.gameObject.transform.position.x) // carptigi CrashedObstacleObj saginda ise saga dogru addforce uygula
        //    {
        //        collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right * 15f);
        //    }
        //}
    }
    //private void OnCollisionStay(Collision collision)
    //{
    //    if (collision.gameObject.tag == "CrashedObstacleObj")
    //    {
    //        if (transform.position.x >= collision.gameObject.transform.position.x) // carptigi CrashedObstacleObj solunda ise sola dogru addforce uygula
    //        {
    //            collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.left * 15f);
    //        }
    //        else if (transform.position.x < collision.gameObject.transform.position.x) // carptigi CrashedObstacleObj saginda ise saga dogru addforce uygula
    //        {
    //            collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right * 15f);
    //        }
    //    }
    //}

}
