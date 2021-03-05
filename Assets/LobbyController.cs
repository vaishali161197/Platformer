using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LobbyController : MonoBehaviour
{
    public AudioSource SoundEffects;

    public GameObject levelSelection;
   public void PlayGame()
    {
        SoundEffects.clip = FindObjectOfType<SoundManager>().Sounds[0];
        SoundEffects.Play();
        levelSelection.SetActive(true);
    }
}
