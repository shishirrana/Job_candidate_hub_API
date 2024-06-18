using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma.Services.Common
{
    public class IResult<t>
    {
        public t? Data { get; set; }
        public ResultStatus Status { get; set; }
        public string? Message { get; set; }
    }
    public enum ResultStatus
    {
        Failure,
        Success
    }
}
