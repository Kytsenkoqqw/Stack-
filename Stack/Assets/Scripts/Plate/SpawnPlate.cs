using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlate : MonoBehaviour
{
    [SerializeField] private GameObject _plate;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private PlateMove _plateMove;
    public int _currentIndexPoint = 0;
    private Vector3 _offset = new Vector3(0, 0,0);
    private float _offsetIncrement = 0.5f;

    private void Start()
    {
        _plateMove.StopPlate += Spawn;
        Spawn();
    }

    private void Update()
    {
        if (_currentIndexPoint == 1)
        {
            _plateMove.MovePlate(_plateMove._firstWaypoints);
        }
        else if (_currentIndexPoint == 0)
        {
            _plateMove.MovePlate(_plateMove._secondWaypoints);
        }
    }

    public void Spawn()
    {
        _offset.y += _offsetIncrement;
        var currentSpawn = _spawnPoints[_currentIndexPoint];
        Quaternion rotation = Quaternion.Euler(0, -135, 0);
        
        if (_currentIndexPoint == 1)
        { 
            rotation = Quaternion.Euler(0,135,0);
        }
            
        var newPlate = Instantiate(_plate, currentSpawn.position + _offset, rotation);
        _plateMove.StopPlate -= Spawn;
        var plateMove = newPlate.GetComponent<PlateMove>();

        if (plateMove != null)
        {
            _plateMove = plateMove;
            _plateMove.StopPlate += Spawn;
        }

        _currentIndexPoint++;
            
        if (_currentIndexPoint >= _spawnPoints.Length)
        { 
            _currentIndexPoint = 0;
        }
        Debug.Log(_currentIndexPoint);
    }

}


