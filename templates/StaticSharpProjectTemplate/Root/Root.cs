using StaticSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticSharpProjectTemplate.Root
{
    [Representative]
    public partial class Root: Page
    {
        public override string PageLanguage => "English (USA)";

        public override string Title => "StaticSharpProjectTemplate - Home page";

        public override object? MainVisual => "Home page";

        public override Inlines? Description => "Home page of StaticSharp sample project";

        public override Blocks UnmanagedChildren => new() { "Hello, world!" };
    }
}
