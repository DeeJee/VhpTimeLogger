using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogic.Services;
using VhpTimeLogger.Interfaces;

namespace VhpTimeLogger.Forms.Beheer
{
    public partial class Projecten : Form, IObservable
    {
        private List<IObserver> _observers = new List<IObserver>();

        public Projecten()
        {
            InitializeComponent();
        }

        private void projectsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();

        }

        private void Projecten_Load(object sender, EventArgs e)
        {
            LoadActiviteiten();
        }

        private void LoadActiviteiten()
        {
            int? selectedIndex = null;
            if (lvProjects.SelectedIndices.Count == 1)
            {
                selectedIndex = lvProjects.SelectedIndices[0];
            }

            lvProjects.Items.Clear();
            ProjectService service = new ProjectService();

            var all = service.GetAll();
            foreach (var item in all)
            {
                lvProjects.Items.Add(new ListViewItem(new string[] { item.Id.ToString(), item.Name, item.Active.ToString() }));
            }

            if (selectedIndex.HasValue && selectedIndex.Value <lvProjects.Items.Count)
            {
                lvProjects.Items[selectedIndex.GetValueOrDefault()].Selected = true;
            }            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ListView lv=sender as ListView;
            if (string.IsNullOrEmpty(idTextBox.Text))
            {
                new ProjectService().Insert(nameTextBox.Text, actiefCheckBox.Checked);                
            }
            else
            {
                new ProjectService().Update(int.Parse(idTextBox.Text), nameTextBox.Text, actiefCheckBox.Checked);
            }
            LoadActiviteiten();
            detailsGroupBox.Enabled = false;
            
            SelectMode();
            ProjectDataSource.Flush();
            Notify();
        }

        private void lvProjects_MouseClick(object sender, MouseEventArgs e)
        {
            SelectItem(sender);
        }

        private void SelectItem(object sender)
        {
            ListView lv = sender as ListView;
            if (lv.SelectedItems.Count > 0)
            {
                ListViewItem item = lv.SelectedItems[0];

                idTextBox.Text = item.SubItems[0].Text;
                nameTextBox.Text = item.SubItems[1].Text;
                actiefCheckBox.Checked = bool.Parse(item.SubItems[2].Text);
            }

            wijzigenButton.Enabled = lv.SelectedItems.Count > 0;
            verwijderButton.Enabled = lv.SelectedItems.Count > 0;
        }

        private void nieuwButton_Click(object sender, EventArgs e)
        {            
            MaakDetailsLeeg();
            EditMode();            
        }

        private void MaakDetailsLeeg()
        {
            idTextBox.Text = string.Empty;
            nameTextBox.Text = string.Empty;
            actiefCheckBox.Checked = false;
        }

        private void lvProjects_SelectedIndexChanged(object sender, EventArgs e)
        {            
            SelectItem(sender);
        }

        private void wijzigenButton_Click(object sender, EventArgs e)
        {
            EditMode();
            detailsGroupBox.Enabled = true;
        }

        private void verwijderenButton_Click(object sender, EventArgs e)
        {
            string item = string.Format("{0} {1}", idTextBox.Text, nameTextBox.Text);

            DialogResult result = MessageBox.Show(string.Format("Item '{0}' zal definitief uit de database worden verwijderd. Weet je het zeker?", item), "Bevestig verwijderen.",MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (result == DialogResult.OK)
            {
                new ProjectService().Delete(int.Parse(idTextBox.Text));
                LoadActiviteiten();
                MaakDetailsLeeg();
            }
            EnableDisableButton();
            ProjectDataSource.Flush();
        }

        private void annulerenButton_Click(object sender, EventArgs e)
        {
            SelectMode();
        }

        private void SelectMode()
        {
            detailsGroupBox.Enabled = false;
            buttonPanel.Enabled = true;
        }

        private void EditMode()
        {
            detailsGroupBox.Enabled = true;
            buttonPanel.Enabled = false;
        }

        private void EnableDisableButton()
        {
            verwijderButton.Enabled=(lvProjects.SelectedIndices.Count==1);
            wijzigenButton.Enabled = (lvProjects.SelectedIndices.Count == 1);
        }

        #region IObservable
        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }
        
        public void Notify()
        {
            foreach (IObserver observer in _observers)
            {
                observer.Notify();
            }
        }
        #endregion
    }
}
