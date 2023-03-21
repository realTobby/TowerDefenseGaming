using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopManager : MonoBehaviour
{
    public int CurrentWaveIndex = 0;

    public List<GameObject> AliveTroops = new List<GameObject>();

    public GameObject Prefab_Troop;

    public GameObject UI_NEXT_WAVE_BUTTON;

    public void StartNextWave()
    {
        CurrentWaveIndex++;
        StartCoroutine(nameof(SpawnTroops));
    }

    IEnumerator SpawnTroops()
    {
        for(int i = 0; i < CurrentWaveIndex; i++)
        {
            var newToop = Instantiate(Prefab_Troop, GameManager.Instance.GetFirstWaypoint(), Quaternion.identity);
            AliveTroops.Add(newToop);
            yield return new WaitForSeconds(.35f);
        }
    }

    public void RemoveTroop(GameObject troopToRemove)
    {
        AliveTroops.Remove(troopToRemove);

        if(AliveTroops.Count == 0)
        {
            // Wave is over
            UI_NEXT_WAVE_BUTTON.SetActive(true);
        }

    }


}
