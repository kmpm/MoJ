using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoJ
{
    public class Task
    {

        ActionCollection _actions;

        public Task()
        {
            _actions = new ActionCollection();
        }

        public ActionCollection Actions
        {
            get { return _actions; }
        }
    }
}
