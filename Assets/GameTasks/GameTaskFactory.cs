using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameTaskFactory {

	public static GameTask GenerateGameTask(Vector3 startPosition)
    {
        GameTask gameTask = new GameTask()
        {
            StartPosition = startPosition,
            GoalPosition = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0),
            StartTime = TimeManager.Instance.GetCurrentTime(),
            GoalTime = TimeManager.Instance.GetCurrentTime().Add(System.TimeSpan.FromMinutes(Random.Range(1, 10)))
        };

        return gameTask;
    }
}
