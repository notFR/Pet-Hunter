using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishLine : MonoBehaviour
{
    public GameObject GameFinishedPanel;
    [SerializeField]
    private Text FinishedScoreText;
    [SerializeField]
    private Text Score;

    private SpawnObject spawnObject;
    public ParticleSystem konfetiPrefab;


    public GameObject missionFailedPanel;
    void Start()
    {
        GameFinishedPanel.SetActive(false);
        spawnObject = GameObject.Find("GameManager").GetComponent<SpawnObject>();

        missionFailedPanel.SetActive(false);
    }
    
    
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            PlayParticle(col);
            FinishedScoreText.text = Score.text; // Finish panele skor yaz
            GameObject.Find("Character").GetComponent<CharacterMovement>().enabled = false;
            GameObject.Find("Character").GetComponent<Animator>().enabled = false;

            StartCoroutine(WaitParticle());
            spawnObject.CalculateSpawnCount();
          
        }
    }
    IEnumerator WaitParticle()
    {
        yield return new WaitForSeconds(1f);
        //If not pass mission,display Mission Failed panel
        if (!GameObject.Find("GameManager").GetComponent<Mission>().CheckRequirementsPass())
        {
            Debug.Log("failed");
            missionFailedPanel.SetActive(true);
        }
        else
        {
            GameFinishedPanel.SetActive(true); // Finish panel ac

            SetNumberOfNextLevel();

        }
    }

    public void SetNumberOfNextLevel()
    {
        int level=PlayerPrefs.GetInt("CurrentLevel",0);
        level += 1;
        PlayerPrefs.SetInt("CurrentLevel",level);
    }
    void PlayParticle(Collider _col)
    {
        ParticleSystem PS = Instantiate(konfetiPrefab, _col.transform.position, Quaternion.Euler(-90f,0f,0f));
        PS.Play();
    }
}
