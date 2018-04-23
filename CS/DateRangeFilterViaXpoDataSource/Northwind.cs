namespace Northwind {
    using System;
    using DevExpress.Xpo;

    [Persistent("Customers")]
    public class Customer : XPLiteObject {
        public Customer(Session session) : base(session) { }

        string customerID;
        
        [Key]
        public string CustomerID {
            get { return customerID; }
            set { SetPropertyValue("CustomerID", ref customerID, value); }
        }

        string contactTitle;
        public string ContactTitle {
            get { return contactTitle; }
            set { SetPropertyValue("ContactTitle", ref contactTitle, value); }
        }

        string companyName;
        public string CompanyName {
            get { return companyName; }
            set { SetPropertyValue("CompanyName", ref companyName, value); }
        }

	string address;
        public string Address {
            get { return address; }
            set { SetPropertyValue("Address", ref address, value); }
        }        

        [Association("CustomerOrders", typeof(Order))]
        public XPCollection<Order> Orders {
            get {
                return GetCollection<Order>("Orders");
            }
        }
    }

    [Persistent("Orders")]
    public class Order : XPLiteObject {
        public Order(Session session) : base(session) { }

        [Key(true), Persistent]
        int OrderID;

        [PersistentAlias("OrderID")]
        public int ID {
            get { return OrderID; }
        }

        DateTime shippedDate;
        public DateTime ShippedDate {
            get { return shippedDate; }
            set { SetPropertyValue("ShippedDate", ref shippedDate, value); }
        }

        Customer customer;
        [Persistent("CustomerID"), Association("CustomerOrders")]
        public Customer Customer {
            get { return customer; }
            set { SetPropertyValue("Customer", ref customer, value); }
        }
    }

    [Persistent("Employees")]
    public class Employee : XPLiteObject {
        public Employee(Session session) : base(session) { }

        [Key(true), Persistent]
        public int EmployeeID;

        private string _FirstName;
        public string FirstName {
            get {
                return _FirstName;
            }
            set {
                SetPropertyValue("FirstName", ref _FirstName, value);
            }
        }
        private string _LastName;
        public string LastName {
            get {
                return _LastName;
            }
            set {
                SetPropertyValue("LastName", ref _LastName, value);
            }
        }

        [PersistentAlias("Concat([FirstName], ' ', [LastName])")]
        public string FullName {
            get {
                return (string)EvaluateAlias("FullName");
            }
        }
    }
}
