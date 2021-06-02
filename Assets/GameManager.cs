using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public string textScore;
    public bool bassCheck = false;
    public bool bassHold = false;
    public bool aGuitarCheck = false;
    public bool aGuitarHold = false;
    public bool eGuitarCheck = false;
    public bool eGuitarHold = false;
    public bool micCheck = false;
    public bool micHold = false; 
    public bool drumCheck = false;
    public bool hasPlayed = false;
    public bool songSwitch = false;
    public GameObject aGuitar;
    public AudioSource aGuitarSource;
    public GameObject eGuitar;
    public AudioSource eGuitarSource;
    public GameObject bass;
    public AudioSource bassSource;
    public GameObject mic;
    public AudioSource micSource;

    public AudioSource drumSource;

    public AudioSource dontWorry;
    void Update()
    {
        // if the user hasnt played all the instruments 
        // they are allowed to play the instruments
        if (!(micCheck && drumCheck && eGuitarCheck && aGuitarCheck && bassCheck)){
            if (bassHold || micHold|| aGuitarHold|| eGuitarHold){
                // If user pressed right click - play audio source
                if (Input.GetMouseButtonDown(1)){
                    
                    // holding bass
                    if(bassHold == true){
                        bassCheck = true;
                        Debug.Log("play bass audio");
                        bassSource.Play();
                    }
                    // holding aGuitar
                    else if(aGuitarHold == true){
                        aGuitarCheck = true;
                        Debug.Log("play acoustic audio");
                        aGuitarSource.Play();
                    }
                    // holding eGuitar
                    else if(eGuitarHold == true){
                        eGuitarCheck = true;
                        Debug.Log("play electric audio");
                        eGuitarSource.Play();
                    }
                    // holding bass
                    else if(micHold == true){
                        micCheck = true;
                        Debug.Log("play mic audio");
                        micSource.Play();
                    }
                }
                // If user pressed left click - release instrument
                else if (Input.GetMouseButtonDown(0)){
                    deactivateInstruments();
                }
            }
        }
        else{
            // play the song
            if(!hasPlayed){
                dontWorry.Play();
                songSwitch = true;
                hasPlayed = true;
            }
                
        }
    }
    public bool getSongSwitch(){
        return songSwitch;
    }
    public void playDrums(){
        Debug.Log("play drum audio");
        drumSource.Play();
    }

    void deactivateInstruments(){
        mic.SetActive(false);
        aGuitar.SetActive(false);
        eGuitar.SetActive(false);
        bass.SetActive(false);
        bassHold = false;
        micHold = false;
        aGuitarHold = false; 
        eGuitarHold = false;
    }
    public void scorePoint(string name){

        switch (name){
            case "BassHallway":
                
            case "AcousticHallway":
                Debug.Log("clicked a hallway instrument +10");
                score += 10;
                break;
            case "BassConcert":
                Debug.Log("clicked on the bass +20");
                score += 20;
                break;
            case "Mic":
                Debug.Log("clicked on the bass +20");
                score += 20;
                break;
            
            case "AGuitar":
            case "EGuitar":
                Debug.Log("clicked on a Guitar +30");
                score += 30;
                break;
            case "Drums":
                Debug.Log("clicked on the drums +40");
                score += 40;
                break;
            
            default:
                Debug.Log("clicked an amplifier +5");
                score += 5;
                break;
        }
        Debug.Log("Score: " + score.ToString());
    }

    public string createText(){
        textScore = "Score: " + score.ToString();
        if (score >= 150)
            textScore = "Score: "+ score.ToString() + " You Win!";
        return textScore;
    }


}
