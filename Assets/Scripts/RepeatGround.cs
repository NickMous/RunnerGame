using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatGround : MonoBehaviour
{
    private float repeatWidth;
    public Vector3 startPos;
    
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.z / 2;
        
        // The ground is scaled by the z axis, so we need to multiply the repeat width by the scale of the z axis
        repeatWidth *= transform.localScale.z;
    }

    // Update is called once per frame
    void Update()
    {
        // If the background moves back far enough, move it back to the start position
        if (transform.position.z < startPos.z - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
