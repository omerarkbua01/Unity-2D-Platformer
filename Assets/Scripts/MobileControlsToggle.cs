using UnityEngine;

public class MobileControlsToggle : MonoBehaviour
{
      void Start()
    {
        #if UNITY_ANDROID || UNITY_IOS
            gameObject.SetActive(true);
        #else
            gameObject.SetActive(false);
        #endif
    }
}
