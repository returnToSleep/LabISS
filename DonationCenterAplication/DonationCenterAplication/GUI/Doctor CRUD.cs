using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DonationCenterAplication.ORM;
using Common.Model;
using Repository;
using GMap.NET;
using GMap.NET.MapProviders;

namespace DonationCenterServer.Forms
{
    public partial class DoctorCRUD : Form
    {
        public DoctorCRUD()
        {
            InitializeComponent();
            gMapDoctorSelect.Manager.Mode = AccessMode.ServerOnly;
            gMapDoctorSelect.MapProvider = GMapProviders.BingMap;
            gMapDoctorSelect.Zoom = 15;
            gMapDoctorSelect.SetPositionByKeywords("Cluj-Napoca");
            gMapDoctorSelect.DragButton = MouseButtons.Left;
            update(new RepositoryBase());
        }


        private Doctor read()
        {
           
    
            bool ok = true;
            #region Validation

            if (string.IsNullOrEmpty(locXTextbox.Text))
            {
                ok = false;
            }
            

            if (string.IsNullOrEmpty(nameTextbox.Text))
            {
                ok = false;
            }

            if (string.IsNullOrEmpty(hospitalTextBox.Text))
            {
                ok = false;
            }

            if (string.IsNullOrEmpty(specialityTextbox.Text))
            {
                ok = false;
            }
            #endregion

            if (ok)
            { 
                return new Doctor(
                    nameTextbox.Text,
                    specialityTextbox.Text,
                    hospitalTextBox.Text,
                    new Location("", double.Parse(locXTextbox.Text), double.Parse(locYTextbox.Text))
                    );
            }
            else
                return null;
                
        }

    

        private void clearTextBoxes()
        {

            locXTextbox.Clear();
            locYTextbox.Clear();
            nameTextbox.Clear();
            specialityTextbox.Clear();
            hospitalTextBox.Clear();
          
        }

        private void update(RepositoryBase repo)
        {

            doctorList.Items.Clear();

            repo.FindAll<Doctor>().ToList().ForEach(x => doctorList.Items.Add(x));

            doctorList.Items.Add("Add new..");
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clearTextBoxes();
        }

        private void gMapDoctorSelect_MouseMove(object sender, MouseEventArgs e)
        {
            locXTextbox.Text = gMapDoctorSelect.Position.Lat.ToString();
            locYTextbox.Text = gMapDoctorSelect.Position.Lng.ToString();
            gMapDoctorSelect.Zoom = 15;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Doctor selected = (Doctor)doctorList.SelectedItem;

            RepositoryBase repo = new RepositoryBase();

            if (MessageBox.Show(
                "Are you sure you want to delete this doctor?\nNote that deleting the doctor will also delete the account associated with it.",
                "Delete doctor",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes)
            {


                try
                {
                    LogInfo log = repo.FindAll<LogInfo>()
                                        .Where(x => x.type == "Doctor")
                                        .First(x => x.intId == selected.id);
                    repo.Delete(log);
                }
                catch { }

                repo.Delete(selected);
               
                update(repo);
                clearTextBoxes();
            }
        }

     

        private void addButton_Click(object sender, EventArgs e)
        {

            Doctor doc = read();

            try
            {
                Doctor other = new RepositoryBase().FindAll<Doctor>().First(x => x.hospital == doc.hospital);
                
                if (! doc.location.Equals(other.location))
                {
                    if (MessageBox.Show(
                       "The location you have entered does not match the location of the hospital.\nMatch the location with that of the hospital?",
                       "Delete doctor",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question) == DialogResult.Yes)
                            {

                                doc.location.latitude = other.location.latitude;
                                doc.location.longitude = other.location.longitude;
                            }
                }
            }
            catch { }

            clearTextBoxes();

            if (addButton.Text == "Add")
            {
                if (doc != null)
                {
                    RepositoryBase repo = new RepositoryBase();

                    int no = 0;
                    bool goOn = true;
                    string username = "";
                    string name = doc.name.Replace(" ", "");

                   

                    repo.Save(doc);

                    int? id = repo.FindAll<Doctor>().Max(x => x.id);

                    while (goOn)
                    {
                        try
                        {
                            username = name + no.ToString();
                            repo.Save(new LogInfo(username, "1234", id, "Doctor"));
                            goOn = false;
                        }
                        catch (Exception) { }
                    }


                    MessageBox.Show("New doctor account created.\nUser: " + username + "\nPassword: 1234", "Success");

                    update(repo);
                }
            }
            else
            {
                if (doc != null)
                {
                    RepositoryBase repo = new RepositoryBase();

                    Doctor selected = (Doctor)doctorList.SelectedItem;

                    repo.Delete(selected);
                    repo.Save(doc);

                    MessageBox.Show("The doctor data has been updated", "Success");

                    update(repo);
                }
            }

        }

        private void doctorList_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                Doctor selected = (Doctor)doctorList.SelectedItem;

                addButton.Text = "Update";
                deleteButton.Visible = true;

                locXTextbox.Text = selected.location.latitude.ToString();
                locYTextbox.Text = selected.location.longitude.ToString();

                nameTextbox.Text = selected.name;
                hospitalTextBox.Text = selected.hospital;
                specialityTextbox.Text = selected.speciality;


                gMapDoctorSelect.Position = new PointLatLng(selected.location.latitude, selected.location.longitude);
                gMapDoctorSelect.Zoom = 15;

            }
            catch (Exception)
            {
                clearTextBoxes();

                addButton.Text = "Add";
                deleteButton.Visible = false;

            }

       
        }

    }
}
