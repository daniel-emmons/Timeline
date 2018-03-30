using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[System.Serializable]
public class SerializableTimeSpan {

    [SerializeField()]
    public int Days;

    [SerializeField()]
    public int Hours;

    [SerializeField()]
    public int Minutes;

    [SerializeField()]
    public int Seconds;

    [SerializeField()]
    public int Milliseconds;

    /// <summary>
    /// Convert a timespan into a serializable 
    /// </summary>
    public SerializableTimeSpan(TimeSpan timespan)
    {
        Days = timespan.Days;
        Hours = timespan.Hours;
        Minutes = timespan.Minutes;
        Seconds = timespan.Seconds;
        Milliseconds = timespan.Milliseconds;
    }

    /// <summary>
    /// Convert it back into a timespan.
    /// </summary>
	public TimeSpan GetTimespan()
    {
        return new TimeSpan(Days, Hours, Minutes, Seconds, Milliseconds);
    }
}
