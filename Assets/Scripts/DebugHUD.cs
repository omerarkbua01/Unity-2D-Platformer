using UnityEngine;
using TMPro;

public class DebugHUD : MonoBehaviour
{
 [SerializeField] PlayerController2D player;
 [SerializeField] Rigidbody2D rb;
 [SerializeField] TMP_Text text;

    void Update()
    {
        if (player== null || rb == null || text == null) return;
        text.text=
        $"Grounded : {player.IsGrounded} \n " +
        $"VelX :  {rb.linearVelocity.x:F2} \n" +
        $" VelY :  {rb.linearVelocity.y:F2} \n";
    }
}
