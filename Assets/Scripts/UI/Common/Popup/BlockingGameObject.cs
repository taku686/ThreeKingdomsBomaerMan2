using UnityEngine;

public class BlockingGameObject : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(false);
    }
}
