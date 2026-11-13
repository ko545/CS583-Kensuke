using UnityEngine;

// Purpose: Update Game State to Win if Player gets to the exit 
public class ExitTouched : MonoBehaviour
{
    private string exitTag = "Exit";
    private void OnTriggerEnter(Collider other)
    {
        bool collidedWithExit = other.CompareTag(exitTag);
        if (collidedWithExit)
        {
             //print("win state");
            UpdateGameStateToWin();
        }
    }

    private void UpdateGameStateToWin()
    {
        GameManager.Instance.UpdateGameState(GameState.Win);
    }
}