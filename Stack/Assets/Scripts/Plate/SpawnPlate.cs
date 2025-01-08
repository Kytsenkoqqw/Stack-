using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlate : MonoBehaviour
{
    [SerializeField] private GameObject _plate;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private PlateMove _plateMove;
    private int _currentIndexPoint = 0;
    private Vector3 _offset = new Vector3(0, 0,0);
    private float _offsetIncrement = 0.5f;

    private void Start()
    {
        Spawn();
        _plateMove.StopPlate += Spawn;
    }

    private void Update()
    {
        if (!_plateMove.IsMoving)
        {
            Spawn();
        }
    }


    private void OnDestroy()
    {
        _plateMove.StopPlate -= Spawn;
    }


    private void Spawn()
    {
        _offset.y += _offsetIncrement;
        var currentSpawn = _spawnPoints[_currentIndexPoint];
        Quaternion rotation = Quaternion.Euler(0, -135, 0);
            

        if (_currentIndexPoint == 1)
        { 
            rotation = Quaternion.Euler(0,135,0);
        }
            
        var spawnPlate = Instantiate(_plate, currentSpawn.position + _offset, rotation);
            
        _currentIndexPoint++;
            
        if (_currentIndexPoint >= _spawnPoints.Length)
        { 
            _currentIndexPoint = 0;
        }
    }

}


