using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplauseScript : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public AudioSource audioSource3;
    int counter;
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
    }

    void OnTriggerEnter(){
        
        counter++;
        if (counter == 1){
            // Play audio here
            audioSource1.Play();
            audioSource2.Stop();
            audioSource3.Stop();
        }
    }
}
