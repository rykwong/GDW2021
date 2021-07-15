using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class HiddenPuzzleManager : MonoBehaviour
{
    [SerializeField] private GameObject[] tiles;
    [SerializeField] private GameObject[] answerTiles;

    private bool[][] possibleAnswers = new[]
    {
        new[] {true,false,false,false,false,
            true,false,false,false,false,
            true,false,false,false,false,
            true,false,false,false,false,
            true,false,false,false,false},
        new[] {false,true,false,false,false,
            false,true,false,false,false,
            false,true,false,false,false,
            false,true,false,false,false,
            false,true,false,false,false}
    };

    private void Start()
    {
        GeneratePuzzle();
    }

    public void GeneratePuzzle()
    {
        bool[] answers = possibleAnswers[Random.Range(0, possibleAnswers.Length)];
        for(int i = 0; i < answers.Length; i ++)
        {
            MeshCollider tile = tiles[i].GetComponent<MeshCollider>();
            if (answers[i])
            {
                tiles[i].layer = 6;
                tile.isTrigger = false;
                tile.convex = false;
                answerTiles[i].SetActive(true);
            }
            else
            {
                tiles[i].layer = 0;
                tile.convex = true;
                tile.isTrigger = true;
                answerTiles[i].SetActive(false);
            }
        }
    }
}
