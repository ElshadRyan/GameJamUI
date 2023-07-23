using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{

    private bool isGameOver;
    private void Update()
    {
        GameOver();   
    }

    public void GameOver()
    {
        if(isGameOver)
        {
            Debug.Log("GameOver");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isGameOver = true;
        }
    }
}
