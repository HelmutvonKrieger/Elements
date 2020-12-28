using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndScreen : MonoBehaviour
{
    private int previousLevel;
    private int nextLevel;

    // Start is called before the first frame update
    void Start()
    {
        previousLevel = MasterControl.Instance.CurrentLevelIndex;
        nextLevel = MasterControl.Instance.NextLevelIndex;
    }

    public void ButtonPressed()
    {
        Invoke("StartNextLevel", 1);
    }

    public void StartNextLevel() 
    {
        SceneManager.LoadScene(nextLevel);
    }

}
