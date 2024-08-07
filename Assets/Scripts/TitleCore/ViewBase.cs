using UI.Title;
using UnityEngine;

public class ViewBase : MonoBehaviour
{
    [SerializeField] private TitleCore.State state;

    public TitleCore.State State => state;
}