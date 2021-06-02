using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRHeight : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)){
            transform.position = transform.position + new Vector3(0.0f, 0.3f, 0.0f);
        }
        else if(Input.GetKeyDown(KeyCode.CapsLock)){
            transform.position = transform.position + new Vector3(0.0f, -0.3f, 0.0f); 
        }
    }
}
