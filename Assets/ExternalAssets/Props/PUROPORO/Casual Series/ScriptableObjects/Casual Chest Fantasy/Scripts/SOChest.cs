using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PUROPORO
{
    [CreateAssetMenu(fileName = "Chest ", menuName = "PUROPORO/Casual/Chest")]
    [System.Serializable]
    public class SOChest : ScriptableObject
    {
        [SerializeField] private Mesh m_ChestMesh;
        [SerializeField] private Texture m_ChestTexture;
        [SerializeField] private Texture m_ChestMaskMap;
        [SerializeField] private int m_AmountOfCards;

        [Header("Materials")]
        [SerializeField] private Material m_URPUnlit;
        [SerializeField] private Material m_URPOnlySpec;
        [SerializeField] private Material m_URPDiffSpec;
        [SerializeField] private Material m_BuiltInUnlit;
        [SerializeField] private Material m_BuiltInOnlySpec;
        [SerializeField] private Material m_BuiltInDiffSpec;

        public Mesh GetMesh()
        {
            return m_ChestMesh;
        }

        public Texture GetBaseTexture()
        {
            return m_ChestTexture;
        }

        public Texture GetMaskMap()
        {
            return m_ChestMaskMap;
        }

        public int GetAmountOfCards()
        {
            return m_AmountOfCards;
        }

        public Material GetMaterial(MaterialType mType, bool b)
        {
            if (b && mType == MaterialType.Unlit)
                return m_URPUnlit;

            if (b && mType == MaterialType.OnlySpecular)
                return m_URPOnlySpec;

            if (b && mType == MaterialType.DiffuseAndSpecular)
                return m_URPDiffSpec;

            if (mType == MaterialType.Unlit)
                return m_BuiltInUnlit;

            if (mType == MaterialType.OnlySpecular)
                return m_BuiltInOnlySpec;

            return m_BuiltInDiffSpec;
        }
    }
}
