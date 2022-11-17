using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class WorldManager : MonoBehaviour
{
    
    private static WorldManager _instance;
    private static bool firstScene = true;
    private string exitScene;
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
        exitScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(
            transitionInformation.targetScene.ToString()
        );
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {   
        if (SceneManager.GetActiveScene().name == "MainMenu")
            return;

        Transform player = PlayerSingleton.GetInstance().gameObject.transform;
        Transform camera = CameraSingleton.GetInstance().gameObject.transform;
        Transform inai = InaiSingleton.GetInstance().gameObject.transform;
        Transform sceneCenter = GameObject.Find("SceneCenter").transform;
        Transform akriLook = player.GetChild(5);
        if (firstScene)
        {
            firstScene = false;
            exitScene = "MainMenu";

            inai.GetComponent<NavMeshAgent>().enabled = true;
            inai.GetComponent<StateMachine>().enabled = true;
            UIManagerSingleton.GetInstance().ChangeGameModeUI(0);

            camera.GetChild(0).gameObject.SetActive(true);
            camera.GetChild(1).gameObject.SetActive(true);

            player.GetComponent<StateMachine>().enabled = true;
        }

        Transform entryPoint = GameObject.Find("EntryContainer").transform.Find(exitScene).transform;


        player.position = entryPoint.position;
        player.transform.LookAt(sceneCenter.transform);

        
        camera.position = player.transform.position - player.transform.forward * 1.4f + new Vector3(0,1.5f,0);
        camera.LookAt(akriLook);

        inai.GetComponent<NavMeshAgent>().enabled = false;
        inai.GetComponent<StateMachine>().enabled = false;
        inai.position = player.position;
        inai.GetComponent<NavMeshAgent>().enabled = true;
        inai.GetComponent<StateMachine>().enabled = true;
    }
}
