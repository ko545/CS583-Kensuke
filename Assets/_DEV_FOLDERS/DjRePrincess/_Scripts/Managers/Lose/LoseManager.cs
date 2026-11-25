using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// Purpose: If Game State is Lose, then roll the LoseSequence()
// no audio yet
public class LoseManager : MonoBehaviour
{
    private Movement movementScript;
    //[SerializeField] private AudioSource loseSoundSource;

    private void Start()
    {
        //loseSoundSource = GetComponent<AudioSource>();
        movementScript = GetComponent<Movement>();
    }
    private void GameManagerOnOnGameStateChanged(GameState state)
    {
        // script (Player) Health will handle changing the gamestate to lose
        if (state == GameState.Lose)
        {
            StartCoroutine(LoseSequence());
        }
    }

    private IEnumerator LoseSequence()
    {
        // LoseScreen.SetActive(true);
        DisablePlayerMovement();
        print("player died");
        //PlayLoseSound();

        yield return new WaitForSeconds(1);

        ReloadLevel();
    }

    private void DisablePlayerMovement()
    {
        movementScript.enabled = false;
    }

    //private void PlayLoseSound()
    //{
    //    if (loseSoundSource.isPlaying)
    //    {
    //        return;
    //    }
    //    loseSoundSource.Play();

    //    // do i need to stop it ?
    //}

    private void ReloadLevel()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    // ------------------- default 

    private void Awake()
    {
        // subcribe to game state changed event 
        GameManager.OnGameStateChanged += GameManagerOnOnGameStateChanged;
    }

    private void OnDestroy()
    {
        // unsubcribe to event when this class gets destroyed 
        GameManager.OnGameStateChanged -= GameManagerOnOnGameStateChanged;
    }
}