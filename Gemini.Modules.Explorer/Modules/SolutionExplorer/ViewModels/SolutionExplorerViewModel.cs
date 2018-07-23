using Gemini.Framework;
using Gemini.Framework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gemini.Modules.Explorer.Modules.SolutionExplorer.ViewModels
{
   class SolutionExplorerViewModel : Tool
   {
      public override PaneLocation PreferredLocation => PaneLocation.Left;
      public string Location { get; set; } = @"C:\Program Files (x86)";
   }
}
