using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneSpawnTimerBar : MonoBehaviour
{
    private float timePassed;
    [SerializeField] private PhoneSpawner phoneSpawner;
    private Image phoneSpawnTimerBar;

    private void Start()
    {
        phoneSpawnTimerBar = GetComponent<Image>();
        SetStartParameters();
    }

    private void Update()
    {
        if (phoneSpawner.NumbersOfObjectsSpawned == phoneSpawner.MaxNmbersOfObjectsSpawned)
        {
            SetStartParameters();
            return;
        }
        if (timePassed < phoneSpawner.TimeBetweenSpawn)
        {
            timePassed += Time.deltaTime;
            phoneSpawnTimerBar.fillAmount = timePassed / phoneSpawner.TimeBetweenSpawn;
        }
        else
        {
            phoneSpawner.Spawn();
            SetStartParameters();
        }
    }

    private void SetStartParameters()
    {
        timePassed = 0;
        phoneSpawnTimerBar.fillAmount = 0;
    }
}