using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityGameObject
{
    using UnityEngine;

    class Radar : Feature
    {
        private float spotDelta;

        private void OnGUI()
        {
            if (featureEnabled)
            {
                // Stop if there is no GameManager instance
                if (GameManager.instance)
                {
                    // Update our spot time
                    spotDelta += Time.deltaTime;

                    GUI.Button(new Rect(800, 200, 150, 20), GameManager.instance.LocalCharacter.gameObject.layer.ToString());

                    // Loop through every live character in the game
                    foreach (Character character in GameManager.instance.AllCharacters)
                    {
                        // Update radar every second
                        if (spotDelta > 0.5f)
                        {
                            character.Spotted = true;
                            GameManager.instance.SpotCharacter(character);

                            // Reset our spot time
                            spotDelta = 0.0f;
                        }
                    }
                }
            }
        }
    }
}
