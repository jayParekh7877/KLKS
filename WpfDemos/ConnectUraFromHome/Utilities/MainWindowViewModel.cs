using System.Collections.Generic;

namespace Utilities
{
    internal class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            Branches = BranchOprations.GetBranchs();
        }


        public List<Branch> Branches { get; }

    }
}