using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BrickImpactBehaviour: MonoBehaviour
{
    [SerializeField] private LayerMask brickLayer;
    [SerializeField] private LayerMask finishLayer;
    [SerializeField] private float brickHeight;
    [SerializeField] private GameObject brickMesh;
    [SerializeField] private GameObject brickDrop;
    [SerializeField] private float speed;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private Animator animator;
    private Player player;
    private int brickNum;
    private List<GameObject> bricks;

    // Start is called before the first frame update
    void Start()
    {
        bricks = new List<GameObject>();
        brickNum = 0;
        uiManager.UpdateScore(brickNum);
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        TakeBrick(); 
        DropBrick();
        ClearBrick();
    }


    void TakeBrick()
    {
        RaycastHit brick;
        if (Physics.Raycast(transform.position + Vector3.up, Vector3.down, out brick ,Mathf.Infinity, brickLayer)){
            if (brick.transform.gameObject.tag == "Brick"){
                brickNum = bricks.Count;
                brick.transform.gameObject.SetActive(false);
                transform.position += Vector3.up * brickHeight;
                var currentBrickMesh = Instantiate(brickMesh, new Vector3(transform.position.x, transform.position.y - (brickHeight * brickNum ) - brickHeight, transform.position.z), Quaternion.Euler(-90, 0, 0), transform);
                bricks.Add(currentBrickMesh);
                animator.SetBool("take_brick", true);
                uiManager.UpdateScore(bricks.Count);
            } else {
                animator.SetBool("take_brick", false);
            }
        }
   }
   void DropBrick(){
        RaycastHit brick;
        if (Physics.Raycast(transform.position + Vector3.up, Vector3.down, out brick ,Mathf.Infinity, brickLayer)){
            if(brick.transform.gameObject.tag == "DropBrick"){
                if (bricks.Count > 0){
                    Destroy(bricks[bricks.Count - 1]);
                    bricks.RemoveAt(bricks.Count - 1);
                    transform.position += Vector3.down * brickHeight;
                    Instantiate(brickDrop, new Vector3(brick.transform.position.x, 0, brick.transform.position.z), Quaternion.Euler(-90, 0, 0), brick.transform);
                    uiManager.UpdateScore(bricks.Count);
                }
            }
        }
   }
   void ClearBrick(){
        RaycastHit finish;
        if (Physics.Raycast(transform.position + Vector3.up, Vector3.down, out finish, Mathf.Infinity, brickLayer)){
            if(finish.transform.gameObject.tag == "Finish"){
                uiManager.ShowScore(bricks.Count);
                if (bricks.Count > PlayerPrefs.GetInt("Score")){
                    PlayerPrefs.SetInt("Score", bricks.Count);
                }

                uiManager.ShowHighScore(PlayerPrefs.GetInt("Score"));
                foreach (var brick in bricks){
                    Destroy(brick);
                }
                transform.position = new Vector3(transform.position.x, brickHeight, transform.position.z);
                Instantiate(brickDrop, new Vector3(finish.transform.position.x, 0, finish.transform.position.z), Quaternion.Euler(-90, 0, 0), finish.transform);
                bricks.Clear();
                uiManager.EndLevelPopUp();
                player.gameEnd = true;
            }
        }
   }
}
