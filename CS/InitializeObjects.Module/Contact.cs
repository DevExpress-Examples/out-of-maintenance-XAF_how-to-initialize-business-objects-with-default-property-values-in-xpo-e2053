using System;
using System.ComponentModel;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace InitializeObjects.Module {
    [DefaultClassOptions]
    public class Contact : Person {
        public Contact(Session session) : base(session) { }

        public TitleOfCourtesy TitleOfCourtesy {
            get { return GetPropertyValue<TitleOfCourtesy>("TitleOfCourtesy"); }
            set { SetPropertyValue<TitleOfCourtesy>("TitleOfCourtesy", value); }
        }
        public Contact Manager {
            get { return GetPropertyValue<Contact>("Manager"); }
            set { SetPropertyValue<Contact>("Manager", value); }
        }
        public override void AfterConstruction() {
            base.AfterConstruction();

            FirstName = "Sam";
            TitleOfCourtesy = TitleOfCourtesy.Mr;

            Address1 = new Address(Session);
            Address1.Country = Session.FindObject<Country>(CriteriaOperator.Parse("Name = 'USA'"));            
            if(Address1.Country == null) {
                Address1.Country = new Country(Session);
                Address1.Country.Name = "USA";                
                Address1.Country.Save();
            }            

            Manager = Session.FindObject<Contact>(CriteriaOperator.Parse("FirstName = 'John' && LastName = 'Doe'"));

            PhoneNumber phone1 = Session.FindObject<PhoneNumber>(CriteriaOperator.Parse("Number = '555-0101'"));
            PhoneNumber phone2 = Session.FindObject<PhoneNumber>(CriteriaOperator.Parse("Number = '555-0102'"));
            PhoneNumbers.Add(phone1);
            PhoneNumbers.Add(phone2);
        }
    }
    public enum TitleOfCourtesy { Dr, Miss, Mr, Mrs, Ms };
}
