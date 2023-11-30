using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //this: class'ın kendisinden bahseder.
        public Result(bool success, string message):this(success)
        {
           Message = message; //getter ile sınırlandırdık constructor kullanarak yapıyı standardize ettik.
        }

        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; } //get olduğu için 

        public string Message {  get; } 
    }
}
