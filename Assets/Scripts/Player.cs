using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class Player : MonoBehaviour
{
    public float jumpForce;
    private Rigidbody2D rb;

    private bool isGrounded = false;
    private Animator animator;
    public TextMeshProUGUI scoreText;
    private int score;
    public AudioClip jumpClip;
    public AudioClip dieClip;
    public AudioClip landClip;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
            rb.AddForce(UnityEngine.Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            AudioManager.instance.PlaySFX(jumpClip);
        }
        if (isGrounded)
        {
            animator.Play("Player_Run");
        }
        else
        {
        animator.Play("Player_Jump");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Damage"))
        {
        AudioManager.instance.PlaySFX(dieClip);
        Invoke("WaitForSceneLoad", dieClip.length);
        // UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
        }
        else
        {
        AudioManager.instance.PlaySFX(landClip);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
    if (collision.gameObject.CompareTag("Damage"))
    {
    score++;
    scoreText.text = score.ToString();
    }
    }
    void WaitForSceneLoad()
    {
    UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }
}

