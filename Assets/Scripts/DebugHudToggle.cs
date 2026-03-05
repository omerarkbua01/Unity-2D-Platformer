using UnityEngine;

public class DebugHudToggle : MonoBehaviour
{
   [SerializeField] GameObject debugHudRoot;
    void Start()
    {
        if(debugHudRoot!=null)
           debugHudRoot.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            if(debugHudRoot==null) return;
               debugHudRoot.SetActive(!debugHudRoot.activeSelf);
        }
    }
}
