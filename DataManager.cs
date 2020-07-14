using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

namespace shopNet
{
    [Serializable()]
    public class DataManager
    {
        string listPath;
        public string ListPath
        {
            set { this.listPath = value; }
        }
        public List<Shop> shopsList;
        public bool fileIsLoaded = false;
        public DataManager() : this("C://EducationBase//ShopNet//shops.bin")
        {
            this.shopsList = new List<Shop>();
        }

        public DataManager(string path)
        {
            listPath = path;
        }
        public void saveShopsListInFile(List<Shop> shopsList)
        {
            this.shopsList = shopsList;
            this.shopsList = this.shopsList.OrderBy(x => x.name).ToList();
            FileStream newFile = new FileStream(listPath, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(newFile, this.shopsList);
            newFile.Close();
        }
        public void saveShopsListInFile(List<Shop> shopsList, string path)
        {
            this.shopsList = shopsList;
            this.shopsList = this.shopsList.OrderBy(x => x.name).ToList();
            FileStream newFile = new FileStream(path, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(newFile, this.shopsList);
            newFile.Close();
        }


        public List<Shop> loadShopsFromFile()
        {
            try
            {
                if (File.Exists(listPath))
                {
                    FileStream openFile = new FileStream(listPath, FileMode.Open);
                    BinaryFormatter formatter = new BinaryFormatter();
                    this.shopsList = (List<Shop>)formatter.Deserialize(openFile);
                    openFile.Close();
                    return this.shopsList;
                }
                else
                    throw new Exception();
            }
            catch
            {
                List<Shop> loadShopsList = new List<Shop>();
                return loadShopsList;
            }
        }

        public void LoadFromExcel(string excelPath)
        {
            if (shopsList == null)
                shopsList = new List<Shop>();


            Excel.Application objWorkExcel = new Excel.Application();
            Excel.Workbook objWorkBook = objWorkExcel.Workbooks.Open(excelPath);
            Excel.Worksheet objWorkSheet = (Excel.Worksheet)objWorkBook.Sheets[1];

            for (int i = 1; i < 224; i++)
                shopsList.Add(
                new Shop(
                    objWorkSheet.Cells[i, 1].Text.ToString(),
                    objWorkSheet.Cells[i, 2].Text.ToString(),
                new Provider
                {
                    customer = objWorkSheet.Cells[i, 3].Text.ToString(),
                    name = objWorkSheet.Cells[i, 4].Text.ToString(),
                    contractNumber = objWorkSheet.Cells[i, 5].Text.ToString(),
                    phoneNumber = objWorkSheet.Cells[i, 6].Text.ToString(),
                    ipAddress = objWorkSheet.Cells[i, 7].Text.ToString(),
                    isActive = objWorkSheet.Cells[i, 7].Text.ToString() == "" ? false : true,
                    connectDayTime = DateTime.Now
                },
                new Provider
                {
                    name = "Укртелеком",
                    ipAddress = objWorkSheet.Cells[i, 8].Text.ToString(),
                    isActive = objWorkSheet.Cells[i, 8].Text.ToString() == "" ? false : true,
                    connectDayTime = DateTime.Now
                }));

            objWorkBook.Close(false, Type.Missing, Type.Missing); //закрыть не сохраняя
            objWorkExcel.Quit(); // выйти из Excel
            GC.Collect(); // убрать за собой
        }

        public List<Shop> loadShopsFromFile(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    FileStream openFile = new FileStream(path, FileMode.Open);
                    BinaryFormatter formatter = new BinaryFormatter();
                    this.shopsList = (List<Shop>)formatter.Deserialize(openFile);
                    openFile.Close();
                    return this.shopsList;
                }
                else throw new Exception("Файл відсутній");
            }
            catch
            {
                return new List<Shop>();
            }
        }
    }
}
