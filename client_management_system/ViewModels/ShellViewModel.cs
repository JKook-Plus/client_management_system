using Caliburn.Micro;
using client_management_system.Models;
using client_management_system.Properties;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client_management_system.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        
        public ShellViewModel()
        {

        }
        public void LoadPageOne()
        {
            ActivateItem(new FirstChildViewModel());
        }

        public void LoadPageTwo()
        {
            ActivateItem(new SecondChildViewModel());
        }
    }
}
