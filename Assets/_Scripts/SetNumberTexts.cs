using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;

public class SetNumberTexts : MonoBehaviour
{
    public Tilemap tilemap;
    public TMP_Text tmpPrefab;
    public Transform tmpParent;

    Dictionary<Vector3Int, TMP_Text> map = new();

    void Start()
    {
        tilemap.CompressBounds();
        BoundsInt bounds = tilemap.cellBounds;

        foreach (var cell in bounds.allPositionsWithin)
        {
            if (tilemap.HasTile(cell))
            {
                SetNumber(cell, null);
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

    //숫자 할당할때
    public void SetNumber(Vector3Int cell, int n)
    {
        var txt = GetOrCreate(cell);
        txt.text = n.ToString();
        txt.gameObject.SetActive(true);
    }
    //넘버->문자열 빈칸 0만들때 사용
    public void SetNumber(Vector3Int cell, string text)
    {
        var txt = GetOrCreate(cell);
        txt.text = text;     
        txt.gameObject.SetActive(true);
    }

    public void Clear(Vector3Int cell)
    {
        if (map.TryGetValue(cell, out var txt))
        {
            txt.gameObject.SetActive(false);
            map.Remove(cell);
        }
    }

    
}
