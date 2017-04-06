using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellPattern : IEquatable<SpellPattern>
{

    public List<PatternLine> Lines { get; set; }

    public SpellPattern()
    {
        Lines = new List<PatternLine>();
    }
    public SpellPattern(List<SpellLine> spellLines)
    {
        Lines = new List<PatternLine>();
        foreach (SpellLine spellLine in spellLines)
        {
            Lines.Add(new PatternLine(spellLine));
        }
    }

    public override string ToString()
    {
        string str = "";
        foreach (PatternLine line in Lines)
        {
            str += string.Format("[({0},{1})->({2},{3})] ", line.Start.x, line.Start.y,
            line.End.x, line.End.y);
        }
        return str;
    }

    public bool Equals(SpellPattern spellPattern)
    {
        int lineCount;
        int otherCount;
        bool areEqual = true;
        if (Lines.Count != spellPattern.Lines.Count)
        {
            return false;
        }
        foreach (PatternLine line in Lines)
        {
            lineCount = Lines.FindAll(delegate (PatternLine patternLine) { return line.Equals(patternLine); }).Count;
            otherCount = spellPattern.Lines.FindAll(delegate (PatternLine patternLine) { return line.Equals(patternLine); }).Count;

            if (lineCount != otherCount)
            {
                areEqual = false;
            }
        }

        return areEqual;
    }

}

public class PatternLine : IEquatable<PatternLine>
{
    public Vector2 Start;
    public Vector2 End;

    #region Ready lines
    public static PatternLine OneTwo
    {
        get
        {
            return new PatternLine()
            {
                Start = new Vector2(1,1),
                End = new Vector2(2,1)
            };
        }
    }
    public static PatternLine OneFour
    {
        get
        {
            return new PatternLine()
            {
                Start = new Vector2(1, 1),
                End = new Vector2(1, 2)
            };
        }
    }
    public static PatternLine OneFive
    {
        get
        {
            return new PatternLine()
            {
                Start = new Vector2(1, 1),
                End = new Vector2(2, 2)
            };
        }
    }
    public static PatternLine OneSix
    {
        get
        {
            return new PatternLine()
            {
                Start = new Vector2(1, 1),
                End = new Vector2(3, 2)
            };
        }
    }
    public static PatternLine OneEight
    {
        get
        {
            return new PatternLine()
            {
                Start = new Vector2(1, 1),
                End = new Vector2(2, 3)
            };
        }
    }
    public static PatternLine TwoThree
    {
        get
        {
            return new PatternLine()
            {
                Start = new Vector2(2, 1),
                End = new Vector2(3, 1)
            };
        }
    }
    public static PatternLine TwoFour
    {
        get
        {
            return new PatternLine()
            {
                Start = new Vector2(2, 1),
                End = new Vector2(1, 2)
            };
        }
    }
    public static PatternLine TwoFive
    {
        get
        {
            return new PatternLine()
            {
                Start = new Vector2(2, 1),
                End = new Vector2(2, 2)
            };
        }
    }
    public static PatternLine TwoSix
    {
        get
        {
            return new PatternLine()
            {
                Start = new Vector2(2, 1),
                End = new Vector2(3, 2)
            };
        }
    }
    public static PatternLine TwoSeven
    {
        get
        {
            return new PatternLine()
            {
                Start = new Vector2(2, 1),
                End = new Vector2(1, 3)
            };
        }
    }
    public static PatternLine TwoNine
    {
        get
        {
            return new PatternLine()
            {
                Start = new Vector2(2, 1),
                End = new Vector2(3, 3)
            };
        }
    }
    public static PatternLine ThreeFour
    {
        get
        {
            return new PatternLine()
            {
                Start = new Vector2(3, 1),
                End = new Vector2(1, 2)
            };
        }
    }
    public static PatternLine ThreeFive
    {
        get
        {
            return new PatternLine()
            {
                Start = new Vector2(3, 1),
                End = new Vector2(2, 2)
            };
        }
    }
    public static PatternLine ThreeSix
    {
        get
        {
            return new PatternLine()
            {
                Start = new Vector2(3, 1),
                End = new Vector2(3, 2)
            };
        }
    }
    public static PatternLine ThreeEight
    {
        get
        {
            return new PatternLine()
            {
                Start = new Vector2(3, 1),
                End = new Vector2(2, 3)
            };
        }
    }
    public static PatternLine FourFive
    {
        get
        {
            return new PatternLine()
            {
                Start = new Vector2(1, 2),
                End = new Vector2(2, 2)
            };
        }
    }
    public static PatternLine FourSeven
    {
        get
        {
            return new PatternLine()
            {
                Start = new Vector2(1, 2),
                End = new Vector2(1, 3)
            };
        }
    }
    public static PatternLine FourEight
    {
        get
        {
            return new PatternLine()
            {
                Start = new Vector2(1, 2),
                End = new Vector2(2, 3)
            };
        }
    }
    public static PatternLine FourNine
    {
        get
        {
            return new PatternLine()
            {
                Start = new Vector2(1, 2),
                End = new Vector2(3, 3)
            };
        }
    }
    public static PatternLine FiveSix
    {
        get
        {
            return new PatternLine()
            {
                Start = new Vector2(2, 2),
                End = new Vector2(3, 2)
            };
        }
    }
    public static PatternLine FiveSeven
    {
        get
        {
            return new PatternLine()
            {
                Start = new Vector2(2, 2),
                End = new Vector2(1, 3)
            };
        }
    }
    public static PatternLine FiveEight
    {
        get
        {
            return new PatternLine()
            {
                Start = new Vector2(2, 2),
                End = new Vector2(2, 3)
            };
        }
    }
    public static PatternLine FiveNine
    {
        get
        {
            return new PatternLine()
            {
                Start = new Vector2(2, 2),
                End = new Vector2(3, 3)
            };
        }
    }
    public static PatternLine SixSeven
    {
        get
        {
            return new PatternLine()
            {
                Start = new Vector2(3, 2),
                End = new Vector2(1, 3)
            };
        }
    }
    public static PatternLine SixEight
    {
        get
        {
            return new PatternLine()
            {
                Start = new Vector2(3, 2),
                End = new Vector2(2, 3)
            };
        }
    }
    public static PatternLine SixNine
    {
        get
        {
            return new PatternLine()
            {
                Start = new Vector2(3, 2),
                End = new Vector2(3, 3)
            };
        }
    }
    public static PatternLine SevenEight
    {
        get
        {
            return new PatternLine()
            {
                Start = new Vector2(1, 3),
                End = new Vector2(2, 3)
            };
        }
    }
    public static PatternLine EightNine
    {
        get
        {
            return new PatternLine()
            {
                Start = new Vector2(2, 3),
                End = new Vector2(3, 3)
            };
        }
    }
    #endregion


    public PatternLine()
    {
        Start = Vector2.zero;
        End = Vector2.zero;
    }
    public PatternLine(SpellLine spellLine)
    {
        Start = spellLine.Start.Position;
        End = spellLine.End.Position;
    }



    public bool Equals(PatternLine patternLine)
    {
        if (Start == patternLine.Start &&
            End == patternLine.End) { return true; }
        else if (Start == patternLine.End &&
            End == patternLine.Start) { return true; }
        return false;
    }



}




