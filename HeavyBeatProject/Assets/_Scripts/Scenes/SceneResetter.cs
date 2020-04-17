using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneResetter : MonoBehaviour {
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            ResetGame();
        }
    }

    private void ResetGame() {
        SceneManager.LoadSceneAsync("MainScene");
    }
}
