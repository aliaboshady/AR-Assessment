using UnityEngine;
using UnityEngine.SceneManagement;

public class WelcomeMenu : MonoBehaviour
{
    public void Play()
	{
		SceneManager.LoadScene(1);
	}
}
