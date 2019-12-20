using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // bool gameHasEnded = false;

    // public void EndGame()
    // {
    //     if(gameHasEnded == false)
    //     {
    //         gameHasEnded = true;
    //         Debug.Log("Game over!");
    //         Invoke("Restart", 1f);
    //     }
    // }

    // if ( Input.GetKey(KeyCode.T) )
    // {
    //     print("Pressed T key");
    //     FindObjectOfType<GameManager>().EndGame();
    // }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
