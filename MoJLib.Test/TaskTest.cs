using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoJ;
using Newtonsoft.Json;

namespace MoJLib.Test
{
    [TestClass]
    public class TaskTest
    {

        
        
        
        [TestMethod]
        [DeploymentItem("testtask.json")]
        public void SerializeTask()
        {
            string expected = System.IO.File.ReadAllText("testtask.json");

            Task t = new Task
            {
                Name ="Testtask",
                Description="For testing only"
            };
            t.Actions.Add(new MoJ.Action
            {
                Method = ActionMethod.KeyDown,
                Delay = 1000,
                Data = "@shift"
            });
            t.Actions.Add(new MoJ.Action{
                Method = ActionMethod.MouseButtonDown,
                Data="@left"
            });

            string output = MoJ.Config.Serialize(t);
            
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        [DeploymentItem("testtask.json")]
        public void DeserializeTask()
        {
            string expected = System.IO.File.ReadAllText("testtask.json");
            var t = JsonConvert.DeserializeObject<Task>(expected);
            Assert.AreEqual("Testtask", t.Name);
            Assert.AreEqual("For testing only", t.Description);
        }
    }
}
