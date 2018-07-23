using Gemini.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using Gemini.Modules.Explorer.Modules.SolutionExplorer.ViewModels;

namespace Gemini.Modules.Explorer
{
   [Export(typeof(IModule))]
   class Module : ModuleBase
   {
      public override void Initialize()
      {
         base.Initialize();
         Shell.Tools.Add(new SolutionExplorerViewModel());
      }
   }
}
