using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class HiddenPuzzleManager : MonoBehaviour
{
    [SerializeField] private GameObject[] tiles;
    [SerializeField] private GameObject[] answerTiles;
    //2d array of possible answers
    private bool[][] possibleAnswers = new[]
    {
        new[] {
            true,false,false,false,false,
            true,false,false,false,false,
            true,true,true,false,false,
            false,false,true,false,false,
            false,false,true,false,false},
        new[] {
            true,false,false,false,false,
            true,true,false,false,false,
            false,true,false,false,false,
            false,true,false,false,false,
            false,true,true,false,false},
        new[] {
            false,true,false,false,false,
            false,true,true,false,false,
            false,false,true,true,false,
            false,false,false,true,true,
            false,false,false,false,true},
        new[] {
            false,false,false,true,false,
            false,false,false,true,true,
            false,false,false,false,true,
            false,false,true,true,true,
            false,false,true,false,false},
        new[] {
            true,false,false,false,false,
            false,true,false,false,false,
            false,false,true,false,false,
            false,false,false,true,false,
            false,false,false,false,true},
        new[] {
            false,true,false,true,false,
            true,false,true,false,true,
            false,true,false,true,false,
            true,false,true,false,true,
            false,true,false,true,false}
    };

    private void Start()
    {
        GeneratePuzzle();
    }

    //create puzzles
    /*
     * look through possible answers:
     *      if wrong:
     *              it has no ground layer
     */

    public void GeneratePuzzle()
    {
        bool[] answers = possibleAnswers[Random.Range(0, possibleAnswers.Length)];
        for (int i = 0; i < answers.Length; i++)
        {
            MeshCollider tile = tiles[i].GetComponent<MeshCollider>();
            MeshRenderer answer = answerTiles[i].GetComponent<MeshRenderer>();
            if (answers[i])
            {
                tiles[i].layer = 6;
                tile.isTrigger = false;
                tile.convex = false;
                answer.material.color = Color.green;
            }
            else
            {
                tiles[i].layer = 0;
                tile.convex = true;
                tile.isTrigger = true;
                answer.material.color = Color.red;
            }
        }
    }
}
