namespace UnityCup.MarkdownParser;

public enum TokenType
{
    Sentence, // 文章とかタイトルの文字とか
    Sharp, // h1とかh2に使うやつ

    Illegal,
    EOF
}