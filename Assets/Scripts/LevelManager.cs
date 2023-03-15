using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    public void RestartLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Restart Level");
    }
    public void NextLevel(){
        Debug.Log("Number of Scene " + SceneManager.sceneCountInBuildSettings);
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;    
        if (nextLevel > SceneManager.sceneCountInBuildSettings- 1){
            nextLevel = 0;
        }
        Debug.Log("Next Level");
        SceneManager.LoadScene(nextLevel);
    }
}
