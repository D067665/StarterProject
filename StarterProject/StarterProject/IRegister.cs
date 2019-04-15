using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarterProject
{
    public interface IRegister
    {
        Task<string> registerWithEmailPassword(string email, string password);
    }
}
