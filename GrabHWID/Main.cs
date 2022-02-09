using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HWID_Finder
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        #region "Grab HWID Function"
        private static string GrabHWID()
        {
            string Root = @"SOFTWARE\Microsoft\Cryptography";
            string N = "MachineGuid";

            using (RegistryKey localMachineX64View = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
            {
                using (RegistryKey RegKey = localMachineX64View.OpenSubKey(Root))
                {
                    if (RegKey == null)
                    {
                        throw new KeyNotFoundException(string.Format(Root));
                    }
                    object HWID = RegKey.GetValue(N);
                    if (HWID == null)
                    {
                        throw new IndexOutOfRangeException(string.Format(N));
                    }
                    return HWID.ToString();
                }
            }
        }
        #endregion

        private void GrabBTN_Click(object sender, EventArgs e)
        {
            GrabHWID();
            richTextBox1.Text = "HWID: " + GrabHWID();

        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}

