using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Clear : MonoBehaviour
{
    public float score = 0;

    public GameObject[] targets;

    private bool actionEnd;

    // Update is called once per frame
    void Update()
    {
        if (actionEnd) return;
        if (score >= 10)
        {
            foreach (GameObject target in targets)
            {
                target.SetActive(true);
            }
            actionEnd = true;
        }
     }

    private void OnCollisionEnter(Collision collision)
    {
        //print("Enter");

        if (collision.collider.CompareTag("EGGGGGGG"))
        {

            collision.gameObject.SetActive(false);
            score += 1;

        }

    }
}
