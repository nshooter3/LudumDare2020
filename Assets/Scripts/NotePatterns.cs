using UnityEngine;
using System.Collections.Generic;
using static RhythmTracker;

public static class NotePatterns
{
    private static List<List<BeatCommandId>> patterns = new List<List<BeatCommandId>>();

    static NotePatterns()
    {
        patterns.Add(new List<BeatCommandId> { BeatCommandId.A, BeatCommandId.None, BeatCommandId.B, BeatCommandId.None,
                                               BeatCommandId.A, BeatCommandId.None, BeatCommandId.B, BeatCommandId.None });
        patterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.None, BeatCommandId.A, BeatCommandId.None,
                                               BeatCommandId.B, BeatCommandId.None, BeatCommandId.B, BeatCommandId.None });
        patterns.Add(new List<BeatCommandId> { BeatCommandId.A, BeatCommandId.None, BeatCommandId.None, BeatCommandId.None,
                                               BeatCommandId.B, BeatCommandId.None, BeatCommandId.None, BeatCommandId.None });
        patterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.None, BeatCommandId.None, BeatCommandId.None,
                                               BeatCommandId.A, BeatCommandId.None, BeatCommandId.None, BeatCommandId.None });
        patterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.B, BeatCommandId.A, BeatCommandId.None,
                                               BeatCommandId.B, BeatCommandId.B, BeatCommandId.A, BeatCommandId.None });
        patterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.B, BeatCommandId.A, BeatCommandId.None,
                                               BeatCommandId.B, BeatCommandId.A, BeatCommandId.B, BeatCommandId.None });
        patterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.B, BeatCommandId.None, BeatCommandId.A,
                                               BeatCommandId.B, BeatCommandId.None, BeatCommandId.B, BeatCommandId.None });
        patterns.Add(new List<BeatCommandId> { BeatCommandId.A, BeatCommandId.A, BeatCommandId.A, BeatCommandId.A,
                                               BeatCommandId.B, BeatCommandId.None, BeatCommandId.B, BeatCommandId.None });
        patterns.Add(new List<BeatCommandId> { BeatCommandId.A, BeatCommandId.A, BeatCommandId.None, BeatCommandId.A,
                                               BeatCommandId.None, BeatCommandId.A, BeatCommandId.None, BeatCommandId.A });
        patterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.B, BeatCommandId.None, BeatCommandId.B,
                                               BeatCommandId.None, BeatCommandId.B, BeatCommandId.None, BeatCommandId.B });
        patterns.Add(new List<BeatCommandId> { BeatCommandId.A, BeatCommandId.B, BeatCommandId.B, BeatCommandId.A,
                                               BeatCommandId.A, BeatCommandId.B, BeatCommandId.None, BeatCommandId.B });
        patterns.Add(new List<BeatCommandId> { BeatCommandId.A, BeatCommandId.None, BeatCommandId.B, BeatCommandId.None,
                                               BeatCommandId.A, BeatCommandId.B, BeatCommandId.None, BeatCommandId.B });
        patterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.None, BeatCommandId.B, BeatCommandId.None,
                                               BeatCommandId.A, BeatCommandId.None, BeatCommandId.None, BeatCommandId.None });
        patterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.None, BeatCommandId.B, BeatCommandId.None,
                                               BeatCommandId.A, BeatCommandId.None, BeatCommandId.None, BeatCommandId.A });
        patterns.Add(new List<BeatCommandId> { BeatCommandId.A, BeatCommandId.None, BeatCommandId.B, BeatCommandId.A,
                                               BeatCommandId.None, BeatCommandId.A, BeatCommandId.B, BeatCommandId.None });
        patterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.B, BeatCommandId.B, BeatCommandId.B,
                                               BeatCommandId.A, BeatCommandId.A, BeatCommandId.B, BeatCommandId.None });
        patterns.Add(new List<BeatCommandId> { BeatCommandId.None, BeatCommandId.None, BeatCommandId.B, BeatCommandId.None,
                                               BeatCommandId.None, BeatCommandId.None, BeatCommandId.B, BeatCommandId.None });
        patterns.Add(new List<BeatCommandId> { BeatCommandId.None, BeatCommandId.None, BeatCommandId.A, BeatCommandId.None,
                                               BeatCommandId.None, BeatCommandId.None, BeatCommandId.A, BeatCommandId.None });
        patterns.Add(new List<BeatCommandId> { BeatCommandId.None, BeatCommandId.None, BeatCommandId.A, BeatCommandId.None,
                                               BeatCommandId.None, BeatCommandId.None, BeatCommandId.B, BeatCommandId.None });
        patterns.Add(new List<BeatCommandId> { BeatCommandId.None, BeatCommandId.None, BeatCommandId.B, BeatCommandId.None,
                                               BeatCommandId.None, BeatCommandId.None, BeatCommandId.A, BeatCommandId.None });
        patterns.Add(new List<BeatCommandId> { BeatCommandId.A, BeatCommandId.A, BeatCommandId.A, BeatCommandId.None,
                                               BeatCommandId.B, BeatCommandId.B, BeatCommandId.B, BeatCommandId.None });
        patterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.B, BeatCommandId.B, BeatCommandId.None,
                                               BeatCommandId.A, BeatCommandId.A, BeatCommandId.A, BeatCommandId.None });
        patterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.A, BeatCommandId.B, BeatCommandId.None,
                                               BeatCommandId.A, BeatCommandId.B, BeatCommandId.A, BeatCommandId.None });
        patterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.A, BeatCommandId.A, BeatCommandId.None,
                                               BeatCommandId.B, BeatCommandId.None, BeatCommandId.B, BeatCommandId.None });
        patterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.A, BeatCommandId.B, BeatCommandId.None,
                                               BeatCommandId.A, BeatCommandId.A, BeatCommandId.A, BeatCommandId.None });
        patterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.B, BeatCommandId.B, BeatCommandId.None,
                                               BeatCommandId.A, BeatCommandId.B, BeatCommandId.A, BeatCommandId.None });
        patterns.Add(new List<BeatCommandId> { BeatCommandId.A, BeatCommandId.None, BeatCommandId.B, BeatCommandId.None,
                                               BeatCommandId.A, BeatCommandId.B, BeatCommandId.None, BeatCommandId.A });
        patterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.None, BeatCommandId.A, BeatCommandId.None,
                                               BeatCommandId.B, BeatCommandId.A, BeatCommandId.None, BeatCommandId.B });
        patterns.Add(new List<BeatCommandId> { BeatCommandId.A, BeatCommandId.None, BeatCommandId.B, BeatCommandId.None,
                                               BeatCommandId.A, BeatCommandId.None, BeatCommandId.None, BeatCommandId.B });
        patterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.None, BeatCommandId.A, BeatCommandId.None,
                                               BeatCommandId.B, BeatCommandId.None, BeatCommandId.None, BeatCommandId.A });
        patterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.A, BeatCommandId.None, BeatCommandId.B,
                                               BeatCommandId.A, BeatCommandId.None, BeatCommandId.B, BeatCommandId.A });
        patterns.Add(new List<BeatCommandId> { BeatCommandId.A, BeatCommandId.B, BeatCommandId.None, BeatCommandId.A,
                                               BeatCommandId.B, BeatCommandId.None, BeatCommandId.A, BeatCommandId.B });
        patterns.Add(new List<BeatCommandId> { BeatCommandId.A, BeatCommandId.None, BeatCommandId.A, BeatCommandId.None,
                                               BeatCommandId.A, BeatCommandId.None, BeatCommandId.None, BeatCommandId.None });
        patterns.Add(new List<BeatCommandId> { BeatCommandId.A, BeatCommandId.None, BeatCommandId.B, BeatCommandId.None,
                                               BeatCommandId.A, BeatCommandId.None, BeatCommandId.None, BeatCommandId.None });
        patterns.Add(new List<BeatCommandId> { BeatCommandId.A, BeatCommandId.None, BeatCommandId.A, BeatCommandId.None,
                                               BeatCommandId.B, BeatCommandId.None, BeatCommandId.None, BeatCommandId.None });
        patterns.Add(new List<BeatCommandId> { BeatCommandId.A, BeatCommandId.None, BeatCommandId.B, BeatCommandId.None,
                                               BeatCommandId.B, BeatCommandId.None, BeatCommandId.None, BeatCommandId.None });
        patterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.None, BeatCommandId.B, BeatCommandId.None,
                                               BeatCommandId.B, BeatCommandId.None, BeatCommandId.None, BeatCommandId.None });
        patterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.None, BeatCommandId.A, BeatCommandId.None,
                                               BeatCommandId.B, BeatCommandId.None, BeatCommandId.None, BeatCommandId.None });
        patterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.None, BeatCommandId.B, BeatCommandId.None,
                                               BeatCommandId.A, BeatCommandId.None, BeatCommandId.None, BeatCommandId.None });
        patterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.None, BeatCommandId.A, BeatCommandId.None,
                                               BeatCommandId.A, BeatCommandId.None, BeatCommandId.None, BeatCommandId.None });
        patterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.None, BeatCommandId.A, BeatCommandId.None,
                                               BeatCommandId.None, BeatCommandId.B, BeatCommandId.None, BeatCommandId.A });
        patterns.Add(new List<BeatCommandId> { BeatCommandId.A, BeatCommandId.None, BeatCommandId.B, BeatCommandId.None,
                                               BeatCommandId.None, BeatCommandId.A, BeatCommandId.None, BeatCommandId.B });
        patterns.Add(new List<BeatCommandId> { BeatCommandId.A, BeatCommandId.None, BeatCommandId.None, BeatCommandId.A,
                                               BeatCommandId.None, BeatCommandId.A, BeatCommandId.None, BeatCommandId.A });
        patterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.None, BeatCommandId.None, BeatCommandId.B,
                                               BeatCommandId.None, BeatCommandId.B, BeatCommandId.None, BeatCommandId.B });
        patterns.Add(new List<BeatCommandId> { BeatCommandId.A, BeatCommandId.None, BeatCommandId.None, BeatCommandId.A,
                                               BeatCommandId.None, BeatCommandId.B, BeatCommandId.None, BeatCommandId.B });
        patterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.None, BeatCommandId.None, BeatCommandId.B,
                                               BeatCommandId.None, BeatCommandId.A, BeatCommandId.None, BeatCommandId.A });
        patterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.None, BeatCommandId.B, BeatCommandId.None,
                                               BeatCommandId.B, BeatCommandId.B, BeatCommandId.B, BeatCommandId.None });
        patterns.Add(new List<BeatCommandId> { BeatCommandId.A, BeatCommandId.None, BeatCommandId.A, BeatCommandId.None,
                                               BeatCommandId.A, BeatCommandId.A, BeatCommandId.A, BeatCommandId.None });
        patterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.None, BeatCommandId.B, BeatCommandId.None,
                                               BeatCommandId.B, BeatCommandId.None, BeatCommandId.B, BeatCommandId.B });
        patterns.Add(new List<BeatCommandId> { BeatCommandId.A, BeatCommandId.None, BeatCommandId.A, BeatCommandId.None,
                                               BeatCommandId.A, BeatCommandId.None, BeatCommandId.A, BeatCommandId.A });
        patterns.Add(new List<BeatCommandId> { BeatCommandId.B, BeatCommandId.None, BeatCommandId.B, BeatCommandId.B,
                                               BeatCommandId.B, BeatCommandId.None, BeatCommandId.B, BeatCommandId.None });
        patterns.Add(new List<BeatCommandId> { BeatCommandId.A, BeatCommandId.None, BeatCommandId.A, BeatCommandId.A,
                                               BeatCommandId.A, BeatCommandId.None, BeatCommandId.A, BeatCommandId.None });
    }

    public static List<BeatCommandId> GetRandomPattern()
    {
        return patterns[Random.Range(0, patterns.Count)];
    }
}
