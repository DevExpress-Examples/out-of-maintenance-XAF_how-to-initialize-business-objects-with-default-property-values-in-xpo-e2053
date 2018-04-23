using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.ExpressApp.Win;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp;

namespace InitializeObjects.Win {
    public partial class InitializeObjectsWindowsFormsApplication : WinApplication {
        public InitializeObjectsWindowsFormsApplication() {
            InitializeComponent();
        }

        private void InitializeObjectsWindowsFormsApplication_DatabaseVersionMismatch(object sender, DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs e) {
            e.Updater.Update();
            e.Handled = true;
        }
    }
}
