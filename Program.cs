using System;
using System.Collections.Generic;
using CodeProblems.Problems;


/*
    For this project there are 3 main components: DataModels, Repositories and Validation Rules.
    DataModels represents schemas: Order, OrderItem, Product
    Repositories contains services to fetch data from the application layer
    Validation Rules functions validates data from the presentation layer
*/
namespace CodeProblems
{
    class Program
    {
        public static void Main(string[] args)
        {
            LinqProblem1.Start();
        }
    }
}
