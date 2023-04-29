namespace UnityCup.BlogSystem.Components;

public class TitleContainerComponent : IBlogComponent
{
    public readonly TitleComponent titleComponent;
    public readonly TitleIconComponent titleIconComponent;

    public TitleContainerComponent(TitleComponent titleComponent, TitleIconComponent titleIconComponent)
    {
        this.titleComponent = titleComponent;
        this.titleIconComponent = titleIconComponent;
    }

    public string Build()
        => $"<div id=\"articlePageTitleContainer\">{titleIconComponent.Build()}{titleComponent.Build()}</div>";
}