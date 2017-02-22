using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeTest;

namespace UnitTestDemo
{
    public class Demo
    {
        public string BaseMethod(string str)
        {
            return str;
        }

        public void ExceptionMethod()
        {
            throw new NullReferenceException("测试抛出异常");
        }
        
        public void NoExceptionMethod()
        {
           
        }

        public void GenerateMethod()
        {
            throw new NotImplementedException();
        }

        //public string FakeMethod(IFake fake)
        //{
        //    fake=new FakeDemo();
        //    return fake.Test();
        //}
    }
}
