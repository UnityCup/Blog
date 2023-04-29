using UnityCup.BlogSystem.Components;

namespace UnityCup.BlogSystem;

public class BlogBuilder
{
    public readonly TitleContainerComponent titleContainerComponent;
    public readonly PageComponent pageComponent;

    public BlogBuilder(TitleContainerComponent titleContainerComponent, PageComponent pageComponent)
    {
        this.titleContainerComponent = titleContainerComponent;
        this.pageComponent = pageComponent;
    }

    public string Build()
        =>
@"<!DOCTYPE html>
<html lang=""jp"">
<head>
    <meta charset = ""UTF-8"" >
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
    <meta name = ""viewport"" content=""width=device-width, initial-scale=1.0"">
    <link rel = ""stylesheet"" href=""css/style.css"">
    <link rel = ""preconnect"" href=""https://fonts.googleapis.com"">
    <link rel = ""preconnect"" href=""https://fonts.gstatic.com"" crossorigin>
    <link href = ""https://fonts.googleapis.com/css2?family=Zen+Kaku+Gothic+New:wght@300;400;500;700;900&display=swap""
        rel=""stylesheet"">
    <title>" +
    titleContainerComponent.titleComponent.title +
@"</title>
</head>
<body>
    <header id=""header"">
        <ul id = ""headerContainer"" >
            <a href=""./index.html"" id=""headerLogo"">
                <img id = ""headerUnityCupLogo"" src=""img/UnityCupLogo.png"" alt=""UnityCupのLogo"">
            </a>
        </ul>
    </header>" +
    titleContainerComponent.Build() +
    pageComponent.Build() +
"</body></html>";
}