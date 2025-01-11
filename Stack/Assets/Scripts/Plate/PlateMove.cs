using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateMove : MonoBehaviour
{
   public event Action StopPlate;
   [SerializeField] private SpawnPlate _spawnPlate;
   [SerializeField] private float _moveSpeed = 3f;
   [SerializeField] public Transform[] _firstWaypoints;
   [SerializeField] public Transform[] _secondWaypoints;
  // [SerializeField] private Transform _parent;
   
   private float _moveAmount = 0.5f;
   private int _currentWaypointIndex = 0;
   
   private bool _isMovingForward = true;
   private bool IsMoving;

   private void Start()
   {
      IsMoving = true;
   }

   public void MovePlate(Transform[] waypoints)
   {
      if (IsMoving)
      {
         Transform targetWaypoint = waypoints[_currentWaypointIndex];
         transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, _moveSpeed * Time.deltaTime);

         if (Vector3.Distance(transform.position, targetWaypoint.position ) < 0.1f)
         {
            _currentWaypointIndex++;

            if (_currentWaypointIndex >= waypoints.Length)
            {
               _currentWaypointIndex = 0;
            }
         }
      }

      if (Input.GetKeyDown(KeyCode.Space))
      {
         _moveSpeed = 0f;
         IsMoving = false;
         StopPlate?.Invoke();
      } 
      
   }
}
