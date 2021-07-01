using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main
{
    class sql
    {
            //数据库连接
            SQLiteConnection m_dbConnection;
            // FLandWidget FLandWidget = new FLandWidget();
            //创建一个空的数据库
            public void createNewDatabase()
            {
                SQLiteConnection.CreateFile("MyDatabase.sqlite");
            }

            //创建一个连接到指定数据库
            public  void connectToDatabase()
            {
               m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
                
            m_dbConnection.Open();
            }

            //在指定数据库中创建一个table
            public void createTable()
            {
                string sql = "create table if not exists highscores (name varchar(20), score varchar(20))";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
            }
            public void createTable2()
            {
            string sql = "create table if not exists personalLike (name varchar(20), nickName varchar(20),team varchar(20),soccerStar varchar(20))";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            }
        public void createTable3()
        {
            string sql = "create table if not exists profile (name varchar(20), pro varchar(20))";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

        //插入一些数据
        public void fillTable(string username,string password)
            {
                string sql = "insert into highscores (name, score) values ('"+username+"', '"+password+"')";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
            }
        public void fillTable2(string username, string nickName, string like,string star)
        {
            string sql = "insert into personalLike (name, nickName,team,soccerStar) values ('" + username + "', '" + nickName + "','"+like+"','"+star+"')";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }
        public void fillTable3(string username, string pro)
        {
            string sql = "insert into profile (name , pro) values ('" + username + "', '" + pro + "')";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

        //使用sql查询语句，并显示结果
        public void printHighscores()
            {
            
                string sql = "select * from highscores order by score desc";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                Console.WriteLine("Name: " + reader["name"] + "\tScore: " + reader["score"]);
                Console.ReadLine();
        }

        public void select(string username, string password)
        {
            SQLiteCommand checkCmd = m_dbConnection.CreateCommand();       //创建SQL命令执行对象
            string sql = "select name,score from highscores where name = '" + username + "' and score = '" + password+"'";
            checkCmd.CommandText = sql;
            SQLiteDataAdapter check = new SQLiteDataAdapter();       //实例化数据适配器
            check.SelectCommand = checkCmd;                    //让适配器执行SELECT命令
            DataSet checkData = new DataSet();                 //实例化结果数据集
            int n = check.Fill(checkData, "highscores");         //将结果放入数据适配器，返回元祖个数
            if (n!=0)
            {
                
                FLandWidget fLandWidget = new FLandWidget();
                fLandWidget.Hide();
                //FPersonal fPersonal = new FPersonal();
                //fPersonal.Show();
                Main_Form main = new Main_Form();
                
                main.Show();
            }
            else
            {
                MessageBox.Show("用户名或密码错误");
            }
            
        }
        public int select1(string username)
        {
            SQLiteCommand checkCmd = m_dbConnection.CreateCommand();    //创建SQL命令执行对象
            string s = "select name from highscores where name='" + username + "'";
            checkCmd.CommandText = s;
            SQLiteDataAdapter check = new SQLiteDataAdapter();       //实例化数据适配器
            check.SelectCommand = checkCmd;                    //让适配器执行SELECT命令
            DataSet checkData = new DataSet();                 //实例化结果数据集
            int n = check.Fill(checkData, "highscores");         //将结果放入数据适配器，返回元祖个数
            if (n != 0)
            {
                MessageBox.Show("用户名存在");
            }
            return n;
        }
        public string look(string id)
        {
            
            SQLiteCommand checkCmd = m_dbConnection.CreateCommand();       //创建SQL命令执行对象
            string s = "select nickName from personalLike where name='" + id + "'";
            checkCmd.CommandText = s;
            SQLiteDataReader reader = checkCmd.ExecuteReader();
            reader.Read();
            
            string nickName = reader.GetString(reader.GetOrdinal("nickName"));
                
            return nickName;
           
        }
        public string look2(string id)
        {

            SQLiteCommand checkCmd = m_dbConnection.CreateCommand();       //创建SQL命令执行对象
            string s = "select team from personalLike where name='" + id + "'";
            checkCmd.CommandText = s;
            SQLiteDataReader reader = checkCmd.ExecuteReader();
            reader.Read();

            string nickName = reader.GetString(reader.GetOrdinal("team"));
            return nickName;

        }
        public string look3(string id)
        {

            SQLiteCommand checkCmd = m_dbConnection.CreateCommand();       //创建SQL命令执行对象
            string s = "select soccerStar from personalLike where name='" + id + "'";
            checkCmd.CommandText = s;
            SQLiteDataReader reader = checkCmd.ExecuteReader();
            reader.Read();

            string nickName = reader.GetString(reader.GetOrdinal("soccerStar"));
            return nickName;

        }
        public string look4(string id)
        {
            SQLiteCommand checkCmd = m_dbConnection.CreateCommand();       //创建SQL命令执行对象
            string s = "select pro from profile where name='" + id + "'";
            checkCmd.CommandText = s;
            SQLiteDataReader reader = checkCmd.ExecuteReader();
            reader.Read();
            string nickName = reader.GetString(reader.GetOrdinal("pro"));
            return nickName;
        }
    }
    }


