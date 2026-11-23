using UnityEngine;

// Purpose: Keep track of Player's health. Will change the Gamestate to "Lose" if playerHealth < 0
public class Health : MonoBehaviour
{
    [SerializeField] private float playerHealth = 100f;
    [SerializeField] private float damage = 10f;

    public void Heal(int healAmount)
    {
        playerHealth += healAmount;
        print(playerHealth);
    }
    
    public void TakeDamage()
    {
        playerHealth -= damage;
        print(playerHealth);

        CheckIfPlayerDead();
    }

    private void CheckIfPlayerDead()
    {
        if (playerHealth <= 0)
        {
            UpdateGameStateToLose();
        }
    }

    private void UpdateGameStateToLose()
    {
        GameManager.Instance.UpdateGameState(GameState.Lose);
    }
}
