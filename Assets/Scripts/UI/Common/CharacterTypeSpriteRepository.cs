using UnityEngine;

namespace UI.Common
{
    public class CharacterTypeSpriteRepository : MonoBehaviour
    {
        [SerializeField] private Sprite[] _characterTypeSprites;
        [SerializeField] private Color[] _characterTypeColors;

        public (Sprite, Color) GetCharacterTypeData(int characterType)
        {
            return (_characterTypeSprites[characterType], _characterTypeColors[characterType]);
        }
    }
}