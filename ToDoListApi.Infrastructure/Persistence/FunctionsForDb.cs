//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;

//namespace ToDoListApi.Infrastructure.Persistence
//{
//    internal class FunctionsForDb
//    {
//        private readonly ToDoListDbContext _context;

//        public FunctionsForDb(ToDoListDbContext context)
//        {
//            _context = context;
//        }

//        public async Task SetIdentityInsertAsync(bool enable)
//        {
//            var tables = new List<string> { "Priorities", "Statuses", "ToDoTasks" };
//            string state = enable ? "ON" : "OFF";

//            foreach (var table in tables)
//            {
//                await _context.Database.ExecuteSqlRawAsync($"SET IDENTITY_INSERT {table} {state}");
//            }
//        }
//    }
//}