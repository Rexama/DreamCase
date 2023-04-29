using UnityEngine.SceneManagement;

namespace _Code.Buttons
{
    public class ExitButton : ButtonObject
    {
        protected override void OnButtonPressed()
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}