using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chirp;

namespace ChirpTest
{
    [TestClass]
    public class ChirpMessageBusTest
    {
        private class TestSubscriber1 : ISubscriber<TestMessage1>
        {
            public bool handlerWasExecuted;

            public void Receive(TestMessage1 message)
            {
                handlerWasExecuted = true;
            }
        }

        private class TestSubscriber2 : ISubscriber<TestMessage2>
        {
            public bool handlerWasExecuted;

            public void Receive(TestMessage2 message)
            {
                handlerWasExecuted = true;
            }
        }

        private class TestMessage1 : IMessage
        {
        }

        private class TestMessage2 : IMessage
        {
        }

        [TestMethod]
        public void TestMultipleBussesNotInterferingWithEachother()
        {
            var subscriber1 = new TestSubscriber1();
            var subscriber2 = new TestSubscriber2();

            MessageBusOf<TestMessage1>.AcceptSubscriber(subscriber1);
            MessageBusOf<TestMessage2>.AcceptSubscriber(subscriber2);

            MessageBusOf<TestMessage2>.Receive(new TestMessage2());
            Assert.IsTrue(subscriber2.handlerWasExecuted);
            Assert.IsFalse(subscriber1.handlerWasExecuted);

            // reset sub2's status
            subscriber2.handlerWasExecuted = false;

            MessageBusOf<TestMessage1>.Receive(new TestMessage1());
            Assert.IsFalse(subscriber2.handlerWasExecuted);
            Assert.IsTrue(subscriber1.handlerWasExecuted);
        }

        [TestMethod]
        public void TestMultipleSubscribersAllReceivingTheMessage()
        {
            var subscriber1 = new TestSubscriber1();
            var subscriber2 = new TestSubscriber1();

            MessageBusOf<TestMessage1>.AcceptSubscriber(subscriber1);
            MessageBusOf<TestMessage1>.AcceptSubscriber(subscriber2);

            MessageBusOf<TestMessage1>.Receive(new TestMessage1());

            Assert.IsTrue(subscriber1.handlerWasExecuted);
            Assert.IsTrue(subscriber2.handlerWasExecuted);
        }
    }
}
