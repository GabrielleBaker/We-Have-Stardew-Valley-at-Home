using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniMenu : MonoBehaviour
{
    public GameObject miniMenu;  // Reference to the mini menu panel

    // Start is called before the first frame update
    void Start()
    {
        if (miniMenu != null)
        {
            miniMenu.SetActive(false);  // Ensure the mini menu is initially inactive
        }
    }

    // Method to call the mini menu
   /* public void ShowMiniMenu()
    {
        if (miniMenu != null)
        {
            miniMenu.SetActive(true);  // Set the mini menu to active
        }
        
    }*/

    // Method to toggle the mini menu
    public void ToggleMiniMenu()
    {
        if (miniMenu != null)
        {
            // Toggle the active state of the mini menu
            miniMenu.SetActive(!miniMenu.activeSelf);
        }
    }

    //change scene
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

    }

    //quit game
    public void Quit()
    {
        Application.Quit();
    }

    //

}
