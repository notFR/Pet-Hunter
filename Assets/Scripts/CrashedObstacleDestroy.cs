using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashedObstacleDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyYourself());
    }

    IEnumerator DestroyYourself()
    {
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
}
