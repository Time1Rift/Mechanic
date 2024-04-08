using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonReboot : AbstractButton
{
    public ButtonReboot(Button button, AudioSource audioSource) : base(button, audioSource) { }

    protected override void Activate()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}