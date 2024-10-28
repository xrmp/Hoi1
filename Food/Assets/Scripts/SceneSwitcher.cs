using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void LoadNextScene()
    {
        // Получаем текущую активную сцену
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Загружаем следующую сцену
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
