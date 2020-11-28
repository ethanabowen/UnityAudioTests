public enum ScaleNote
{
    G,
    GSharp,
    A,
    ASharp,
    B,
    C,
    CSharp,
    D,
    DSharp,
    E,
    F,
    FSharp,
    G5
}

public static class ScaleNoteMethods
{
    public static ScaleNote GetNextChromatic(ScaleNote current)
    {
        ScaleNote next = ScaleNote.G;
        switch (current)
        {
            case ScaleNote.G:
                next = ScaleNote.GSharp;
                break;
            case ScaleNote.GSharp:
                next = ScaleNote.A;
                break;
            case ScaleNote.A:
                next = ScaleNote.ASharp;
                break;
            case ScaleNote.ASharp:
                next = ScaleNote.B;
                break;
            case ScaleNote.B:
                next = ScaleNote.C;
                break;
            case ScaleNote.C:
                next = ScaleNote.CSharp;
                break;
            case ScaleNote.CSharp:
                next = ScaleNote.D;
                break;
            case ScaleNote.D:
                next = ScaleNote.DSharp;
                break;
            case ScaleNote.DSharp:
                next = ScaleNote.E;
                break;
            case ScaleNote.E:
                next = ScaleNote.F;
                break;
            case ScaleNote.F:
                next = ScaleNote.FSharp;
                break;
            case ScaleNote.FSharp:
                next = ScaleNote.G5;
                break;
        }

        return next;
    }
}