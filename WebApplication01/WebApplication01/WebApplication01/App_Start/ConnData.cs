using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication01.App_Start
{
    public class ConnData
    {
        public DataSet GetDataSet()
        {
            string strCon = "Server=DESKTOP-3POL04N;User Id=sa;Pwd=123456;DataBase=sqlserver2012";
            SqlConnection connection = new SqlConnection(strCon);
            connection.Open();
            string sqlCommond = "select * from student";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommond, connection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            return dataSet;
        }
    }
}