using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PineappleCollected : MonoBehaviour
{
    private ItemCollector item;
    [SerializeField] private TMP_Text pineappleText;
    [SerializeField] private TMP_Text scoreText;
    private int itemCount;
    private int scoreCount;

    // Start is called before the first frame update
    void OnEnable()
    {
        item = FindObjectOfType<ItemCollector>();
        itemCount = item.pineapples;
        pineappleText.text = itemCount + "/7";
        scoreCount = (int)itemCount * 100 / 7;
        scoreText.text = scoreCount + "/100";
    }
}
