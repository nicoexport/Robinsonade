using UnityEngine;

namespace Architecture
{
   public abstract class PersistantSingleton<T> : Singleton<T> where T : MonoBehaviour
   {
      protected override void Awake()
      {
         base.Awake();
         DontDestroyOnLoad(gameObject);
      }
   }
}
