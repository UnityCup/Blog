namespace UnityCup.BlogSystem.Components;

public class TitleIconComponent : IBlogComponent
{
    public readonly string icon;

    public TitleIconComponent(string icon)
    {
        this.icon = icon;
    }

    public string Build()
        => $"<div id=\"articlePageIconHolder\"> <img src=\"https://emoji2svg.deno.dev/api/{icon}\" id=\"articlePageIcon\"></div>";
}