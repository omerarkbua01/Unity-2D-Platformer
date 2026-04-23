using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public Transform CurrentCheckpoint {get;private set;}

    public void SetCheckpoint(Transform checkpoint)
    {
        CurrentCheckpoint = checkpoint;
    }
    public bool HasCheckpoint()
    {
        return CurrentCheckpoint != null;
    }
}
