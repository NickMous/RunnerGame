using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private float repeatWidth;
    public Vector3 startPos;

    // Start is called before the first frame update
    private void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.z / 2;

        // The ground is scaled by the z axis, so we need to multiply the repeat width by the scale of the z axis
        repeatWidth *= transform.localScale.z;
    }

    // Update is called once per frame
    private void Update()
    {
        // If the background moves back far enough, move it back to the start position
        if (transform.position.z < startPos.z - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}