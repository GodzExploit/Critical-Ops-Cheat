namespace UnityGameObject
{
    using UnityEngine;

    public class Loader : MonoBehaviour
    {
        public static GameObject cheatObj = new GameObject();

        public static void Load()
        {
            cheatObj.AddComponent<Cheat>();
            UnityEngine.Object.DontDestroyOnLoad(cheatObj);
        }
    }
}
