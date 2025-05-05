using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuController : MonoBehaviour {
    public void OnStartClick() {
        // Load the game scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }

    public void OnExitClick() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Stop playing the scene in the editor
        #endif
        Application.Quit();
    }
}
