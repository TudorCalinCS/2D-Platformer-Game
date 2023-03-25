using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    
    [SerializeField] private Transform levelpart_start;
    [SerializeField] private List<Transform> levelPartList;
    [SerializeField] private int cate_platforme;
    //[SerializeField] private playerscript player;


    private Vector3 lastEndPosition;
    private void Awake()
    {
        lastEndPosition = levelpart_start.Find("EndPosition").position;
        SpawnLevelPart();
        for (int i = 0; i <= 5; i++)
            SpawnLevelPart();

    }
    private void Update()
    {
        if (cate_platforme > 0)
        {
            SpawnLevelPart();
            cate_platforme--;
        }
    }

    private void SpawnLevelPart()
    {
        Transform chosenLevePart = levelPartList[Random.Range(0, levelPartList.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevePart,lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;


    }
    private Transform SpawnLevelPart(Transform levelpart, Vector3 spawnposition)
    {
        Transform levelPartTransform =Instantiate(levelpart, spawnposition, Quaternion.identity);
        return levelPartTransform;
    }
}
