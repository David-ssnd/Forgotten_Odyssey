using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update() {
        if (GameData.health == 0) {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }
    private void Die() {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        SceneManager.LoadScene("DeathScreen"); 
    }
    private void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
