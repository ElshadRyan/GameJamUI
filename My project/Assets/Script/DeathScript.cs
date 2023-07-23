using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            SceneManager.LoadScene("YouLose");
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
