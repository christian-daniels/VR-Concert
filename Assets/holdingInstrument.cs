using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holdingInstrument : MonoBehaviour
{
    public GameObject aGuitar;
    public AudioSource aGuitarSource;
    public GameObject eGuitar;
    public AudioSource eGuitarSource;
    public GameObject bass;
    public AudioSource bassSource;
    public GameObject mic;
    public AudioSource micSource;

    public AudioSource drumSource;

    public GameManager gameManager;
    // gameManager holds information on what instrument was
    // picked up - simply check what flag is up and play 
    // instrument sample

    void Update()
    {
        // If user pressed left click - play audio source
        if (Input.GetMouseButtonDown(1)){
            Debug.Log("play audio");
            // holding bass
            if(gameManager.bassCheck){
                bassSource.Play();
            }
            // holding aGuitar
            else if(gameManager.aGuitarCheck){
                aGuitarSource.Play();
            }
            // holding eGuitar
            else if(gameManager.aGuitarCheck){
                eGuitarSource.Play();
            }
            // holding bass
            else if(gameManager.micCheck){
                micSource.Play();
            }
        }
    }
    void deactivateInstruments(){
        mic.SetActive(false);
        aGuitar.SetActive(false);
        eGuitar.SetActive(false);
        bass.SetActive(false);
    }
}
