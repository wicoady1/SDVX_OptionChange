using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data;

namespace SDVX_OptionChange.Functions
{
    class MainPresenter
    {
        Functions.IMain _iMain;

        private static DataTable dtNavList;

        public MainPresenter(Functions.IMain iMain)
        {
            this._iMain = iMain;
            DataTable dtNavList = new DataTable();
        }

        public void LoadNavigatorList()
        {
            string[] strNavNameArr = {"Rasis Default",
                                    "Rasis Battle",
                                    "Kureha",
                                    "Near & Noah",
                                    "Rasis Yukata",
                                    "Kanade",
                                    "Rasis Mizugi",
                                    "Meu Meu",
                                    "Reimu",
                                    "Rasis Bug",
                                    "Left Tsumabuki",
                                    "Right Tsumabuki",
                                    "Maxima"};
            byte[] intNavHex1Arr = { 0x8C,
                                0x50,
                                0x94,
                                0x34,
                                0xCC,
                                0x50,
                                0x10,
                                0xA0,
                                0x90,
                                0x9C,
                                0xB8,
                                0x24,
                                0xF8};
            byte[] intNavHex2Arr = {0x0B,
                                0x0A,
                                0x09,
                                0x09,
                                0x08,
                                0x08,
                                0x07,
                                0x06,
                                0x05,
                                0x04,
                                0x0A,
                                0x0B,
                                0x09};

            DataTable dtNavList = new DataTable();
            DataColumn dcNavIndex = new DataColumn("NavIndex", typeof(int));
            DataColumn dcNavName = new DataColumn("NavName", typeof(string));
            DataColumn dcNavHex1 = new DataColumn("NavHex1", typeof(byte));
            DataColumn dcNavHex2 = new DataColumn("NavHex2", typeof(byte));
            dtNavList.Columns.Add(dcNavIndex);
            dtNavList.Columns.Add(dcNavName);
            dtNavList.Columns.Add(dcNavHex1);
            dtNavList.Columns.Add(dcNavHex2);

            for (int i = 0; i< strNavNameArr.Length; i++)
            {
                DataRow drNav = dtNavList.NewRow();
                drNav["NavIndex"] = i;
                drNav["NavName"] = strNavNameArr[i];
                drNav["NavHex1"] = intNavHex1Arr[i];
                drNav["NavHex2"] = intNavHex2Arr[i];

                dtNavList.Rows.Add(drNav);
            }

            _iMain.NavigatorDataSource = dtNavList;
        }

