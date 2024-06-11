using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackwards : MonoBehaviour
{
    private const float Speed = 30.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // store the movement in a variable for an efficient calculation
        float movement = Time.deltaTime * Speed;
        transform.Translate(Vector3.back * movement);
    }
}
