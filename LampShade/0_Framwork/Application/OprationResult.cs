using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framwork.Application
{
    public class OprationResult
    {
        public string Message { get; set; }
        public bool IsSucsseded { get; set; }

        public OprationResult()
        {
            IsSucsseded = false;
        }

        public OprationResult Sucsseded(string message="عملیات با موفقیت انجام شد")
        {
            this.IsSucsseded = true;
            this.Message = message;
            return this;
        }
        public OprationResult Feiled(string messege)
        {
            this.IsSucsseded = false;
            this.Message = messege;
            return this;
        }
    }
}
