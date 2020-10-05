using UnityEngine;
using System.Collections.Generic;
using static RhythmTracker;

public static class NotePatterns
{
    private static List<List<BeatCommandId>> allPatterns = new List<List<BeatCommandId>>();

    private static List<List<BeatCommandId>> basicPatterns = new List<List<BeatCommandId>>();

    static NotePatterns()
    {
        basicPatterns.Add(new List<BeatCommandId> { BeatCommandId.A, BeatCommandId.None, BeatCommandId.B, BeatCommandId.None,
                                               BeatCommandId.A, BeatCommandId.None, BeatCommandId.B, BeatCommandId.None });

        basicPatterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.None, BeatCommandId.A, BeatCommandId.None,
                                               BeatCommandId.B, BeatCommandId.None, BeatCommandId.B, BeatCommandId.None });

        basicPatterns.Add(new List<BeatCommandId> { BeatCommandId.A, BeatCommandId.None, BeatCommandId.None, BeatCommandId.None,
                                               BeatCommandId.B, BeatCommandId.None, BeatCommandId.None, BeatCommandId.None });

        basicPatterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.None, BeatCommandId.None, BeatCommandId.None,
                                               BeatCommandId.A, BeatCommandId.None, BeatCommandId.None, BeatCommandId.None });

        basicPatterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.None, BeatCommandId.B, BeatCommandId.None,
                                               BeatCommandId.A, BeatCommandId.None, BeatCommandId.None, BeatCommandId.None });

        basicPatterns.Add(new List<BeatCommandId> { BeatCommandId.None, BeatCommandId.None, BeatCommandId.B, BeatCommandId.None,
                                               BeatCommandId.None, BeatCommandId.None, BeatCommandId.B, BeatCommandId.None });

        basicPatterns.Add(new List<BeatCommandId> { BeatCommandId.None, BeatCommandId.None, BeatCommandId.A, BeatCommandId.None,
                                               BeatCommandId.None, BeatCommandId.None, BeatCommandId.A, BeatCommandId.None });

        basicPatterns.Add(new List<BeatCommandId> { BeatCommandId.None, BeatCommandId.None, BeatCommandId.A, BeatCommandId.None,
                                               BeatCommandId.None, BeatCommandId.None, BeatCommandId.B, BeatCommandId.None });

        basicPatterns.Add(new List<BeatCommandId> { BeatCommandId.A, BeatCommandId.None, BeatCommandId.A, BeatCommandId.None,
                                               BeatCommandId.A, BeatCommandId.None, BeatCommandId.None, BeatCommandId.None });

        basicPatterns.Add(new List<BeatCommandId> { BeatCommandId.A, BeatCommandId.None, BeatCommandId.B, BeatCommandId.None,
                                               BeatCommandId.A, BeatCommandId.None, BeatCommandId.None, BeatCommandId.None });

        basicPatterns.Add(new List<BeatCommandId> { BeatCommandId.A, BeatCommandId.None, BeatCommandId.A, BeatCommandId.None,
                                               BeatCommandId.B, BeatCommandId.None, BeatCommandId.None, BeatCommandId.None });

        basicPatterns.Add(new List<BeatCommandId> { BeatCommandId.A, BeatCommandId.None, BeatCommandId.B, BeatCommandId.None,
                                               BeatCommandId.B, BeatCommandId.None, BeatCommandId.None, BeatCommandId.None });

        basicPatterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.None, BeatCommandId.B, BeatCommandId.None,
                                               BeatCommandId.B, BeatCommandId.None, BeatCommandId.None, BeatCommandId.None });

        basicPatterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.None, BeatCommandId.A, BeatCommandId.None,
                                               BeatCommandId.B, BeatCommandId.None, BeatCommandId.None, BeatCommandId.None });

        basicPatterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.None, BeatCommandId.B, BeatCommandId.None,
                                               BeatCommandId.A, BeatCommandId.None, BeatCommandId.None, BeatCommandId.None });

        basicPatterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.None, BeatCommandId.A, BeatCommandId.None,
                                               BeatCommandId.A, BeatCommandId.None, BeatCommandId.None, BeatCommandId.None });

        basicPatterns.Add(new List<BeatCommandId> { BeatCommandId.None, BeatCommandId.None, BeatCommandId.B, BeatCommandId.None,
                                               BeatCommandId.None, BeatCommandId.None, BeatCommandId.A, BeatCommandId.None });

        basicPatterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.None, BeatCommandId.B, BeatCommandId.None,
                                               BeatCommandId.B, BeatCommandId.B, BeatCommandId.B, BeatCommandId.None });

        basicPatterns.Add(new List<BeatCommandId> { BeatCommandId.A, BeatCommandId.None, BeatCommandId.A, BeatCommandId.None,
                                               BeatCommandId.A, BeatCommandId.A, BeatCommandId.A, BeatCommandId.None });

        basicPatterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.None, BeatCommandId.B, BeatCommandId.None,
                                               BeatCommandId.B, BeatCommandId.None, BeatCommandId.B, BeatCommandId.B });

        basicPatterns.Add(new List<BeatCommandId> { BeatCommandId.A, BeatCommandId.None, BeatCommandId.A, BeatCommandId.None,
                                               BeatCommandId.A, BeatCommandId.None, BeatCommandId.A, BeatCommandId.A });

        allPatterns.AddRange(basicPatterns);

        allPatterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.B, BeatCommandId.A, BeatCommandId.None,
                                               BeatCommandId.B, BeatCommandId.B, BeatCommandId.A, BeatCommandId.None });

        allPatterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.B, BeatCommandId.A, BeatCommandId.None,
                                               BeatCommandId.B, BeatCommandId.A, BeatCommandId.B, BeatCommandId.None });

        allPatterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.B, BeatCommandId.None, BeatCommandId.A,
                                               BeatCommandId.B, BeatCommandId.None, BeatCommandId.B, BeatCommandId.None });

        allPatterns.Add(new List<BeatCommandId> { BeatCommandId.A, BeatCommandId.A, BeatCommandId.A, BeatCommandId.A,
                                               BeatCommandId.B, BeatCommandId.None, BeatCommandId.B, BeatCommandId.None });

        allPatterns.Add(new List<BeatCommandId> { BeatCommandId.A, BeatCommandId.A, BeatCommandId.None, BeatCommandId.A,
                                               BeatCommandId.None, BeatCommandId.A, BeatCommandId.None, BeatCommandId.A });

        allPatterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.B, BeatCommandId.None, BeatCommandId.B,
                                               BeatCommandId.None, BeatCommandId.B, BeatCommandId.None, BeatCommandId.B });

        allPatterns.Add(new List<BeatCommandId> { BeatCommandId.A, BeatCommandId.B, BeatCommandId.B, BeatCommandId.A,
                                               BeatCommandId.A, BeatCommandId.B, BeatCommandId.None, BeatCommandId.B });

        allPatterns.Add(new List<BeatCommandId> { BeatCommandId.A, BeatCommandId.None, BeatCommandId.B, BeatCommandId.None,
                                               BeatCommandId.A, BeatCommandId.B, BeatCommandId.None, BeatCommandId.B });

        allPatterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.None, BeatCommandId.B, BeatCommandId.None,
                                               BeatCommandId.A, BeatCommandId.None, BeatCommandId.None, BeatCommandId.A });

        allPatterns.Add(new List<BeatCommandId> { BeatCommandId.A, BeatCommandId.None, BeatCommandId.B, BeatCommandId.A,
                                               BeatCommandId.None, BeatCommandId.A, BeatCommandId.B, BeatCommandId.None });

        allPatterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.B, BeatCommandId.B, BeatCommandId.B,
                                               BeatCommandId.A, BeatCommandId.A, BeatCommandId.B, BeatCommandId.None });

        allPatterns.Add(new List<BeatCommandId> { BeatCommandId.A, BeatCommandId.A, BeatCommandId.A, BeatCommandId.None,
                                               BeatCommandId.B, BeatCommandId.B, BeatCommandId.B, BeatCommandId.None });

        allPatterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.B, BeatCommandId.B, BeatCommandId.None,
                                               BeatCommandId.A, BeatCommandId.A, BeatCommandId.A, BeatCommandId.None });

        allPatterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.A, BeatCommandId.B, BeatCommandId.None,
                                               BeatCommandId.A, BeatCommandId.B, BeatCommandId.A, BeatCommandId.None });

        allPatterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.A, BeatCommandId.A, BeatCommandId.None,
                                               BeatCommandId.B, BeatCommandId.None, BeatCommandId.B, BeatCommandId.None });

        allPatterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.A, BeatCommandId.B, BeatCommandId.None,
                                               BeatCommandId.A, BeatCommandId.A, BeatCommandId.A, BeatCommandId.None });

        allPatterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.B, BeatCommandId.B, BeatCommandId.None,
                                               BeatCommandId.A, BeatCommandId.B, BeatCommandId.A, BeatCommandId.None });

        allPatterns.Add(new List<BeatCommandId> { BeatCommandId.A, BeatCommandId.None, BeatCommandId.B, BeatCommandId.None,
                                               BeatCommandId.A, BeatCommandId.B, BeatCommandId.None, BeatCommandId.A });

        allPatterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.None, BeatCommandId.A, BeatCommandId.None,
                                               BeatCommandId.B, BeatCommandId.A, BeatCommandId.None, BeatCommandId.B });

        allPatterns.Add(new List<BeatCommandId> { BeatCommandId.A, BeatCommandId.None, BeatCommandId.B, BeatCommandId.None,
                                               BeatCommandId.A, BeatCommandId.None, BeatCommandId.None, BeatCommandId.B });

        allPatterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.None, BeatCommandId.A, BeatCommandId.None,
                                               BeatCommandId.B, BeatCommandId.None, BeatCommandId.None, BeatCommandId.A });

        allPatterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.A, BeatCommandId.None, BeatCommandId.B,
                                               BeatCommandId.A, BeatCommandId.None, BeatCommandId.B, BeatCommandId.A });

        allPatterns.Add(new List<BeatCommandId> { BeatCommandId.A, BeatCommandId.B, BeatCommandId.None, BeatCommandId.A,
                                               BeatCommandId.B, BeatCommandId.None, BeatCommandId.A, BeatCommandId.B });

        allPatterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.None, BeatCommandId.A, BeatCommandId.None,
                                               BeatCommandId.None, BeatCommandId.B, BeatCommandId.None, BeatCommandId.A });

        allPatterns.Add(new List<BeatCommandId> { BeatCommandId.A, BeatCommandId.None, BeatCommandId.B, BeatCommandId.None,
                                               BeatCommandId.None, BeatCommandId.A, BeatCommandId.None, BeatCommandId.B });

        allPatterns.Add(new List<BeatCommandId> { BeatCommandId.A, BeatCommandId.None, BeatCommandId.None, BeatCommandId.A,
                                               BeatCommandId.None, BeatCommandId.A, BeatCommandId.None, BeatCommandId.A });

        allPatterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.None, BeatCommandId.None, BeatCommandId.B,
                                               BeatCommandId.None, BeatCommandId.B, BeatCommandId.None, BeatCommandId.B });

        allPatterns.Add(new List<BeatCommandId> { BeatCommandId.A, BeatCommandId.None, BeatCommandId.None, BeatCommandId.A,
                                               BeatCommandId.None, BeatCommandId.B, BeatCommandId.None, BeatCommandId.B });

        allPatterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.None, BeatCommandId.None, BeatCommandId.B,
                                               BeatCommandId.None, BeatCommandId.A, BeatCommandId.None, BeatCommandId.A });

        allPatterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.None, BeatCommandId.B, BeatCommandId.B,
                                               BeatCommandId.B, BeatCommandId.None, BeatCommandId.B, BeatCommandId.None });

        allPatterns.Add(new List<BeatCommandId> { BeatCommandId.A, BeatCommandId.None, BeatCommandId.A, BeatCommandId.A,
                                               BeatCommandId.A, BeatCommandId.None, BeatCommandId.A, BeatCommandId.None });
    }

    public static List<BeatCommandId> GetRandomPattern()
    {
        return allPatterns[Random.Range(0, allPatterns.Count)];
    }

    public static List<BeatCommandId> GetRandomBasicPattern()
    {
        return basicPatterns[Random.Range(0, basicPatterns.Count)];
    }
}
