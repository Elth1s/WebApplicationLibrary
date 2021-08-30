using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_Урок_2.Data.Services
{
    public class LogsService
    {
        private AppDbContext _context;
        public LogsService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<WebApplication_Урок_2.Data.Models.Log> GetAllLogsFromDB()
        {
            return _context.Logs;
        }

        
    }
}
