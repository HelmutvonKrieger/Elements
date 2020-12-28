using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        // Index 1 is the first game level
        MasterControl.Instance.NextLevelIndex = 1;
    }

    public void PressButton()
    {
        Invoke("StartFirstLevel", 1);
    }

    public void StartFirstLevel()
    {
        SceneManager.LoadScene(MasterControl.Instance.NextLevelIndex);
    }
}
