using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HACPM.Validators
{
    public class AccountSegmentValidator : BaseValidator
    {
        private readonly ISegmentRepository segmentRepository;
        public AccountSegmentValidator(ISegmentRepository segmentRepository)
        {
            this.segmentRepository = segmentRepository;
        }

        public override bool IsValid(int rowId, string header, string value)
        {
            if (segmentRepository.Get(value) != null)
            {
                return true;
            }
            else
            {
                AddRowError(rowId, value);
                return false;
            }
        }
    }
}
