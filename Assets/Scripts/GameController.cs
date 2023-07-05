using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int scoreAdd, levelGoal;

    public bool locked = false;

    void Update()
    {
        if (scoreAdd == levelGoal && locked == false) { 
           SceneManager.LoadScene(2, LoadSceneMode.Additive);
           locked = true;
        }
    }

    public void CloseScene()
    {
        SceneManager.UnloadSceneAsync(2);
    }
}
