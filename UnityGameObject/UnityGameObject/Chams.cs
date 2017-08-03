using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityGameObject
{
    using UnityEngine;

    class Chams : Feature
    {
        private Texture2D pixel;
        private Camera chamCam;

        void Start()
        {
            pixel = new Texture2D(1, 1);
            pixel.SetPixel(0, 0, Color.black);
            pixel.wrapMode = TextureWrapMode.Repeat;
            pixel.Apply();


            chamCam = gameObject.AddComponent<Camera>();
            chamCam.depth = -999;
        }

        private void Update()
        {
            if (chamCam.transform.parent && GameManager.instance.LocalCharacter)
            {
                chamCam.transform.localEulerAngles = new Vector3(GameManager.instance.LocalCharacter.RecoilY, GameManager.instance.LocalCharacter.RecoilX, 0);
            }
        }

        void OnGUI()
        {
            // Ensure that our feature is enabled, and there is a game running
            if (featureEnabled && (GameManager.instance || CameraManager.instance))
            {
                if (!chamCam.transform.parent)
                {
                    if (CameraManager.instance && CameraManager.instance.ActiveCamera)
                    {
                        chamCam.transform.parent = CameraManager.instance.ActiveCamera.transform;
                        chamCam.CopyFrom(CameraManager.instance.ActiveCamera);
                        chamCam.clearFlags = CameraClearFlags.Depth;
                        chamCam.depth += 1;
                        chamCam.cullingMask = 1 << 12;
                        chamCam.fieldOfView = CameraManager.instance.FieldOfView;
                    }
                }
                else
                {
                    chamCam.fieldOfView = CameraManager.instance.FieldOfView;
                }

                // Loop through every live character in the game
                foreach (Character character in GameManager.instance.AllCharacters)
                {
                    // Ignore the local character
                    if (character.ID == GameManager.instance.LocalID) { continue; }

                    // Ignore character if they are not in front of our camera
                    if (Vector3.Dot(CameraManager.instance.ActiveCamera.transform.forward, character.Position - CameraManager.instance.ActiveCamera.transform.position) <= 0) { continue; }

                    // Get GUI position of player
                    Vector3 pos = CameraManager.instance.ActiveCamera.WorldToScreenPoint(character.Position);
                    pos.y = Screen.height - pos.y; // Fix reversed y-axis

                    // Set player label color based on team
                    if (character.Player.Team == CriticalOps.Team.CT)
                        GUI.color = Color.blue;
                    else
                        GUI.color = Color.red;

                    // Display player label
                    GUI.Label(new Rect(pos.x, pos.y, 300, 80), character.Player.UserName + "(" + character.Health + ")");

                    // Reset GUI color
                    GUI.color = Color.white;

                    int i = 0;
                    foreach (CharacterBodyPart bodypart in character.BodyParts)
                    {
                        Vector3 testpos = CameraManager.instance.ActiveCamera.WorldToScreenPoint(bodypart.transform.position);
                        testpos.y = Screen.height - testpos.y; // Fix reversed y-axis

                        pixel.SetPixel(0, 0, Color.white);
                        pixel.Apply();
                        GUI.DrawTexture(new Rect(testpos.x, testpos.y, 2, 2), pixel);

                        GUI.Label(new Rect(testpos.x, testpos.y, 20, 50), (i++).ToString());
                    }

                    // Get distance ratio to player
                    float distance = 1.0f / Vector3.Distance(character.Position, CameraManager.instance.ActiveCamera.transform.position);

                    // Display ESP box around player (using "sharpcorners" GUIStyle)
                    Rect rect = new Rect(pos.x - (250f * distance), pos.y - (1300f * distance), 500f * distance, 1300f * distance);

                    // top - left - right - bottom
                    pixel.SetPixel(0, 0, Color.black);
                    pixel.Apply();
                    GUI.DrawTexture(new Rect(rect.xMin, rect.yMin, rect.width, 2), pixel);
                    GUI.DrawTexture(new Rect(rect.xMin, rect.yMin, 2, rect.height), pixel);
                    GUI.DrawTexture(new Rect(rect.xMax - 2, rect.yMin, 2, rect.height), pixel);
                    GUI.DrawTexture(new Rect(rect.xMin, rect.yMax - 2, rect.width, 2), pixel);
                }
            }
        }
    }
}
