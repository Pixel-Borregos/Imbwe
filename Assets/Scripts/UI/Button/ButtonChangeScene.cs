using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonChangeScene : MonoBehaviour
{
    [SerializeField] EnumGameScene scene;
    public void ChangeScene()
    {
        SceneManager.LoadScene(scene.ToString());
    }
}
