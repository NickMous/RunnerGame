using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator playerAnim;
    private GameManager gameManager;
    private Rigidbody playerRb;
    private float horizontalInput;
    private static readonly int DeathB = Animator.StringToHash("Death_b");
    private static readonly int DeathTypeINT = Animator.StringToHash("DeathType_int");
    private static readonly int JumpTrig = Animator.StringToHash("Jump_trig");
    private static readonly int SpeedF = Animator.StringToHash("Speed_f");
    public ParticleSystem dirtParticle;
    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;
    public bool isOnGround = true;
    public float gravityModifier = 10;
    public float jumpForce = 2000;
    public float moveForce = 10;
    public float screenEdge = 8;

    // Start is called before the first frame update
    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!gameManager.isGameActive) return;
        horizontalInput = Input.GetAxis("Horizontal");

        // block movement when the player reaches the edge of the screen
        if ((transform.position.x < -screenEdge && horizontalInput < 0) ||
            (transform.position.x > screenEdge && horizontalInput > 0))
        {
            horizontalInput = 0;
        }

        // store the movement in a variable for an efficient calculation
        float movement = Time.deltaTime * moveForce * horizontalInput;
        transform.Translate(Vector3.right * movement);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && gameManager.isGameActive)
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            dirtParticle.Stop();
            explosionParticle.Play();
            gameManager.GameOver();
            playerAnim.SetBool(DeathB, true);
            playerAnim.SetInteger(DeathTypeINT, 1);
            playerAnim.SetFloat(SpeedF, 0);
        }
        else if (collision.gameObject.CompareTag("Coins"))
        {
            fireworksParticle.Play();
            Destroy(collision.gameObject);
            gameManager.UpdateCoins();
        }
    }

    public void StartRunning()
    {
        playerAnim.SetFloat(SpeedF, 1.0f);
    }

    // Reset the gravity when the player is disabled or the scene is reloaded
    private void OnDisable()
    {
        Physics.gravity /= gravityModifier;
    }

    private void Jump()
    {
        if (!isOnGround || !gameManager.isGameActive) return;
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isOnGround = false;
        dirtParticle.Stop();
        playerAnim.SetTrigger(JumpTrig);
    }
}