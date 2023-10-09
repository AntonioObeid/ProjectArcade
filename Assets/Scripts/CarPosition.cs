using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CarPosition : MonoBehaviour
{
    public List<LapCounter> lapCounters = new List<LapCounter>();
    
    // Start is called before the first frame update
    void Start()
    {
        //Finds all the lap counters in unity scene
        LapCounter[] lapCounterArray = FindObjectsOfType<LapCounter>();

        //Lap counters are then stored in a list
        lapCounters = lapCounterArray.ToList<LapCounter>();

        //We tie it to the events of checkpoint passed
        foreach (LapCounter lapCounters in lapCounters)
            lapCounters.CheckpointPassed += CheckpointPassed;
    }

    void CheckpointPassed(LapCounter lapCounter)
    {
        //Firstly, we sort the positions of cars according to how many checkpoint we have passed and then we sort them by the shortest time they passed a checkpoint. (More checkpoint and shortest time are always better)
        lapCounters = lapCounters.OrderByDescending(x => x.GetQuantityOfPassedCheckpoint())
            .ThenBy(x => x.GetLastCheckpointTimePassed()).ToList();
        
        //Car Positions are obtained
        int positionOfCar = lapCounters.IndexOf(lapCounter) + 1;

        lapCounter.SetPositionOfCar(positionOfCar);
    }
}
