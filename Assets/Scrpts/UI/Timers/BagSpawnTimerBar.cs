using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagSpawnTimerBar : MonoBehaviour
{
    private float timePassed;
    [SerializeField] private BagSpawner bagSpawner;
    private Image bagSpawnTimerBar;

    private void Start()
    {
        bagSpawnTimerBar = GetComponent<Image>();
        SetStartParameters();
    }

    private void Update()
    {
        if (bagSpawner.NumbersOfObjectsSpawned == bagSpawner.MaxNmbersOfObjectsSpawned)
        {
            SetStartParameters();
            return;
        }
        if (timePassed < bagSpawner.TimeBetweenSpawn)
        {
            timePassed += Time.deltaTime;
            bagSpawnTimerBar.fillAmount = timePassed / bagSpawner.TimeBetweenSpawn;
        }
        else
        {
            bagSpawner.Spawn();
            SetStartParameters();
        }
    }


    private void SetStartParameters()
    {
        timePassed = 0;
        bagSpawnTimerBar.fillAmount = 0;
    }
}