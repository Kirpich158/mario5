using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {
    public CanvasGroup settingsCanvasGroup;

    public void OnPlayButton() {
        SceneManager.LoadScene("Lvl1");
    }

    public void OnSettingsButton() {
        settingsCanvasGroup.gameObject.SetActive(true);
        // StartCoroutine(Fade(true));
    }

    public void OnResolutionChange() {
        Debug.Log("resolution picked");
    }

    public void OnSettingsSave() {
        settingsCanvasGroup.gameObject.SetActive(false);
        // StartCoroutine(Fade(false));
    }

    public void OnExitButton() {
        Application.Quit();
    }

    IEnumerator Fade(bool isFadingIn) {
        int denier = isFadingIn ? 1 : -1;

        for (float alpha = 1f; alpha >= 0; alpha += 0.1f * denier) {
            settingsCanvasGroup.alpha = alpha;
            yield return null;
        }
    }
}
