using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class LevelButtonBehaviour : MonoBehaviour
{
    [SerializeField] private TMP_Text buttonText; 
    public string level;
    void Start(){
        Debug.Log(level);
        buttonText.text = level;
    }
    public void ChangeLevel(){
        SceneManager.LoadScene(level);
    }
}
