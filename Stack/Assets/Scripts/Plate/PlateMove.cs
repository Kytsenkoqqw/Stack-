using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateMove : MonoBehaviour
{
   public event Action StopPlate;
   [SerializeField] private float _moveSpeed = 3f;
   [SerializeField] private Transform[] _waypoints;
   private int _currentWaypointIndex = 0;
   
   
   private bool _isMovingForward = true;
   

   public bool IsMoving { get; private set; }

   private void Start()
   {
      IsMoving = true;
   }

   private void Update()
   {

      if (IsMoving)
      {
         Transform targetWaypoint = _waypoints[_currentWaypointIndex];
         transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, _moveSpeed * Time.deltaTime);

         if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
         {
            _currentWaypointIndex++;

            if (_currentWaypointIndex >= _waypoints.Length)
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
