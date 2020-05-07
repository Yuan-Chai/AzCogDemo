using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IHttpClient
    {
        Task<T> PostAync<T>(string content);
    }
}
