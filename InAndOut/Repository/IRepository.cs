using InAndOut.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Repository
{
    public interface IRepository
    {
        List<Item> Items { get; set; }
        List<Item> GetItems();
        Item Create(Item obj);

        List<Expense> Expenses { get; set; }
        Expense Create(Expense EXP);
        Expense Edit(Expense expense);
        Expense Delete(Expense expense );

        List<ExpenseType> ExpenseTypes { get; set; }
    }
}
