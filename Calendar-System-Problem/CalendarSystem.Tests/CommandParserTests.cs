using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalendarSystem.Parser;

namespace CalendarSystem.Tests
{
    [TestClass]
    public class CommandParserTests
    {
        private ICommandParser parser;

        [TestInitialize]
        public void GetParserInstance()
        {
            this.parser = new CommandParser();
        }

        [TestMethod]
        public void PassValidAddCommandStringShouldReturnValidCommand()
        {
            string addCmd = "AddEvent 2012-01-21T20:00:00 | party Viki | home";

            var addCmdResult = this.parser.Parse(addCmd);

            Assert.AreEqual("AddEvent", addCmdResult.Name);
            Assert.AreEqual(3, addCmdResult.Params.Count);
        }

        [TestMethod]
        public void PassValidDeleteCommandStringShouldReturnValidCommand()
        {
            string delCmd = "DeleteEvents c# exam";

            var delCmdResult = this.parser.Parse(delCmd);

            Assert.AreEqual("DeleteEvents", delCmdResult.Name);
            Assert.AreEqual(1, delCmdResult.Params.Count);

        }

        [TestMethod]
        public void PassValidListCommandStringShouldReturnValidCommand()
        {
            string listCmd = "ListEvents 2012-03-07T08:00:00 | 2";

            var listCmdResult = this.parser.Parse(listCmd);

            Assert.AreEqual("ListEvents", listCmdResult.Name);
            Assert.AreEqual(2, listCmdResult.Params.Count);
        }

        [TestMethod]
        public void PassAStringAlwaysShouldReturnCommandName()
        {
            string cmd = "AddEventPesho 2012-01-21T20:00:00 | party Viki | home";

            var result = this.parser.Parse(cmd);

            Assert.AreEqual("AddEventPesho", result.Name);
        }
    }
}