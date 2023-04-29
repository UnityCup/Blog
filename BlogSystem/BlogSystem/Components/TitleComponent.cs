namespace UnityCup.BlogSystem.Components;

public class TitleComponent : IBlogComponent
{
    public readonly string title;

    public TitleComponent(string title)
    {
        this.title = title;
    }

    public string Build()
        => $"<h1 id=\"articlePageTitle\">{title}</h1>";
}