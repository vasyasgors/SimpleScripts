﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleScripts
{
    public class Spawner : MonoBehaviour
    {
        public enum SpawnMode
        {
            Start,
            Loop,
            Invoke
        }

        [SerializeField] private GameObject prefab;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private SpawnMode spawnMode;
        [SerializeField] private int numSpawn;

        [SerializeField] private float respawnTime;
        [SerializeField] private bool rotateObjectBySpawnPoint = true;


        private float timer;

        private void Start()
        {
            if (spawnMode == SpawnMode.Start)
            {
                Spawn();
            }

            timer = respawnTime;
        }

        private void Update()
        {
            if (timer > 0)
                timer -= Time.deltaTime;

            if (spawnMode == SpawnMode.Loop && timer < 0)
            {
                Spawn();

                timer = respawnTime;
            }
        }

        public void Spawn()
        {
            for (int i = 0; i < numSpawn; i++)
            {
                GameObject e = Instantiate(prefab);

                e.transform.position = spawnPoint.position;

                if(rotateObjectBySpawnPoint == true)
                    e.transform.rotation = spawnPoint.rotation;
            }
        }
    }
}