using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    private AudioSource victorySFX;
    private Rigidbody2D rb;
    private bool levelCompleted = false;

    [SerializeField] private GameObject scorePopup;

    // Start is called before the first frame update
    private void Start()
    {
        victorySFX = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            victorySFX.Play();
            levelCompleted = true;
            rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Static;
            CompleteLevel();
        }
    }

    private void CompleteLevel()
    {
        scorePopup.SetActive(true);
    }
}
