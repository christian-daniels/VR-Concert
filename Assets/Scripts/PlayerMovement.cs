using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public LayerMask groundMask;
    public float groundDistance = 0.4f; // we project a sphere on the ground to check if there are any collisions - if so we are grounded
    Vector3 velocity;
    bool isGrounded;

    public GameObject aGuitar;
    public AudioSource aGuitarSource;
    public GameObject eGuitar;
    public AudioSource eGuitarSource;
    public GameObject bass;
    public AudioSource bassSource;
    public GameObject mic;
    public AudioSource micSource;

    public AudioSource drumSource;


    void deactivateInstruments(){
        mic.SetActive(false);
        aGuitar.SetActive(false);
        eGuitar.SetActive(false);
        bass.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0){
            velocity.y = -2f; // small number that will force our player on the ground
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        // Create a direction we want to move 
        Vector3 move = transform.right * x + transform.forward * z;
        // Pass move with a speed that is framerate independent to controller
        controller.Move(move * speed * Time.deltaTime);

        // jumping
        if (Input.GetButtonDown("Jump") && isGrounded){
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        // apply gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // If user pressed Left click
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit  hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // hit an object
            if (Physics.Raycast(ray, out hit)) {
                // Object was Bass
                if (hit.transform.name == "Stand+BassGuitar" ){
                    Debug.Log("Clicked on Bass");
                    deactivateInstruments();
                    bass.SetActive(true);
                }
                // Object was Drums
                if (hit.transform.name == "BassDrum" ){
                    Debug.Log("Clicked on Drums");
                    deactivateInstruments();
                    drumSource.Play();
                }
                // Object was Acoustic Guitar
                if (hit.transform.name == "Stand+AcousticGuitar" ){
                    Debug.Log("Clicked on Acoustic Guitar");
                    deactivateInstruments();
                    aGuitar.SetActive(true);
                }
                // Object was Electric Guitar
                if (hit.transform.name == "Stand+ElectricGuitar" ){
                    Debug.Log("Clicked on Electric Guitar");
                    deactivateInstruments();
                    eGuitar.SetActive(true);
                }
                // Object was Mic
                if (hit.transform.name == "MicrophonewStand" ){
                    Debug.Log("Clicked on Mic");
                    deactivateInstruments();
                    mic.SetActive(true);
                }
                // Debug.Log(hit.transform.name);
            }
        }
        // If user pressed right click - play audio source
        if (Input.GetMouseButtonDown(1)){
            Debug.Log("play audio");
            // holding bass
            if(bass.activeSelf == true){
                bassSource.Play();
            }
            // holding aGuitar
            else if(aGuitar.activeSelf == true){
                aGuitarSource.Play();
            }
            // holding eGuitar
            else if(eGuitar.activeSelf == true){
                eGuitarSource.Play();
            }
            // holding bass
            else if(mic.activeSelf == true){
                micSource.Play();
            }
        }
    }
}
