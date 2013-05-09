// Copyright (C) 2013 Peter Magnusson
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoJ
{
    public class Task
    {

        ActionCollection _actions;

        public String Name { get; set; }
        public String Description { get; set; }

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
