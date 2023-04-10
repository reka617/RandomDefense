using UnityEngine;

namespace Utils
{
    public class GenericSingleton<T> where T : MonoBehaviour
    {
        private static T _instance;
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject temp = new GameObject();
                    _instance = temp.AddComponent<T>();
                    Object.DontDestroyOnLoad(temp);
                }
                return _instance;
            }
        }
    }
}
