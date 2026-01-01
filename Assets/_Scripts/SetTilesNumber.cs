using System.Collections.Generic;
using UnityEngine;

public class SetTilesNumber : MonoBehaviour
{
    public int startCount = 9;
    public NumberTMPs numberTmps;

    private int tileCount;

    // 중복 방지
    private HashSet<int> uniqueNums = new HashSet<int>();

    void Start()
    {
        tileCount = numberTmps.GetTileCount();
        SetInitialNumber();
    }

    /// <summary>
    /// 최초 한 번 정해진 개수만큼 생성
    /// </summary>
    private void SetInitialNumber()
    {
        if (numberTmps == null) return;
        if (tileCount <= 0) return;

        int k = Mathf.Min(startCount, tileCount);

        for (int i = 0; i < k; i++)
        {
            SpawnRandomTileNumber();
        }
    }

    /// <summary>
    /// 랜덤 생성
    /// </summary>

    private bool SpawnRandomTileNumber()
    {
        if (uniqueNums.Count >= tileCount)
            return false;

        int idx;
        do
        {
            idx = Random.Range(0, tileCount);
        }
        while (uniqueNums.Contains(idx));

        uniqueNums.Add(idx);

        int value = Random.Range(1, 10);
        numberTmps.SetTileText(idx, value);

        return true;
    }

    /// <summary>
    /// 지우기
    /// </summary>

    public void ClearTile(int idx)
    {
        uniqueNums.Remove(idx);
    }
}
