using BusinessLayer.Utilities;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;
namespace CrudTesting
{
    public class LoggingTest
    {
        [Fact]
        public void LogInfo_ShouldLogResult()
        {
            string fileName = @"C:\Users\Muhammad Talha\source\repos\StudentManageSystem\TestLogs.txt";

            ILogInfo log = new LogInfo();
            string message = "Logged to test file";

            log.LogToFile(message, fileName);

            Assert.True(File.Exists(fileName));
            File.Delete(fileName);

        }
    }
}
