namespace T06to07ExcellSheetConnection
{
    using System;
    using System.Data;
    using System.Data.OleDb;
    using System.Text;

    class MainEntry
    {
        private static string ConnectionInfo = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=../../Results.xls;Extended Properties='Excel 8.0;HDR=Yes'";
        static void Main(string[] args)
        {
            ReadEntries();
            InsertData("Bate Goiko", 9001);
            ReadEntries();
        }

        /*Create an Excel file with 2 columns: name and score:
         * Write a program that reads your MS Excel file through the OLE DB data provider and displays the name and score row by row.*/
        public static void ReadEntries()
        {
            OleDbConnection excelCon = new OleDbConnection(ConnectionInfo);            
            DataTable data = new DataTable();
            OleDbCommand com = new OleDbCommand("Select * FROM [Sheet1$]", excelCon);
            using (com)
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter(com);
                using (adapter)
                {
                    adapter.Fill(data);
                }
            }            
            StringBuilder result = new StringBuilder();
            foreach (DataRow row in data.Rows)
            {
                foreach (DataColumn col in data.Columns)
                {                    
                    result.AppendFormat("{0} ", row[col]);
                }
                result.AppendLine();
            }
            Console.WriteLine(result);
        }

        /*Implement appending new rows to the Excel file.*/
        public static void InsertData(string name, int score)
        {
            OleDbConnection excelCon = new OleDbConnection(ConnectionInfo);
            excelCon.Open();
            OleDbCommand com = new OleDbCommand(string.Format("INSERT INTO [Sheet1$](Name, Score)VALUES('{0}', {1})", name, score), excelCon);
            com.ExecuteNonQuery();
            excelCon.Close();
        }
    }
}