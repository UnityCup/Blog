namespace UnityCup.BlogSystem.Components;

public class HeadLineComponent : IBlogComponent
{
    public readonly SentenceComponent sentenceComponent;

    public HeadLineComponent(SentenceComponent sentenceComponent)
    {
        this.sentenceComponent = sentenceComponent;
    }

    public string Build()
        => $"<h2 class=\"articleHeadLine\">{sentenceComponent.Build()}</h2>{new HorizontalLineComponent().Build()}";
}