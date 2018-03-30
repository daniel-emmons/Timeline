using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class NPCScript : MonoBehaviour {

    public GameTask CurrentTask;

    private List<GameTask> m_taskHistory = new List<GameTask>();
    private int m_currentTaskIndex = 0;

    // Use this for initialization
    void Start()
    {

        // Start with a task.
        SetNextTask();
    }

    // Update is called once per frame
    void Update()
    {

        // Move to the goal position;
        PerformTask();

        // Handle the end time of the task.
        if (TimeManager.Instance.IsPassedTime(CurrentTask.GoalTime))
        {
            SetNextTask();
        }

        // Handle tasks backwards in time.
        if (TimeManager.Instance.IsBeforeTime(CurrentTask.StartTime))
        {
            SetPreviousTask();
        }
    }

    /// <summary>
    /// Move.
    /// </summary>
    private void PerformTask()
    {
        MovementGameTask movementTask = (MovementGameTask)CurrentTask;
        Vector3 goalPosition = movementTask.GoalPosition;
        Vector3 startPosition = movementTask.StartPosition;
        TimeSpan goalTime = CurrentTask.GoalTime;
        TimeSpan startTime = CurrentTask.StartTime;

        if (TimeManager.Instance.TimeScale < 0)
        {
            goalPosition = movementTask.StartPosition;
            startPosition = movementTask.GoalPosition;
            goalTime = CurrentTask.StartTime;
            startTime = CurrentTask.GoalTime;
        }
        if (transform.position != goalPosition)
        {
            float totalDistance = Vector3.Distance(startPosition, goalPosition);
            TimeSpan totalTime = goalTime - startTime;
            float moveSpeed = (totalDistance / TimeManager.Instance.GetRealSecondsFromGameSeconds((float)totalTime.TotalSeconds)) * TimeManager.Instance.TimeScale;

            transform.position += (goalPosition - transform.position).normalized * moveSpeed * Time.deltaTime;
        }
    }

    /// <summary>
    /// Move to the next task in the list, or generate a new one.
    /// </summary>
    private void SetNextTask()
    {
        m_currentTaskIndex += 1;

        if (m_currentTaskIndex >= m_taskHistory.Count)
        {
            CurrentTask = GameTaskFactory.GenerateGameTask(transform.position);
            m_taskHistory.Add(CurrentTask);
            m_currentTaskIndex = m_taskHistory.Count - 1;
        }
        else
        {
            CurrentTask = m_taskHistory[m_currentTaskIndex];
        }
    }

    /// <summary>
    /// Move to the previous task in the list, or stop.
    /// </summary>
    private void SetPreviousTask()
    {
        if (m_currentTaskIndex == 0)
        {
            return;
        }
        m_currentTaskIndex -= 1;
        CurrentTask = m_taskHistory[m_currentTaskIndex];
    }
}