        public void LoadFile()
        {
            try
            {
                string path = @"soundvoltex.dll";

                using (var stream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
                {
                    BinaryReader readBinary = new BinaryReader(stream);

                    byte inbyte;
                    inbyte = readBinary.ReadByte();
                    string outbyte = "";
                    string result = "";

                    //------------------------ for AllStage Safe -------------------------------
                    readBinary.BaseStream.Position = 0x001424D6;
                    while (readBinary.BaseStream.Position < 0x001424D8)
                    {
                        inbyte = readBinary.ReadByte();
                        //outbyte = Convert.ToString(inbyte);
                        outbyte = string.Format("{0:X2}", inbyte);
                        result += outbyte + " ";
                    }

                    //result = string.Format("{0:X2}", outbyte);
                    result = result.TrimEnd(' ');
                    //MessageBox.Show(result);

                    CheckAllStageSafe(result);

                    //------------------------ for Force Event Mode -------------------------------
                    result = "";
                    readBinary.BaseStream.Position = 0x0015B3E2;
                    while (readBinary.BaseStream.Position < 0x0015B3E3)
                    {
                        inbyte = readBinary.ReadByte();
                        //outbyte = Convert.ToString(inbyte);
                        outbyte = string.Format("{0:X2}", inbyte);
                        result += outbyte + " ";
                    }

                    //result = string.Format("{0:X2}", outbyte);
                    result = result.TrimEnd(' ');
                    //MessageBox.Show(result);

                    CheckForceEventMode(result);

                    //------------------------ for All Difficulty Unlock -------------------------------
                    result = "";
                    readBinary.BaseStream.Position = 0x0012CD65;
                    while (readBinary.BaseStream.Position < 0x0012CD69)
                    {
                        inbyte = readBinary.ReadByte();
                        //outbyte = Convert.ToString(inbyte);
                        outbyte = string.Format("{0:X2}", inbyte);
                        result += outbyte + " ";
                    }

                    //result = string.Format("{0:X2}", outbyte);
                    result = result.TrimEnd(' ');
                    //MessageBox.Show(result);

                    CheckAllDifficultyUnlock(result);

                    //------------------------ for Navigator -------------------------------
                    result = "";
                    readBinary.BaseStream.Position = 0x0027FB88;
                    while (readBinary.BaseStream.Position < 0x0027FB8A)
                    {
                        inbyte = readBinary.ReadByte();
                        //outbyte = Convert.ToString(inbyte);
                        outbyte = string.Format("{0:X2}", inbyte);
                        result += outbyte + " ";
                    }

                    //result = string.Format("{0:X2}", outbyte);
                    result = result.TrimEnd(' ');
                    //MessageBox.Show(result);

                    CheckNavigator(result);

                    //------------------------ for Premium Free Mode -------------------------------
                    result = "";
                    readBinary.BaseStream.Position = 0x0017CA4F;
                    while (readBinary.BaseStream.Position < 0x0017CA50)
                    {
                        inbyte = readBinary.ReadByte();
                        //outbyte = Convert.ToString(inbyte);
                        outbyte = string.Format("{0:X2}", inbyte);
                        result += outbyte + " ";
                    }

                    //result = string.Format("{0:X2}", outbyte);
                    result = result.TrimEnd(' ');
                    //MessageBox.Show(result);

                    CheckPremFree(result);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("soundvoltex.dll is not found. Please put this EXE into same folder as gamestart.bat or soundvoltex.dll!");
            }
        }

        private void CheckAllStageSafe(string strLoadVal)
        {
            if (strLoadVal == "B0 01")
            {
                _iMain.AllStageSafe = true;
            }
            else
            {
                _iMain.AllStageSafe = false;
            }
        }

        private void CheckForceEventMode(string strLoadVal)
        {
            if (strLoadVal == "01")
            {
                _iMain.ForceEventMode = true;
            }
            else
            {
                _iMain.ForceEventMode = false;
            }
        }

        private void CheckAllDifficultyUnlock(string strLoadVal)
        {
            if (strLoadVal == "B8 0B 00 00")
            {
                _iMain.AllDifficultyUnlock = true;
            }
            else
            {
                _iMain.AllDifficultyUnlock = false;
            }
        }

        private void CheckNavigator(string strLoadVal)
        {
            byte intHex1 = Convert.ToByte(strLoadVal.Substring(0, 2), 16);
            byte intHex2 = Convert.ToByte(strLoadVal.Substring(strLoadVal.Length-2, 2), 16);
            dtNavList = _iMain.NavigatorDataSource;

            for (int i = 0; i < dtNavList.Rows.Count; i++)
            {
                if (dtNavList.Rows[i].Field<byte>("NavHex1") == intHex1 &&
                    dtNavList.Rows[i].Field<byte>("NavHex2") == intHex2)
                {
                    _iMain.NavigatorSelect = dtNavList.Rows[i].Field<int>("NavIndex");
                }
            }
        }

        private void CheckPremFree(string strLoadVal)
        {
            if (strLoadVal == "02")
            {
                _iMain.PremFree = true;
            }
            else
            {
                _iMain.PremFree = false;
            }
        }

        public void HexEdit()
        {
            try
            { 
                WriteAllStageSafe(_iMain.AllStageSafe);
                WriteNavigator(_iMain.NavigatorDataSource, _iMain.NavigatorSelect);
                WritePremFree(_iMain.PremFree);
                WriteForceEventMode(_iMain.ForceEventMode);
                WriteAllDifficultyUnlock(_iMain.AllDifficultyUnlock);

                MessageBox.Show("Applied Successful");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void WriteAllStageSafe(bool boolInput)
        {
            string path = @"soundvoltex.dll";

            using (var stream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
            {
                if (boolInput == true) { 
                    stream.Position = 0x001424D6;
                    stream.WriteByte(0xB0);

                    stream.Position = 0x001424D7;
                    stream.WriteByte(0x01);
                }
                if (boolInput == false)
                {
                    stream.Position = 0x001424D6;
                    stream.WriteByte(0x32);

                    stream.Position = 0x001424D7;
                    stream.WriteByte(0xC0);
                }
            }
        }

        private void WriteForceEventMode(bool boolInput)
        {
            string path = @"soundvoltex.dll";

            using (var stream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
            {
                if (boolInput == true)
                {
                    
                    stream.Position = 0x0015B3E2;
                    stream.WriteByte(0x01);
                }
                if (boolInput == false)
                {

                    stream.Position = 0x0015B3E2;
                    stream.WriteByte(0x00);
                }
            }
        }

        private void WriteAllDifficultyUnlock(bool boolInput)
        {
            string path = @"soundvoltex.dll";

            using (var stream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
            {
                if (boolInput == true)
                {
                    stream.Position = 0x0012CD65;
                    stream.WriteByte(0xB8);

                    stream.Position = 0x0012CD66;
                    stream.WriteByte(0x0B);

                    stream.Position = 0x0012CD67;
                    stream.WriteByte(0x00);

                    stream.Position = 0x0012CD68;
                    stream.WriteByte(0x00);
                }
                if (boolInput == false)
                {
                    stream.Position = 0x0012CD65;
                    stream.WriteByte(0xE8);

                    stream.Position = 0x0012CD66;
                    stream.WriteByte(0x56);

                    stream.Position = 0x0012CD67;
                    stream.WriteByte(0x8B);

                    stream.Position = 0x0012CD68;
                    stream.WriteByte(0x01);
                }
            }
        }

        private void WriteNavigator(DataTable dtInput, int index)
        {
            byte intHex1 = dtInput.Rows[index].Field<byte>("NavHex1");
            byte intHex2 = dtInput.Rows[index].Field<byte>("NavHex2");
            string path = @"soundvoltex.dll";

            using (var stream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
            {
                    stream.Position = 0x0027FB88;
                    stream.WriteByte(intHex1);

                    stream.Position = 0x0027FB89;
                    stream.WriteByte(intHex2);
            }
        }

        private void WritePremFree(bool boolInput)
        {
            string path = @"soundvoltex.dll";

            using (var stream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
            {
                

                if (boolInput == true)
                {
                    //Modified
                    //0x0017CA4F                  02
                    //0x0017CAD6 - 0x0017CADB     E9 6F D1 0C 00 90
                    //0x00249C4A - 0x00249C4D     C7 83 78 0A
                    //0x00249C50 - 0x00249C5F     01 00 00 00 8B 83 78 0A 00 00 E9 7D 2E F3 FF 00

                    stream.Position = 0x0017CA4F;
                    stream.WriteByte(0x02);
                    //-----
                    stream.Position = 0x0017CAD6;
                    stream.WriteByte(0xE9);

                    stream.Position = 0x0017CAD7;
                    stream.WriteByte(0x6F);

                    stream.Position = 0x0017CAD8;
                    stream.WriteByte(0xD1);

                    stream.Position = 0x0017CAD9;
                    stream.WriteByte(0x0C);

                    stream.Position = 0x0017CADA;
                    stream.WriteByte(0x00);

                    stream.Position = 0x0017CADB;
                    stream.WriteByte(0x90);
                    //-----
                    stream.Position = 0x00249C4A;
                    stream.WriteByte(0xC7);

                    stream.Position = 0x00249C4B;
                    stream.WriteByte(0x83);

                    stream.Position = 0x00249C4C;
                    stream.WriteByte(0x78);

                    stream.Position = 0x00249C4D;
                    stream.WriteByte(0x0A);
                    //-----
                    stream.Position = 0x00249C50;
                    stream.WriteByte(0x01);

                    stream.Position = 0x00249C51;
                    stream.WriteByte(0x00);

                    stream.Position = 0x00249C52;
                    stream.WriteByte(0x00);

                    stream.Position = 0x00249C53;
                    stream.WriteByte(0x00);

                    stream.Position = 0x00249C54;
                    stream.WriteByte(0x8B);

                    stream.Position = 0x00249C55;
                    stream.WriteByte(0x83);

                    stream.Position = 0x00249C56;
                    stream.WriteByte(0x78);

                    stream.Position = 0x00249C57;
                    stream.WriteByte(0x0A);

                    stream.Position = 0x00249C58;
                    stream.WriteByte(0x00);

                    stream.Position = 0x00249C59;
                    stream.WriteByte(0x00);

                    stream.Position = 0x00249C5A;
                    stream.WriteByte(0xE9);

                    stream.Position = 0x00249C5B;
                    stream.WriteByte(0x7D);

                    stream.Position = 0x00249C5C;
                    stream.WriteByte(0x2E);

                    stream.Position = 0x00249C5D;
                    stream.WriteByte(0xF3);

                    stream.Position = 0x00249C5E;
                    stream.WriteByte(0xFF);

                    stream.Position = 0x00249C5F;
                    stream.WriteByte(0x00);
                }
                if (boolInput == false)
                {
                    //Default
                    //0x0017CA4F                  00
                    //0x0017CAD6 - 0x0017CADB     8B 83 78 0A 00 00
                    //0x00249C4A - 0x00249C4D     00 00 00 00
                    //0x00249C50 - 0x00249C5F     00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00

                    stream.Position = 0x0017CA4F;
                    stream.WriteByte(0x00);
                    //-----
                    stream.Position = 0x0017CAD6;
                    stream.WriteByte(0x8B);

                    stream.Position = 0x0017CAD7;
                    stream.WriteByte(0x83);

                    stream.Position = 0x0017CAD8;
                    stream.WriteByte(0x78);

                    stream.Position = 0x0017CAD9;
                    stream.WriteByte(0x0A);

                    stream.Position = 0x0017CADA;
                    stream.WriteByte(0x00);

                    stream.Position = 0x0017CADB;
                    stream.WriteByte(0x00);
                    //-----
                    stream.Position = 0x00249C4A;
                    stream.WriteByte(0x00);

                    stream.Position = 0x00249C4B;
                    stream.WriteByte(0x00);

                    stream.Position = 0x00249C4C;
                    stream.WriteByte(0x00);

                    stream.Position = 0x00249C4D;
                    stream.WriteByte(0x00);
                    //-----
                    stream.Position = 0x00249C50;
                    stream.WriteByte(0x00);

                    stream.Position = 0x00249C51;
                    stream.WriteByte(0x00);

                    stream.Position = 0x00249C52;
                    stream.WriteByte(0x00);

                    stream.Position = 0x00249C53;
                    stream.WriteByte(0x00);

                    stream.Position = 0x00249C54;
                    stream.WriteByte(0x00);

                    stream.Position = 0x00249C55;
                    stream.WriteByte(0x00);

                    stream.Position = 0x00249C56;
                    stream.WriteByte(0x00);

                    stream.Position = 0x00249C57;
                    stream.WriteByte(0x00);

                    stream.Position = 0x00249C58;
                    stream.WriteByte(0x00);

                    stream.Position = 0x00249C59;
                    stream.WriteByte(0x00);

                    stream.Position = 0x00249C5A;
                    stream.WriteByte(0x00);

                    stream.Position = 0x00249C5B;
                    stream.WriteByte(0x00);

                    stream.Position = 0x00249C5C;
                    stream.WriteByte(0x00);

                    stream.Position = 0x00249C5D;
                    stream.WriteByte(0x00);

                    stream.Position = 0x00249C5E;
                    stream.WriteByte(0x00);

                    stream.Position = 0x00249C5F;
                    stream.WriteByte(0x00);
                }
            }
        }

        public void ShowPremFreeHelp()
        {
            string strMessage = "[PREMIUM FREE MODE]\n" +
                "-- THIS FEATURE IS STILL UNDERDEVELOPMENT + EXPERIMENTAL!! USE IT AT YOUR OWN RISK! --\n" + 
                "Premium Free Mode will set game starts at Final Track and Showing Result Screen as 2nd Track\n" + 
                "Makes game will do infinite loop play, until player decide to \"force quit\" the Application / SDVX";

            MessageBox.Show(strMessage);
        }
    }
}
