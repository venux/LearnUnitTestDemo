using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeTest
{
    public class FakeDemo
    {
        public DateTime BeginTime { get; set; }

        public FakeDemo()
        {
            this.BeginTime = new DateTime(2014, 3, 3);
        }

        public bool IsExpire()
        {
            return BeginTime >= DateTime.Now;
        }

        public IFake Fake { get; set; }

        public FakeDemo(IFake fake)
        {
            Fake = fake;
        }

        public string TestStub()
        {
            return Fake.Test();
        }
    }
}
