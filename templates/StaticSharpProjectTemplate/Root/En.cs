using StaticSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticSharpProjectTemplate.Root
{
    [Representative]
    public partial class En : Page
    {
        public override string PageLanguage => "English (USA)";

        public override string Title => "StaticSharpProjectTemplate - Home page";

        public override object? MainVisual => "Home page";

        public override Inlines? Description => "Home page of StaticSharp sample project";

        protected override Blocks BodyContent => new() { "Hello, world!" };
    }
}
