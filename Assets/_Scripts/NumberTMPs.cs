using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;

public class NumberTMPs : MonoBehaviour
{
    public Tilemap tilemap;
    public TMP_Text tmpPrefab;
    public Transform tmpParent;

    Dictionary<Vector3Int, TMP_Text> map = new();
    List<Vector3Int> cells = new();

    void Awake()
    {
        Init();
    }

    private void Init()
    {
        cells.Clear();

        tilemap.CompressBounds();
        BoundsInt bounds = tilemap.cellBounds;

        foreach (var cell in bounds.allPositionsWithin)
        {
            if (tilemap.HasTile(cell))
            {
                cells.Add(cell);
                GetOrCreate(cell);
            }
        }
    }

    public TMP_Text GetOrCreate(Vector3Int cell)
    {
        if (map.TryGetValue(cell, out var t))
            return t;

        var txt = Instantiate(tmpPrefab, tmpParent);
        txt.transform.position = tilemap.GetCellCenterWorld(cell);
        txt.transform.localScale = Vector3.one;

        map[cell] = txt;
        return txt;
    }

    /// <summary>
    ///  cell 인덱스에 맞는 tmp에 숫자 텍스트 할당
    ///  0이면 아무것도 출력X
    /// </summary>

    public void SetTileText(int idx, int n)
    {
        if (idx < 0 || idx >= cells.Count)
            return;

        Vector3Int cell = cells[idx];
        var txt = GetOrCreate(cell);

        txt.text = (n == 0) ? "" : n.ToString();
        txt.gameObject.SetActive(true);
    }

    public int GetTileCount()
    {
        return cells.Count;
    }
}
