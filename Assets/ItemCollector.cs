using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    [HideInInspector] public int pineapples = 0;
    [SerializeField] private TMP_Text pineapplesText;
    [SerializeField] private AudioSource collectSFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pineapple"))
        {
            collectSFX.Play();
            Destroy(collision.gameObject);
            pineapples++;
            pineapplesText.text = "Pineapples: " + pineapples;
        }
    }
}
