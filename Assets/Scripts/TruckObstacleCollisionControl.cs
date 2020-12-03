using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TruckObstacleCollisionControl : MonoBehaviour
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
        if(collision.gameObject.tag == "ObstacleObj" || collision.gameObject.tag == "CrashedObstacleObj")// Player ile ObstacleObj arasında carpisma olursa
        {
            //Death if not moving obstacle
            if (collision.rigidbody.velocity.magnitude < 0.1f)
            {
                Debug.Log("GameOver");
                // GameOver paneline skor yaz
                GameOverScore.text = Score.text;
                GameObject.Find("Character").GetComponent<CharacterMovement>().enabled = false;
                GameObject.Find("Character").GetComponent<Animator>().enabled = false;
                GameOverPanel.SetActive(true); //Game Over panel ac
            }

        }
       
    }
   

}
