using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityGameObject
{
    using UnityEngine;

    class Menu : Feature
    {
        private GUIStyle sharpcorners;
        private Texture2D texture;

        void Start()
        {
            texture = new Texture2D(1, 1);
            texture.SetPixel(1, 1, new Color(0, 0, 0, 0.2f));
            texture.wrapMode = TextureWrapMode.Repeat;
            texture.Apply();

            sharpcorners = new GUIStyle();
            sharpcorners.normal.background = texture;
        }

        bool radar, wall;

        void OnGUI()
        {
            // Reset GUI color
            GUI.color = Color.white;

            // If menu is on
            if (featureEnabled)
            {
                // Add button to unlock skins
                // if (GUI.Button(new Rect(800, 200, 150, 20), "Unlock all skins!"))
                //     UnlockSkins();

                // Add toggle buttons to enable/disable hacks
                // radar = GUI.Toggle(new Rect(800, 220, 100, 20), radar, "Radar hack");
                // wall = GUI.Toggle(new Rect(800, 240, 100, 20), wall, "ESP boxes");
            }
        }
    }
}
