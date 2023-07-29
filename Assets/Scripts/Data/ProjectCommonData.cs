using UnityEngine;

public class ProjectCommonData : MonoBehaviour
{
    public static ProjectCommonData Instance;
    public Color fadeOutColor;
    public Color fadeInColor;
    public int maskTextureIndex;
    public bool isInitialize;
    public bool isSceneTransition;
    public bool isResultScene;
    public bool isNewRecord;
    public int score;
    public int selectGameIndex;

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