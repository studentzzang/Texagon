using System.Collections.Generic;
using UnityEngine;

public class SetTilesNumber : MonoBehaviour
{
    public int startCount = 9;
    public NumberTMPs numberTmps;

    private int tileCount;

    void Start()
    {
        tileCount = numberTmps.GetTileCount();
        SetInitialNumber();
    }

    private void SetInitialNumber()
    {
        if (numberTmps == null) return;
        if (tileCount <= 0) return;

        int k = Mathf.Min(startCount, tileCount);

        // 중복 방지
        HashSet<int> chosen = new HashSet<int>();

        while (chosen.Count < k)
        {
            int idx = Random.Range(0, tileCount);
            if (!chosen.Add(idx)) continue; 

            int value = Random.Range(1, 10);
            numberTmps.SetTileText(idx, value); //뽑은 idx에 바로 할당
        }
    }
}
