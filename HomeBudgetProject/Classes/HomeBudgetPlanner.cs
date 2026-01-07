using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeBudgetProject.Enums;
using HomeBudgetProject.Interfaces;

namespace HomeBudgetProject.Classes
{
    public class HomeBudgetPlanner : IHomeBudgetPlanner
    {
        private List<IBudgetObserver> observers = new List<IBudgetObserver>();
        public List<BudgetItem> budgetItemsList = new List<BudgetItem>();
        public IRaportStrategy raportStrategy;
        private BudgetGroup expensesGroup;
        private BudgetGroup incomeGroup;

        public HomeBudgetPlanner()
        {
            incomeGroup = new BudgetGroup(Enums.CategoryType.Przychody);
            expensesGroup = new BudgetGroup(Enums.CategoryType.WszystkieWydatki);

            foreach (CategoryType category in Enum.GetValues(typeof(CategoryType)))
            {
                if (category == CategoryType.Przychody || category == CategoryType.WszystkieWydatki) continue;

                BudgetGroup group = new BudgetGroup(category);
                expensesGroup.Add(group);
            }

            budgetItemsList.Add(incomeGroup);
            budgetItemsList.Add(expensesGroup);
        }
        public void AddExpense(Expense item)
        {
            BudgetGroup pomGroup = null;

            foreach (BudgetGroup element in expensesGroup.budgetItemList)
            {
                if (item.Category == element.Category)
                {
                    pomGroup = element;
                    break;
                }
            }      
                pomGroup.Add(item);
                Logger.GetInstance().Log($"Dodano wydatek: {item.Name}.");
                Notify();
        }

        public void AddIncome(Income item)
        {
            incomeGroup.Add(item);
            Logger.GetInstance().Log($"Dodano przychód.");
            Notify();
        }

        public void Attach(IBudgetObserver observer)
        {
            throw new NotImplementedException();
        }

        public void Detach(IBudgetObserver observer)
        {
            throw new NotImplementedException();
        }

        public void GenerateRaport()
        {
            throw new NotImplementedException();
        }

        public void Notify()
        {
            throw new NotImplementedException();
        }

        public void SetStrategy(IRaportStrategy strategy)
        {
            throw new NotImplementedException();
        }
    }
}
