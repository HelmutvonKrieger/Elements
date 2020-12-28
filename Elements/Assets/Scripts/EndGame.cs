using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public void PressButton()
    {
        Invoke("FinishGame", 1);
    }

    private void FinishGame()
    {
        Application.Quit();
    }
}
