using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

namespace DemoImage_FlatMagicBundle1
{
    public class SetDemoImage : MonoBehaviour
    {
        public Image[] DemoImage = new Image[51];

        // Start is called before the first frame update
        void Start()
        {
            DemoImage = GetComponentsInChildren<Image>();
            for (int i = 0; i < 5; i++) // DemoImage[0] is background
            {
				for (int j = 1; j < 11; j++) // DemoImage[0] is background
				{ 
                    switch (i){
					case 0:
						DemoImage[i*10+j].sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Flat Magic Spell Icons Mix Bundle1/Icons/Holy/Flat Magic Spell Icons Mix Bundle1_Holy_" + j + ".png");
						break;
					case 1:
						DemoImage[i*10+j].sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Flat Magic Spell Icons Mix Bundle1/Icons/Alchemy/Flat Magic Spell Icons Mix Bundle1_Alchemy_" + j + ".png");
						break;
					case 2:
						DemoImage[i*10+j].sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Flat Magic Spell Icons Mix Bundle1/Icons/Fire/Flat Magic Spell Icons Mix Bundle1_Fire_" + j + ".png");
						break;
					case 3:
						DemoImage[i*10+j].sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Flat Magic Spell Icons Mix Bundle1/Icons/Arcane/Flat Magic Spell Icons Mix Bundle1_Arcane_" + j + ".png");
						break;
					case 4:
						DemoImage[i*10+j].sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Flat Magic Spell Icons Mix Bundle1/Icons/Nature/Flat Magic Spell Icons Mix Bundle1_Nature_" + j + ".png");
						break;				
					}

				}	
			}
        }
    }
}