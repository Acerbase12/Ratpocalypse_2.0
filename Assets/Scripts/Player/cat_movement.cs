using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;
using Unity.VisualScripting;
using System;

public class cat_movement : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 movement;
    private Rigidbody2D rb;
    public float speed = 2;
    private Animator playerAnimator;
    public GameObject punchHitbox;
    Collider2D punchCollider;
    //public GameObject hitBox;

    public bool climb { get; set; }
    private float dirX, dirY;
    // private bool isDead = false;
    // private bool isOver = false;
    public GameManagerScript gameManager;
    [SerializeField] AudioSource walkingSFX;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        punchCollider = punchHitbox.GetComponent<Collider2D>();
    }

    private void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();

        if (movement.x != 0 || movement.y != 0)
        {
            if (!walkingSFX.isPlaying)
            {
                walkingSFX.Play();
            }

            playerAnimator.SetFloat("xDir", movement.x);
            playerAnimator.SetFloat("yDir", movement.y);
            playerAnimator.SetBool("isWalking", true);

        }
        else
        {
            walkingSFX.Stop();
            playerAnimator.SetBool("isWalking", false);
        }


    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        //SetAnima();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            climb = true;
        }
        else if (collision.gameObject.CompareTag("NextScene"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    // void OnAttack()
    // {
    //     playerAnimator.SetTrigger("isAttacking");
    // }

    // public void SetAnima()
    // {
    //     if ((updater.playerHp <= 0f) && !isDead)
    //     {
    //         isDead = true;
    //         playerAnimator.SetTrigger("isDead");
    //         gameManager.gameOver();
    //         Invoke("GameOverAnimation", 1);
    //     }
    // }

    // public void GameOverAnimation()
    // {
    //     if (isDead && !isOver)
    //     {
    //         isDead = false;
    //         isOver = true;
    //         playerAnimator.SetTrigger("isOver");
    //     }
    // }
}
