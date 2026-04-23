using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] CheckpointManager checkpointManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.CompareTag("Player")) return;

        if(checkpointManager != null)
        {
            checkpointManager.SetCheckpoint(transform);
            Debug.Log("Checkpoint Activated!");
        }
    }
}
