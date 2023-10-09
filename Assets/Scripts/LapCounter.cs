using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LapCounter : MonoBehaviour
{
   //Variables that would determine which car is at 1st place by checking how many checkpoint a car passed with the least amount of time.
   private int _passedCheckPointNumber;
   private float _lastCheckpointTimePassed;
   private int _quantityOfPassedCheckPoint;
   private int _completedLaps = 0;
   private const int TotalLaps = 2;
   private bool raceEnded = false;
   
   private int positionOfCar = 0;

   public Text positionOfCarText;
   private bool _routineRuningHide;
   private float _delayTimeUIHide;

   // Events
   public event Action<LapCounter> CheckpointPassed; 
   
   public void SetPositionOfCar(int position)
   {
      positionOfCar = position;
   }

   public int GetQuantityOfPassedCheckpoint()
   {
      return _quantityOfPassedCheckPoint;
   }

   public float GetLastCheckpointTimePassed()
   {
      return _lastCheckpointTimePassed;
   }

   IEnumerator ShowPositionOfCarCO(float delayUntilHidePosition)
   {
      _delayTimeUIHide += delayUntilHidePosition;
      
      positionOfCarText.text = positionOfCar.ToString();
      
      positionOfCarText.gameObject.SetActive(true);

      if (!_routineRuningHide)
      {
         _routineRuningHide = true;

         yield return new WaitForSeconds(delayUntilHidePosition);

         positionOfCarText.gameObject.SetActive(false);

         _routineRuningHide = false;
      }
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("CheckPoint"))
      {
         //When the car finishes the race then checkpoints or laps will no longer be tracked.
         if (raceEnded)
            return;
         
         CheckPoints checkpoint = other.GetComponent<CheckPoints>();
         
         // This allows us to follow the order of the checkpoint and not skipping checkpoints.
         if (_passedCheckPointNumber + 1 == checkpoint.checkPointNumber)
         {
            _passedCheckPointNumber = checkpoint.checkPointNumber;

            _quantityOfPassedCheckPoint++;
            
            // This records the time when we pass the checkpoint
            _lastCheckpointTimePassed = Time.time;

            if (checkpoint.lapEndLine)
            {
               _passedCheckPointNumber = 0;
               _completedLaps++;

               if (_completedLaps >= TotalLaps)
                  raceEnded = true;
            }
            
            //CheckpointPassed event invoked
            CheckpointPassed?.Invoke(this);

            // Position of car is now showed as text
            if (raceEnded)
               StartCoroutine(ShowPositionOfCarCO(100));
            else StartCoroutine(ShowPositionOfCarCO(1.5f));
         }
      }
   }
}
