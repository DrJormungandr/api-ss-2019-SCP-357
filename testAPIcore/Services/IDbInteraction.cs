using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testAPIcore.Models;

namespace testAPIcore.Services
{
    public interface IDbInteraction
    {
        Task<IEnumerable<Page>> GetPages();
        Task<Page> GetPage(int id);
        Task<bool> PostPage(Page page);
        Task<bool> PutPage(int id, Page page);
        Task<bool> DeletePage(int id);
    }
}
