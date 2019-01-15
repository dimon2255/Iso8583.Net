﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenIso8583Net.Formatter;
using OpenIso8583Net.TermAppIso;

namespace OpenIso8583Net.Tests.TermAppIso
{
    [TestClass]
    public class TermAppIsoPackTests
    {
        [TestMethod]
        public void PackStructuredData()
        {
            Iso8583TermApp msg = new Iso8583TermApp();
            msg.MessageType = Iso8583TermApp.MsgType._1200_TRAN_REQ;
            msg[Iso8583TermApp.Bit._011_SYS_TRACE_AUDIT_NUM] = "123456";
            HashtableMessage sd = new HashtableMessage();
            sd.Add("key", "value");
            msg.StructuredData = sd;

            String actual = Formatters.Binary.GetString(msg.ToMsg());
            String expected = "4231323030002000000001000031323334353630303231F0002100013030313231336B6579313576616C7565";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PackIccData()
        {
            Iso8583TermApp msg = new Iso8583TermApp();
            msg.MessageType = Iso8583TermApp.MsgType._1200_TRAN_REQ;
            msg[Iso8583TermApp.Bit._011_SYS_TRACE_AUDIT_NUM] = "123456";

            msg[Iso8583TermApp.Bit._055_ICC_DATA] = "FF208201139F400C3030303030303030303930309F2610354134373043413041434439453733368204354330309F0704464630309F3604303030315F201A56495341204143515549524552205445535420434152442032359F34063145303330309F27023830840E41303030303030303033313031309F060E41303030303030303033313031309F0D0A463034303030383830309F0E0A303031303030303030309F0F0A463034303030393830309F100E30363031304130334130303030305F2804303834305F34009F120F4352454449544F204445205649534199009F33064530423043389F1A04303732349F090A303030303030383030305F2A04303937389A063134303330359C0230309F37083337334144313437";

            var actual = Formatters.Binary.GetString(msg.ToMsg());
            var expected = "42313230300020000000000200313233343536323830FF208201139F400C3030303030303030303930309F2610354134373043413041434439453733368204354330309F0704464630309F3604303030315F201A56495341204143515549524552205445535420434152442032359F34063145303330309F27023830840E41303030303030303033313031309F060E41303030303030303033313031309F0D0A463034303030383830309F0E0A303031303030303030309F0F0A463034303030393830309F100E30363031304130334130303030305F2804303834305F34009F120F4352454449544F204445205649534199009F33064530423043389F1A04303732349F090A303030303030383030305F2A04303937389A063134303330359C0230309F37083337334144313437";

            Assert.AreEqual(expected, actual);
        }
    }
}
