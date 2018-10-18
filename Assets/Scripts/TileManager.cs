﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

    public GameObject[] tilePrefabs;

    private Transform playerTransform;
    private float spawnZ = 70.0f;
    private float tileLength = 80.0f;
    private float safeZone = 45.0f;
    private int amnTilesOnScreen = 3;
    private int lastPrefabIndex = 0;

    private List<GameObject> activeTiles;

	// Use this for initialization
	private void Start () {
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
      
        for(int i = 0; i < amnTilesOnScreen; i++)
        {
            SpawnTile();
        }
    }
	
	// Update is called once per frame
	private void Update () {
		if (playerTransform.position.z - safeZone > (spawnZ - amnTilesOnScreen * tileLength) )
        {
            SpawnTile();
            DeleteTile();
        }
	}

    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(go);
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private int RandomPrefabIndex()
    {
        if (tilePrefabs.Length <= 1)
            return 0;

        int randomIndex = lastPrefabIndex;
        while(randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }

        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}
