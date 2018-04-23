using System;

using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.BaseImpl;

namespace InitializeObjects.Module {
    public class Updater : ModuleUpdater {
        public Updater(Session session, Version currentDBVersion) : base(session, currentDBVersion) { }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();

            PhoneNumber phone1 = Session.FindObject<PhoneNumber>(CriteriaOperator.Parse("Number = '555-0101'"));
            if(phone1 == null) {
                phone1 = new PhoneNumber(Session);
                phone1.Number = "555-0101";
                phone1.PhoneType = "Home";
                phone1.Save();
            }
            PhoneNumber phone2 = Session.FindObject<PhoneNumber>(CriteriaOperator.Parse("Number = '555-0102'"));
            if(phone2 == null) {
                phone2 = new PhoneNumber(Session);
                phone2.Number = "555-0102";
                phone2.PhoneType = "Work";
                phone2.Save();
            }
            Contact johnDoe = Session.FindObject<Contact>(CriteriaOperator.Parse("FirstName = 'John' && LastName = 'Doe'"));
            if(johnDoe == null) {
                johnDoe = new Contact(Session);
                johnDoe.FirstName = "John";
                johnDoe.LastName = "Doe";
                johnDoe.Save();
            }            
        }
    }
}
