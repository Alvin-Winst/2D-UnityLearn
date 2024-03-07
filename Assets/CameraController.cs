using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;

    private bool initial = false;

    // Update is called once per frame
    private void Update()
    {
        float posX, posY = 0;
        if (initial == true)
        {
            posX = player.position.x;
            posY = player.position.y + (float)0.05;
        }
        else if(initial == false && player.position.y > -0.04)
        {
            posX = player.position.x;
            posY = 0;
        }
        else
        {
            posX = player.position.x;
            posY = 0;
            initial = true;
        }

        transform.position = new Vector3(posX, posY, transform.position.z);
    }
}
