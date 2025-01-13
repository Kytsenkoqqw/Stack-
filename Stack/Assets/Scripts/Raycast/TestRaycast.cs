using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class TestRaycast : MonoBehaviour
{

   private Renderer _renderer;

   private void Start()
   {
      _renderer = GetComponent<Renderer>();
   }

   private void Update()
   {
      ClickMouse();
   }

   private void ClickMouse()
   {

      if (Input.GetMouseButtonDown(0))
      {
         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         RaycastHit hit;

         if (Physics.Raycast(ray, out hit))
         {
            
         }
      }
     
   }
}
