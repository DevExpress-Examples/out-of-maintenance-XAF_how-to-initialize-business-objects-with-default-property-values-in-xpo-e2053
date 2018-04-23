using System;

using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.Persistent.BaseImpl;

namespace InitializeObjects.Module {
    public class Updater : ModuleUpdater {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) : base(objectSpace, currentDBVersion) { }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();

            PhoneNumber phone1 = ObjectSpace.FindObject<PhoneNumber>(CriteriaOperator.Parse("Number = '555-0101'"));
            if(phone1 == null) {
                phone1 = ObjectSpace.CreateObject<PhoneNumber>();
                phone1.Number = "555-0101";
                phone1.PhoneType = "Home";
                phone1.Save();
            }
            PhoneNumber phone2 = ObjectSpace.FindObject<PhoneNumber>(CriteriaOperator.Parse("Number = '555-0102'"));
            if(phone2 == null) {
                phone2 = ObjectSpace.CreateObject<PhoneNumber>();
                phone2.Number = "555-0102";
                phone2.PhoneType = "Work";
                phone2.Save();
            }
            Contact johnDoe = ObjectSpace.FindObject<Contact>(CriteriaOperator.Parse("FirstName = 'John' && LastName = 'Doe'"));
            if(johnDoe == null) {
                johnDoe = ObjectSpace.CreateObject<Contact>();
                johnDoe.FirstName = "John";
                johnDoe.LastName = "Doe";
                johnDoe.Save();
            }            
			ObjectSpace.CommitChanges();
        }
    }
}
