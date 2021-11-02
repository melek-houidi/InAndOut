using InAndOut.Data;
using InAndOut.Models;
using InAndOut.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Services
{
    public class Service : IRepository
    {
        private readonly ApplicationDbContext _context;
        public Service(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Item> Items { get; set; } = new List<Item>();
        public List<Expense> Expenses { get; set; } = new List<Expense>();
        public List<ExpenseType> ExpenseTypes { get; set; } = new List<ExpenseType>();

        public Item Create(Item obj)
        {
            _context.Items.Add(obj);
            _context.SaveChanges();
            return obj;
        }

        public Expense Create(Expense EXP)
        {
            _context.Expenses.Add(EXP);
            _context.SaveChanges();
            return EXP;
        }

        public Expense Delete(Expense expense)
        {
            _context.Expenses.Attach(expense);
            _context.Entry(expense).State = EntityState.Deleted;
            _context.SaveChanges();
            return expense;
        }

        public Expense Edit(Expense expense)
        {
            _context.Expenses.Attach(expense);
            _context.Entry(expense).State = EntityState.Modified; //update the echange
            _context.SaveChanges();
            return expense;
        }

        public List<Item> GetItems()
        {
            List<Item> item = _context.Items.ToList();
            return item;
        }
    }
}

