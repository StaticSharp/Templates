using StaticSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticSharpProjectTemplate.Root
{
    [Representative]
    public partial class Ru : Page
    {
        public override string PageLanguage => "Русский";

        public override string Title => "StaticSharpProjectTemplate - Домашняя страница";

        public override object? MainVisual => "Home page";

        public override Inlines? Description => "Домашняя страница примера проекта на StaticSharp";

        protected override Blocks BodyContent => new() { "Привет, мир!" };
    }
}
