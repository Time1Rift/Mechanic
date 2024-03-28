using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonReboot : ButtonAbstract
{
    public ButtonReboot(Button button) : base(button) { }

    protected override void OnButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}