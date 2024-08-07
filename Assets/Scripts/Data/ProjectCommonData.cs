using UnityEngine;

public class ProjectCommonData : MonoBehaviour
{
    public static ProjectCommonData Instance;
    public Color fadeOutColor;
    public Color fadeInColor;
    public int maskTextureIndex;
    public bool isSceneTransition;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}