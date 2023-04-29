namespace UnityCup.BlogSystem.Components;

public class PragraphComponent : IBlogComponent
{
    public readonly SentenceComponent sentenceComponent;

    public PragraphComponent(SentenceComponent sentenceComponent)
    {
        this.sentenceComponent = sentenceComponent;
    }

    public string Build()
        => $"<p class=\"articlePragraph\">{sentenceComponent.Build()}</p>";
}