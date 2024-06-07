using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public AudioSource buttonAudioSource;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    //play sound and start coroutine to change scene after sound ends
        public void Play(string sceneName)
    {
        buttonAudioSource.Play();

        StartCoroutine(ChangeSceneAfterAudio(sceneName));
    }

    //coroutine to determine clip length
    private IEnumerator ChangeSceneAfterAudio(string sceneName)
    {
        // Wait until the audio clip has finished playing
        yield return new WaitForSeconds(buttonAudioSource.clip.length);

        // Change the scene
        ChangeScene(sceneName);
    }

    //change scene
    private void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

    }
    }
