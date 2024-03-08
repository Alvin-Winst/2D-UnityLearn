using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupActive : MonoBehaviour
{
    [SerializeField] private GameObject scoreboard;

    void OnEnable()
    {
        scoreboard.SetActive(true);
    }
}
