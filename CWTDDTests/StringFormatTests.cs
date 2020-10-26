using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using Xunit;

namespace CWTDDTests
{
    public class StringFormatTests
    {
        [Theory]
        [InlineData(0, "00:00:00")]
        [InlineData(5, "00:00:05")]
        [InlineData(60, "00:01:00")]
        [InlineData(86399, "23:59:59")]
        [InlineData(359999, "99:59:59")]
        public void StringFormat_TimeInSecunds_ReturnsFormatedTime(int input, string expected)
        {
            StringFormatter sf = new StringFormatter();
            string result = sf.GetReadableTime(input);
            Assert.Equal(expected, result);
            Assert.Equal(expected, result);
            Assert.Equal(expected, result);
            Assert.Equal(expected, result);
            Assert.Equal(expected, result);

        }
    }

    internal class StringFormatter
    {
        internal string GetReadableTime(int input)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(input);

            return string.Format("{0:D2}:{1:D2}:{2:D2}",
                                    (int)timeSpan.TotalHours,
                                    timeSpan.Minutes,
                                    timeSpan.Seconds);
        }
    }
}
