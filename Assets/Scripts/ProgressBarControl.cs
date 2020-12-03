using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarControl : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private Transform startTransform;
    [SerializeField]
    private Transform endTransform;
    private float totalDistance;
    [SerializeField]
    private Transform PlayerTransform;
    private float currentDistance;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = 0f;
        totalDistance = Vector3.Distance(startTransform.position, endTransform.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentDistance = Vector3.Distance(PlayerTransform.position, endTransform.position);
        slider.value = currentDistance / totalDistance;
        if (slider.value <= 0.02f)
        {
            //mission passed and open result panel
            Debug.Log("Mission Completed");
        }
    }
}
