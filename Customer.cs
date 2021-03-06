//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NicoleProvanFinalExam
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            this.Customer_Detail = new HashSet<Customer_Detail>();
        }

        public int CustNum { get; set; }
        public string CustFirstName { get; set; }
        public string CustLastName { get; set; }
        public string City { get; set; }
        public Nullable<decimal> CreditLimit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer_Detail> Customer_Detail { get; set; }




        public static void NewCustomer(string firstName, string lastName, string city, decimal creditLimit)
        {
            using (var context = new FinalExamEntities())
            {
                Customer cust = new Customer()
                {
                    CustFirstName = firstName,
                    CustLastName = lastName,
                    City = city,
                    CreditLimit = creditLimit
                };

                context.Customers.Add(cust);
                context.SaveChanges();
            }
        }


        public static bool CheckCustomer(string firstName, string lastName)
        {
            using (var context = new FinalExamEntities())
            {
                var query = context.Customers.Where(user => user.CustFirstName == firstName).FirstOrDefault<Customer>();

                var query2 = context.Customers.Where(user => user.CustLastName == lastName).FirstOrDefault<Customer>();

                if (query != null && query2 != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static void EditCity(string username, string city)
        {
            using (var context = new FinalExamEntities())
            {
                //get customer number
                var query = from user in context.Customer_Detail
                            where user.CustUserName == username
                            select user.CustNum;

                int id = query.FirstOrDefault();

                var cust = context.Customers.Where(user => user.CustNum == id).FirstOrDefault<Customer>();
                cust.City = city;
                context.SaveChanges();

                Console.WriteLine("City Updated.");
            }
        }

        public static void EditCredit(string username, decimal credLim)
        {
            using (var context = new FinalExamEntities())
            {
                //get customer number
                var query = from user in context.Customer_Detail
                            where user.CustUserName == username
                            select user.CustNum;

                int id = query.FirstOrDefault();

                var cust = context.Customers.Where(user => user.CustNum == id).FirstOrDefault<Customer>();
                cust.CreditLimit = credLim;
                context.SaveChanges();

                Console.WriteLine("Credit Updated.");

            }
        }
    }
}
