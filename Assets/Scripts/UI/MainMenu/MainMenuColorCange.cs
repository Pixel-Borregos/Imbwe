using UnityEngine;

public class MainMenuColorCange : MonoBehaviour
{
    [SerializeField] Material mBlood;
    [SerializeField] Material mRain;
    [SerializeField] MeshRenderer mesh;
    [SerializeField] GameObject goRain;
    [SerializeField] GameObject goBlood;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ChangeToBlood", 18.5f);
    }

    private void ChangeToBlood()
    {
        RenderSettings.fog = false;
       
        mesh.material = mBlood;
        goRain.SetActive(false);
        goBlood.SetActive(true);
        Invoke("ChangeToWater", 11f);
    }
}
