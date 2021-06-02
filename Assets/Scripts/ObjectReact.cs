using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectReact : MonoBehaviour
{
    public AudioSource pointSource;
    public GameManager gameManager;
    public Outline outline;
    int counter = 0;
    bool canHover = true;
    public void hoverEnter(){
        if(canHover){
            outline.OutlineMode = Outline.Mode.OutlineVisible;
            outline.OutlineColor = Color.yellow;
            outline.OutlineWidth = 2f;
        }
    }
    public void hoverExit(){
        if(canHover){
            outline.OutlineMode = Outline.Mode.OutlineVisible;
            outline.OutlineColor = Color.grey;
            outline.OutlineWidth = 6f;
        }
    }

    public void testActive(){
        Debug.Log("you left clicked this thing");
    }
    public void doSomething(){
        Debug.Log("clicked an interesting object: " + transform.name);
        if (counter == 0){
            counter++;
            pointSource.Play();
            gameManager.scorePoint(transform.name);
            if (transform.tag == "Interactive"){
                outline.OutlineColor = Color.green;
            }
            else{
                outline.OutlineColor = Color.red;
            }
            outline.OutlineMode = Outline.Mode.OutlineVisible;
            outline.OutlineWidth = 2f;
            canHover = false;
        }
        else if (counter > 0 && transform.tag == "Interactive"){
            Debug.Log("requesting to hold interactive instrument " + transform.name);
            if(transform.name ==  "BassConcert"){
                
                gameManager.bassHold = true;
                gameManager.bass.SetActive(true);
            }
            else if (transform.name == "AGuitar"){
                
                gameManager.aGuitarHold = true;
                gameManager.aGuitar.SetActive(true);
            }
            else if (transform.name == "Mic"){
                
                gameManager.micHold = true;
                gameManager.mic.SetActive(true);
            }
            else if (transform.name == "EGuitar"){
                
                gameManager.eGuitarHold = true;
                gameManager.eGuitar.SetActive(true);
            }
            else if (transform.name == "Drums"){
                gameManager.drumCheck = true;
                gameManager.playDrums();
            }
        }
    }
}
