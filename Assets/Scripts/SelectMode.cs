using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SelectMode : MonoBehaviour
{
    public GameObject playerAI;
    public GameObject selectPanel;

    private bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        Pause();
    }

// Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    private void Resume()
    {
        //deactivate pause menu and unfreeze game
        selectPanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    private void Pause()
    {
        //activate pause menu and freeze game
        selectPanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void SelectedPlayer()
    {
        
        playerAI.GetComponent<Player>().enabled = true;
        playerAI.GetComponent<NavMeshFollower>().enabled = false;
        playerAI.GetComponent<NavMeshAgent>().enabled = false;
        playerAI.GetComponent<WallFollower>().enabled = false;

        Resume();
    }

    public void SelectedNavMesh()
    {
        playerAI.GetComponent<Player>().enabled = false;
        playerAI.GetComponent<NavMeshFollower>().enabled = true;
        playerAI.GetComponent<NavMeshAgent>().enabled = true;
        playerAI.GetComponent<WallFollower>().enabled = false;

        Resume();
    }

    public void SelectedWallFollower()
    {
        playerAI.GetComponent<Player>().enabled = false;
        playerAI.GetComponent<NavMeshFollower>().enabled = false;
        playerAI.GetComponent<WallFollower>().enabled = true;

        Resume();
    }
}
