using System;
using System.Fakes;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using FakeTest;
using FakeTest.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestDemo;

namespace MSUnitTest
{
    [TestClass]
    public class TestDemo
    {
        [TestMethod]
        public void TestBaseMethodOfTrue()
        {
            Assert.AreEqual(new Demo().BaseMethod("Hello"), "Hello");
        }

        [TestMethod]
        public void TestBaseMethodOfFalse()
        {
            Assert.AreEqual(new Demo().BaseMethod("Hello"), "Hello1");
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "未抛出异常")]
        public void TestExceptionMethod()
        {
            new Demo().ExceptionMethod();
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "未抛出异常")]
        public void TestExceptionMethod2()
        {
            new Demo().NoExceptionMethod();
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "未抛出异常")]
        public void TestExceptionMethod3()
        {
            new Demo().GenerateMethod();
        }

        [TestMethod]
        public void TestFakeMethod()
        {
            //stub用于我们可控的代码，shim用于不可控的
            FakeDemo fakeDemo = new FakeDemo();
            Assert.IsFalse(fakeDemo.IsExpire());

            using (ShimsContext.Create())
            {
                ShimDateTime.NowGet = () => new DateTime(2014,1, 1);
               Assert.IsTrue(fakeDemo.IsExpire());
            }

            //只有遵循依赖反转与接口隔离原则的代码才好使用Stub填充外部依赖
            StubIFake fake =new StubIFake();
            FakeDemo fakeDemo2=new FakeDemo(fake);
            fake.Test = () => "Stub";

            Assert.AreEqual(fakeDemo2.TestStub(), "Stub");
        }
    }
}
