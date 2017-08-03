using System;
using System.Collections;
using System.Reflection;
using System.Security.Policy;

namespace UnityGameObject
{
    using UnityEngine;

    public class Cheat : MonoBehaviour
    {
        void Start()
        {
            Menu menu = AddFeature<Menu>(true);
            Chams chams = AddFeature<Chams>(true);
        }

        private T AddFeature<T>(bool enabled) where T : Feature
        {
            T feature = gameObject.AddComponent<T>();
            feature.featureEnabled = enabled;
            return feature;
        }

        /*void UnlockSkins()
        {
            // Stop if there is no PlayerDataManager instance
            if(!SingletonMonoBehaviour<PlayerDataManager>.instance) { return; }

            // Clear the current player's owned skins
            SingletonMonoBehaviour<PlayerDataManager>.instance.CurrentPlayerProfile.ownedWeaponSkins.Clear();

            // Loop through the skin list adding all of them
            for(int i = 0; i < 1000; ++i)
            {
                SingletonMonoBehaviour<PlayerDataManager>.instance.CurrentPlayerProfile.ownedWeaponSkins.Add(i);
            }
        }*/
    }
}
