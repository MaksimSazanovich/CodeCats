using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatsPool : MonoBehaviour
{
    private readonly Dictionary<string, List<GameObject>> cats = new Dictionary<string, List<GameObject>>();

    public void AddCats(GameObject catPrefab, int count)
    {
        if (cats.ContainsKey(catPrefab.name) == false)
            cats.Add(catPrefab.name, new List<GameObject>());

        for (int i = 0; i < count; i++)
        {
            //var cat = Instantiate(catPrefab, transform);
            Create(catPrefab);
        }
    }

    private GameObject Create(GameObject carPrefab)
    {
        var cat = Instantiate(carPrefab, transform);
        cat.SetActive(false);
        cats[carPrefab.name].Add(cat);

        return cat;
    }

    public GameObject GetBullet(GameObject catPrefab)
    {
        if (cats.ContainsKey(catPrefab.name))
        {
            for (int i = 0; i < cats.Count; i++)
            {
                if (!cats[catPrefab.name][i].activeInHierarchy)
                    return cats[catPrefab.name][i];
            }
            return Create(catPrefab);
        }
        else
            cats.Add(catPrefab.name, new List<GameObject>());

        return Create(catPrefab);
    }
}
