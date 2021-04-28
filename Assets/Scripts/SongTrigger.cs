using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongTrigger : MonoBehaviour
{
    public AudioSource audioSource;
    [SerializeField] private Animator myAnimationController;
    int counter;
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
    }

    // Update is called once per frame
    void OnTriggerEnter(){
        
        counter++;
        if (counter == 1){
            // Play audio here
            audioSource.Play();
            myAnimationController.SetBool("playMoon", true);
        }
    }
}
