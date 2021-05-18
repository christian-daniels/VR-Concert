using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform leftEye;

    public float Speed = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xAxisValue = Input.GetAxis("Horizontal") * Speed;
        float zAxisValue = Input.GetAxis("Vertical") * Speed;
 
        transform.position = new Vector3(transform.position.x + xAxisValue, transform.position.y, transform.position.z + zAxisValue);
        leftEye.position = new Vector3(leftEye.position.x + xAxisValue, leftEye.position.y, leftEye.position.z + zAxisValue);
    
    }
}
