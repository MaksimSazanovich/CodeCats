using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnerObject : MonoBehaviour
{
    protected Vector3 screenBounds;
    public float TimeBetweenSpawn { get => timeBetweenSpawn; }
    [SerializeField] protected float timeBetweenSpawn;

    [SerializeField] protected GameObject spawnObject;

    public int MaxNmbersOfObjectsSpawned { get => maxNmbersOfObjectsSpawned; }
    [SerializeField] protected int maxNmbersOfObjectsSpawned;

    public int NumbersOfObjectsSpawned { get => numbersOfObjectsSpawned; }
    [SerializeField] protected int numbersOfObjectsSpawned;

    [SerializeField] protected UnityEvent OnFull;
    [SerializeField] protected UnityEvent OnNotFull;

    protected void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }
    protected void Update()
    {
        if (numbersOfObjectsSpawned == maxNmbersOfObjectsSpawned)
            OnFull.Invoke();
    }
    public void Spawn()
    {
        if (numbersOfObjectsSpawned < maxNmbersOfObjectsSpawned)
        {

            Instantiate(spawnObject, CalculateRandomPosition(), Quaternion.identity);
            numbersOfObjectsSpawned++;
        }
    }
    protected Vector3 CalculateRandomPosition()
    {
        return new Vector3(Random.Range(-screenBounds.x + 0.5f * LerpPatrolObject.offset, screenBounds.x - 0.5f * LerpPatrolObject.offset), screenBounds.y + 2 * LerpPatrolObject.offset, transform.position.z);
    }

    protected virtual void SubtractNumbersOfObjectsSpawned()
    {
        numbersOfObjectsSpawned--;
        if (numbersOfObjectsSpawned < maxNmbersOfObjectsSpawned)
        {
            OnNotFull.Invoke();
        }
    }
}