using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Actor {

    public ActorBio Bio;

    public GameTask CurrentTask;
    public Vector2 CurrentPosition;

    public ActorObject ActorObject;

    private ActorGoal m_currentGoal;

    private List<GameTask> m_taskHistory = new List<GameTask>();
    private int m_currentTaskIndex = 0;

    /// <summary>
    /// Constructor for initialization.
    /// </summary>
    public Actor()
    {
        // Start with a task.
        //SetNextTask();
    }

    /// <summary>
    /// Perform standard AI and tasks.
    /// </summary>
    public void Update()
    {
        // Determine my next goal.
        UpdateCurrentGoal();

        // Set a task to accomplish that goal.
        UpdateCurrentTask();

        // Execute my current task.
        PerformCurrentTask();
    }

    /// <summary>
    /// Look at my schedule and determine what my current goal should be.
    /// </summary>
    private void UpdateCurrentGoal()
    {
        if(Bio == null)
        {
            return;
        }

        // Iterate my goals. For now, assume they are sorted by time.
        foreach(var goal in Bio.Schedule.Schedule)
        {
            // If we have missed this goal, skip it and move on.
            if (TimeManager.Instance.IsPassedTime(goal.GoalTime))
            {
                continue;
            }

            // Check any other pre-conditions.

            // This goal is the next available goal (assuming sorted by time).
            m_currentGoal = goal;
            return;
        }
    }

    /// <summary>
    /// Check my current task, current goal, current time, etc and determine what I should be doing.
    /// This should use Utility AI to determine what I should be doing.
    /// </summary>
    private void UpdateCurrentTask()
    {
        // Use Utility AI to determine what I should be doing.
        // Look at my current goal, the time it will take to complete that goal, and my other needs.


        // Handle the end time of the task.
        if (CurrentTask == null || TimeManager.Instance.IsPassedTime(CurrentTask.GoalTime))
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
    private void PerformCurrentTask()
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
        if (ActorObject.transform.position != goalPosition)
        {
            float totalDistance = Vector3.Distance(startPosition, goalPosition);
            TimeSpan totalTime = goalTime - startTime;
            float moveSpeed = (totalDistance / TimeManager.Instance.GetRealSecondsFromGameSeconds((float)totalTime.TotalSeconds)) * TimeManager.Instance.TimeScale;

            ActorObject.transform.position += (goalPosition - ActorObject.transform.position).normalized * moveSpeed * Time.deltaTime;
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
            CurrentTask = GameTaskFactory.GenerateGameTask(ActorObject.transform.position);
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
