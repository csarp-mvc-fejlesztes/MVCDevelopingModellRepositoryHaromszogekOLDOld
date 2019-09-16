using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HaromszogekSzoftverfejleszto.Modell;
using HaromszogekSzoftverfejleszto.Tarolo;

namespace HaromszogekGUI
{
    public partial class Form1 : Form
    {

        Haromszogek haromszogek;

        public Form1()
        {
            haromszogek = new Haromszogek();
            InitializeComponent();
        }

        private void buttonBeolvas_Click(object sender, EventArgs e)
        {
            haromszogek.beolvas();
            megjelenitHaromszogeketListboxban();
        }

        private void listBoxHaromszogek_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBoxHaromszogek.SelectedIndex;
            if (index < 0) //üres a ListBox
                return;
            try
            {
                Haromszog h = haromszogek.getAdottElem(index);
                megjelenitHaromszoget(h);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void megjelenitHaromszoget(Haromszog h)
        {
            textBoxAOldal.Text = h.getA().ToString();
            textBoxBOldal.Text = h.getB().ToString();
            textBoxCOldal.Text = h.getC().ToString();
        }

        private void megjelenitHaromszogeketListboxban()
        {
            listBoxHaromszogek.DataSource = null;
            listBoxHaromszogek.DataSource = haromszogek.getHaromszogek();
        }


        private void buttonTorol_Click(object sender, EventArgs e)
        {
            int index = listBoxHaromszogek.SelectedIndex;
            if (index < 0) 
                return;
            try
            {
                Haromszog h = haromszogek.getAdottElem(index);
                int id = h.getId();
                haromszogek.torolIdAlapjan(id);
                megjelenitHaromszogeketListboxban();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void buttonUjOldal_Click(object sender, EventArgs e)
        {
            errorProviderA.SetError(textBoxAOldal, "");
            errorProviderA.SetError(textBoxBOldal, "");
            errorProviderA.SetError(textBoxCOldal, "");
            bool vanHiba = false;
            int a = 0;
            try
            {
                a = Convert.ToInt32(textBoxAOldal.Text);
            }
            catch(Exception ex)
            {
                errorProviderA.SetError(textBoxAOldal, "Hibás adat!");
                vanHiba = true;
            }
            int b = 0;
            try
            {
                b = Convert.ToInt32(textBoxBOldal.Text);
            }
            catch (Exception ex)
            {
                errorProviderB.SetError(textBoxBOldal, "Hibás adat!");
                vanHiba = true;
            }
            int c = 0;
            try
            {
                c = Convert.ToInt32(textBoxCOldal.Text);
                
            }
            catch (Exception ex)
            {
                errorProviderC.SetError(textBoxCOldal, "Hibás adat!");
                vanHiba = true;
            }
            if (!vanHiba)
            {
                Haromszog h = new Haromszog(a, b, c);
                haromszogek.hozzaadHaromszoget(h);
                megjelenitHaromszogeketListboxban();
            }
        }

        private void buttonModosit_Click(object sender, EventArgs e)
        {
            errorProviderA.SetError(textBoxAOldal, "");
            errorProviderA.SetError(textBoxBOldal, "");
            errorProviderA.SetError(textBoxCOldal, "");
            bool vanHiba = false;
            int a = 0;
            try
            {
                a = Convert.ToInt32(textBoxAOldal.Text);
            }
            catch (Exception ex)
            {
                errorProviderA.SetError(textBoxAOldal, "Hibás adat!");
                vanHiba = true;
            }
            int b = 0;
            try
            {
                b = Convert.ToInt32(textBoxBOldal.Text);
            }
            catch (Exception ex)
            {
                errorProviderB.SetError(textBoxBOldal, "Hibás adat!");
                vanHiba = true;
            }
            int c = 0;
            try
            {
                c = Convert.ToInt32(textBoxCOldal.Text);

            }
            catch (Exception ex)
            {
                errorProviderC.SetError(textBoxCOldal, "Hibás adat!");
                vanHiba = true;
            }
            if (!vanHiba)
            {
                int index = listBoxHaromszogek.SelectedIndex;
                if (index < 0) //üres a ListBox
                    return;
                Haromszog modositando = haromszogek.getAdottElem(index);
                int id = modositando.getId();
                Haromszog h = new Haromszog(a, b, c);                
                haromszogek.modositHaromszoget(id, h);
                megjelenitHaromszogeketListboxban();
            }
        }
    }
}
