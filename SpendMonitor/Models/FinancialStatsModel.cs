﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpendMonitor.Models
{
    public class FinancialStatsModel
    {
        [DisplayName("Avg. Monthly Expense: ")]
        [DataType(DataType.Currency)]
        public decimal AverageMonthlyExpense { get; set; }


        [DisplayName("Total Expense This Month: ")]
        [DataType(DataType.Currency)]
        public decimal TotalCurrentMonthExpense { get; set; }

        [DisplayName("Total Expense Last Month: ")]
        [DataType(DataType.Currency)]
        public decimal TotalLastMonthExpense { get; set; }

        [DisplayName("Avg. Monthly Income: ")]
        [DataType(DataType.Currency)]
        public decimal AverageMonthlyIncome { get; set; }

        [DisplayName("Total Income This Month:")]
        [DataType(DataType.Currency)]
        public decimal TotalCurrentMonthIncome { get; set; }

        [DisplayName("Total Income Last Month: ")]
        [DataType(DataType.Currency)]
        public decimal TotalLastMonthIncome{ get; set; }

        [DisplayName("Total Expenditure By Category: ")]
        public List<TblAccount> AccountBalances { get; set; }

        [DisplayName("Total Expenditure By Month: ")]
        public List<Dictionary<string, decimal>> ExpenseByMonth { get; set; }
    }
}
