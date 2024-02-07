using System.Collections;
using UnityEngine;

public class MainMenuScript : MonoBehaviour {
    public CanvasGroup settingsCanvas;

    public void OnPlayButton() {
        Debug.Log("play clicked");
    }

    public void OnSettingsButton() {
        Fade(true);
        Debug.Log("settings clicked");
    }

    public void OnResolutionChange() {
        Debug.Log("resolution picked");
    }

    public void OnSettingsSave() {
        Fade(false);
        Debug.Log("settings saved");
    }

    public void OnExitButton() {
        Application.Quit();
    }

    IEnumerator Fade(bool isFadingIn) {
        int denier = isFadingIn ? 1 : -1;

        for (float alpha = 1f; alpha >= 0; alpha += 0.1f * denier) {
            settingsCanvas.alpha = alpha;
            yield return null;
        }
    }
}
