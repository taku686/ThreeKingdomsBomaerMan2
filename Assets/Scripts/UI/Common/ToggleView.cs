using UI.Title;
using UnityEngine;

namespace UI.Common
{
    public class ToggleView : MonoBehaviour
    {
        [SerializeField] private ToggleElement[] toggleElements;

        public ToggleElement[] ToggleElements => toggleElements;

        public void ApplyView(CharacterSelectRepository.OrderType orderType)
        {
            foreach (var element in toggleElements)
            {
                element.SetActive(element.OrderType == orderType);
            }
        }
    }
}