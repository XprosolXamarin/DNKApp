using System;
using System.Collections.Generic;
using System.Text;

namespace DNKApp.Helpers
{
    public interface IMessage
    {
        void Longtime(string message);
        void Shorttime(string message);
    }
}
