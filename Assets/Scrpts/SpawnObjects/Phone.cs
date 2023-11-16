using System;

public class Phone : SpawnObject
{
    public static event Action OnDelete;

    private void OnDestroy()
    {
        OnDelete?.Invoke();
    }
}