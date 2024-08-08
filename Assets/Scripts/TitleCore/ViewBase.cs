using UnityEngine;

public class ViewBase : MonoBehaviour
{
    [SerializeField] private UI.Title.TitleCore.State state;

    public UI.Title.TitleCore.State State => state;
}