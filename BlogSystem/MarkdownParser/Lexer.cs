﻿namespace UnityCup.MarkdownParser;

public class Lexer
{
    public readonly string source;
    public int currentPosition { get; private set; }
    public char currentChar
    {
        get
        {
            if (source.Length <= currentPosition) return ' ';
            return source[currentPosition];
        }
    }
    public char nextChar
    {
        get
        {
            if (source.Length <= currentPosition + 1) return ' ';
            return source[currentPosition + 1];
        }
    }

    public Lexer(string source)
    {
        this.source = source;
    }

    public void NextChar()
    {
        currentPosition++;
    }

    public Token NextToken()
    {

    }
}
