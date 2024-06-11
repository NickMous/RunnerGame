using UnityEngine;

public class MoveBackwards : MonoBehaviour
{
    private GameManager gameManager;
    private const float Speed = 30.0f;
    public bool isFence;

    // Start is called before the first frame update
    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (gameManager.isGameActive)
        {
            float currentSpeed = Speed;
            if (gameManager.rampUpSpeed < Speed)
            {
                currentSpeed = gameManager.rampUpSpeed;
                gameManager.rampUpSpeed += Time.deltaTime * 15f;
            }
            
            // store the movement in a variable for an efficient calculation
            float movement = Time.deltaTime * currentSpeed;

            // we need to check the rotation of the object to move it in the right direction
            // we also account for weird rotation values that some prefabs have
            // fences are living their best life, so they move the opposite way
            switch (transform.rotation.y)
            {
                case > -10 and < 10 when isFence:
                    transform.Translate(Vector3.forward * movement);
                    break;
                case > -10 and < 10:
                    transform.Translate(Vector3.back * movement);
                    break;
                case > 170 and < 190:
                    transform.Translate(Vector3.forward * movement);
                    break;
                case > 80 and < 100 or > -280 and < -260:
                    transform.Translate(Vector3.right * movement);
                    break;
                case > 260 and < 280 or > -80 and < -100:
                    transform.Translate(Vector3.left * movement);
                    break;
            }
        }

        // If the object moves back far enough, destroy it
        if (transform.position.z < -15 && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}