using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HACPM.Validators
{
    public interface ISegmentRepository
    {
        AccountSegment Get(string code);
    }

    public class SegmentRepository : ISegmentRepository
    {

        public AccountSegment Get(string code)
        {
            return new AccountSegment()
            {
                Id = 10,
                Code = code
            };
        }
    }

    public class AccountSegment
    {
        public int Id { get; set; }
        public string Code { get; set; }
    }
}
