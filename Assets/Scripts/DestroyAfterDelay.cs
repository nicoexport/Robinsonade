using System.Collections;
using UnityEngine;

public class DestroyAfterDelay : MonoBehaviour
{
   [SerializeField] private float _delayInSeconds;
   [SerializeField] private bool _onAwake;

   private void Awake()
   {
      if (_onAwake)
         StartCoroutine(destroyAfterTimeEnumerator(_delayInSeconds));
   }

   public void DestroyAfterSeconds()
   { 
      StartCoroutine(destroyAfterTimeEnumerator(_delayInSeconds));
   }
   
   public void DestroyAfterSeconds(float seconds)
   { 
      StartCoroutine(destroyAfterTimeEnumerator(seconds));
   }

   private IEnumerator destroyAfterTimeEnumerator(float timeInSeconds)
   {
      yield return new WaitForSeconds(timeInSeconds);
      Destroy(gameObject);
   }
}