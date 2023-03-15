using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class LevelSelectionButton : MonoBehaviour
{
    [SerializeField] private GameObject button;
    void Start(){
        AddLevelButton();
    }
    void AddLevelButton(){
        for(int i = 0; i < SceneManager.sceneCountInBuildSettings- 1; i++){
            var levelButton = Instantiate(button, transform);
            levelButton.transform.GetComponent<LevelButtonBehaviour>().level = "Level" + (i+1).ToString();
        }
    }
}
