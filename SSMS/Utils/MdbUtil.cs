using SSMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace SSMS.Utils
{
    public class MdbUtil
    {
        public static string connStr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=";
        public static Dictionary<string, OleDbConnection> m_Conn = new Dictionary<string, OleDbConnection>();

        /// <summary>
        /// 从连接池中取OdbcConnection
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static OleDbConnection getConn(string path)
        {
            if (!m_Conn.ContainsKey(path))
            {
                OleDbConnection conn = new OleDbConnection(connStr + path);
                m_Conn.Add(path, conn);

                return conn;
            }

            return m_Conn[path];
        }

        /// <summary>
        /// 根据路径返回已打开的OdbcConnection,失败返回null
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static OleDbConnection getOpenedConn(string path)
        {
            OleDbConnection conn = getConn(path);

            try 
            {
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                return null;
            }

            return conn;
        }

        /// <summary>
        /// 根据sql和conn获取DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static DataTable getDataTable(string sql, OleDbConnection conn)
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                return null;
            }

            DataTable myDataTable = new DataTable();

            try
            {
                OleDbDataAdapter myCommand = new OleDbDataAdapter(sql, conn);
                myCommand.Fill(myDataTable);
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                return null;
            }

            return myDataTable;
        }

        /// <summary>
        /// 从数据库加载student数据
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static List<Student> loadStudentFromMdb(OleDbConnection conn)
        {
            string sql = "SELECT * FROM Student ORDER BY DbNumber";

            return queryStudentFromMdb(sql, conn);
        }

        /// <summary>
        /// 根据sql查询mdb数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static List<Student> queryStudentFromMdb(string sql, OleDbConnection conn)
        {
            DataTable myDataTable = getDataTable(sql, conn);
           
            if (null == myDataTable)
            {
                return null;
            }

            List<Student> list = new List<Student>();

            foreach (DataRow dr in myDataTable.Rows)
            {
                Student student = ORMUtil.getStudentByDataRow(dr);
                student.StudyTime = ORMUtil.getStudyTime(student.ID, conn);

                list.Add(student);
            }

            return list;
        }

        /// <summary>
        /// 根据ID获得对应Student课程
        /// </summary>
        /// <param name="id"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static List<Lesson> getStudentLessonsByID(string id, OleDbConnection conn)
        {
            string sql = "SELECT * FROM StudentLesson WHERE OwnerID='" + id + "'";

            DataTable myDataTable = getDataTable(sql, conn);

            if (null == myDataTable)
            {
                return null;
            }

            List<Lesson> list = new List<Lesson>();

            foreach (DataRow dr in myDataTable.Rows)
            {
                Lesson lesson = ORMUtil.getLessonByDataRow(dr);

                list.Add(lesson);
            }

            return list;
        }

        /// <summary>
        /// 从数据库加载teacher数据
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static List<Teacher> loadTeacherFromMdb(OleDbConnection conn)
        {
            string sql = "SELECT * FROM Teacher ORDER BY DbNumber";

            return queryTeacherFromMdb(sql, conn);
        }

        /// <summary>
        /// 根据sql查询mdb数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static List<Teacher> queryTeacherFromMdb(string sql, OleDbConnection conn)
        {
            DataTable myDataTable = getDataTable(sql, conn);

            if (null == myDataTable)
            {
                return null;
            }

            List<Teacher> list = new List<Teacher>();

            foreach (DataRow dr in myDataTable.Rows)
            {
                Teacher teacher = ORMUtil.getTeacherByDataRow(dr);
                teacher.TeachTime = ORMUtil.getTeachTime(teacher.ID, conn);

                list.Add(teacher);
            }

            return list;
        }

        /// <summary>
        /// 根据ID获得对应Teacher课程
        /// </summary>
        /// <param name="id"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static List<Lesson> getTeacherLessonsByID(string id, OleDbConnection conn)
        {
            string sql = "SELECT * FROM TeacherLesson WHERE OwnerID='" + id + "'";

            DataTable myDataTable = getDataTable(sql, conn);

            if (null == myDataTable)
            {
                return null;
            }

            List<Lesson> list = new List<Lesson>();

            foreach (DataRow dr in myDataTable.Rows)
            {
                Lesson lesson = ORMUtil.getLessonByDataRow(dr);

                list.Add(lesson);
            }

            return list;
        }
    }
}
