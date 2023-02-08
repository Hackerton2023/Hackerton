using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;


public class Player : MonoBehaviour
{
    private AudioSource sound;
    float n;
    int m;

    string s;

    int[] arr;

    public TextMeshProUGUI text;
    public float score = 0;

    // Start is called before the first frame update
    void Start()
    {
        SoundManager soundManager = FindObjectOfType<SoundManager>();
        if (soundManager)
        {
            sound = soundManager.transform.parent.Find("Pop").GetComponent<AudioSource>();
        }
    }


    // 1번 : 처음 부딛힐때
    private void OnCollisionEnter(Collision collision)
    {
        //print("Enter");

        if (collision.collider.CompareTag("EGGGGGGG"))
        {
            
            collision.gameObject.SetActive(false);
            score += 1;
            sound.Play(); //재생
            SetText();

        }

    }

    public void SetText()
    {
        text.text = "현재 점수: " + score.ToString() + "/10";
    }
}
