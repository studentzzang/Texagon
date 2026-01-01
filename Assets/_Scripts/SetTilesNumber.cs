///<summary>
/// 타일 담은 부모옵젝에, 숫자 설정만
///</summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTilesNumber : MonoBehaviour
{
    public int sum = 50; //분포 된 숫자 총합
    int count;
    Transform children;

    private void Awake()
    {
        count = transform.childCount;
    }
    void Start()
    {
        SetRandomNumTile();
    }

    void SetRandomNumTile()
    {
        int rand = Random.Range(0, 10);
    }

    void Update()
    {
        
    }



}
