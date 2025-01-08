using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateMove : MonoBehaviour
{
   public Action StopPlate;
   [SerializeField] private float _moveSpeed = 3f;
   public bool IsMoving;

   private void Start()
   {
      IsMoving = true;
   }

   private void Update()
   {

      if (IsMoving)
      {
         transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);

      }
      
      if (Input.GetKeyDown(KeyCode.Space))
      {
         _moveSpeed = 0f;
         IsMoving = false;
         StopPlate?.Invoke();
      }
   }
}
