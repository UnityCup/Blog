using System.Collections.ObjectModel;

namespace UnityCup.BlogSystem.Components;

public class PageComponent : IBlogComponent
{
    public readonly ReadOnlyCollection<IBlogComponent> blogComponents;

    public PageComponent(IList<IBlogComponent> blogComponents)
    {
        this.blogComponents = new(blogComponents);
    }

    public string Build()
        => $"<div id=\"pageContainer\"><div id=\"articlePageContents\">{string.Join("", blogComponents.Select(component => component.Build()))}</div></div>";
}