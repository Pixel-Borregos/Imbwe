using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldManager : MonoBehaviour
{
    
    private static WorldManager _instance;
    private static bool firstScene = true;
    private static SceneTransitionInfo sceneInfo;
    public static WorldManager GetInstance()
    {
        if(_instance == null)
        {
            throw new System.NullReferenceException("You are trying to access a nonexistent World Manager");
        }
        return _instance;
    }

    private void Awake()
    {
        if( _instance != null && _instance != this)
        {
            Debug.LogWarning("There is already an instance of World Manager in the scene ");
            Destroy(GameObject.Find("World Manager"));
            Destroy(this);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void HandleSceneChange(SceneTransitionInfo transitionInformation)
    {
        SceneManager.LoadScene(
            transitionInformation.targetScene.ToString()
        );
       sceneInfo = transitionInformation;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (firstScene)
        {
            firstScene = false;
            return;
        }

        Transform entryPoint = GameObject.Find("EntryContainer").transform.GetChild(sceneInfo.entryIndex);
        Transform player = PlayerSingleton.GetInstance().gameObject.transform;
        Transform camera = CameraSingleton.GetInstance().gameObject.transform;
        Transform inai = InaiSingleton.GetInstance().gameObject.transform;

        player.position = entryPoint.position;
        player.rotation = entryPoint.rotation;

        camera.LookAt(player.gameObject.transform);
        camera.position = player.transform.position - player.transform.right * 1.3f + new Vector3(0,0.8f,0);

        inai.position = player.transform.position - player.transform.right * 1.4f;


    }
}
