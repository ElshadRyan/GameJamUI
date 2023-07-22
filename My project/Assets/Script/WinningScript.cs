using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningScript : MonoBehaviour
{
    GameManager gm;
    private bool isWinning;

    private void Start()
    {
        gm = GameManager.Instance;
    }
    private void Update()
    {
        IsWinning();
    }

    private void IsWinning()
    {
        if(isWinning)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                gm.money += 70;
                Debug.Log(gm.money);
                Debug.Log("Winning");
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isWinning = true;
        }
    }
}
