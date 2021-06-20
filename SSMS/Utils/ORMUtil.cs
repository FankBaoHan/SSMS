using SSMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSMS.Utils
{
    public class ORMUtil
    {
        /// <summary>
        /// getStudentByDataRow
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static Student getStudentByDataRow(DataRow dr)
        {
            string dbNumber = dr["DbNumber"].ToString();
            string name = dr["Name"].ToString();
            string gender = dr["Gender"].ToString();
            string id = dr["ID"].ToString();
            string post = dr["Post"].ToString();
            string cardID = dr["CardID"].ToString();
            string dataPath = dr["DataPath"].ToString();

            return new Student(dbNumber,name,gender,id,post,cardID,dataPath);
        }

        /// <summary>
        /// 计算学习时长,String类型
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static string getStudyTime(string studentId, OleDbConnection conn)
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
                return "-1";
            }

            string sql = "SELECT SUM(Time) FROM StudentLesson WHERE OwnerID='" + studentId + "'";
            OleDbCommand cmmd = new OleDbCommand(sql, conn);
            string result = cmmd.ExecuteScalar().ToString();

            if (result.Equals(""))
            {
                return "0.0";
            }

            return Convert.ToSingle(result).ToString("0.0");
        }

        /// <summary>
        /// 根据dr获得课程
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static Lesson getLessonByDataRow(DataRow dr)
        {
            string ownerID = dr["OwnerID"].ToString();
            string content = dr["Content"].ToString();
            string time = dr["Time"].ToString();

            return new Lesson(ownerID, content, Convert.ToSingle(time));
        }

        /// <summary>
        /// getTeacherByDataRow
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static Teacher getTeacherByDataRow(DataRow dr)
        {
            string dbNumber = dr["DbNumber"].ToString();
            string name = dr["Name"].ToString();
            string gender = dr["Gender"].ToString();
            string id = dr["ID"].ToString();
            string post = dr["Post"].ToString();
            string cardID = dr["CardID"].ToString();
            string dataPath = dr["DataPath"].ToString();

            return new Teacher(dbNumber, name, gender, id, post, cardID, dataPath);
        }

        /// <summary>
        /// 计算授课时长,String类型
        /// </summary>
        /// <param name="teacherID"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static string getTeachTime(string teacherID, OleDbConnection conn)
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
                return "-1";
            }

            string sql = "SELECT SUM(Time) FROM TeacherLesson WHERE OwnerID='" + teacherID + "'";
            OleDbCommand cmmd = new OleDbCommand(sql, conn);

            string result = cmmd.ExecuteScalar().ToString();
            if (result.Equals(""))
            {
                return "0.0";
            }

            return Convert.ToSingle(result).ToString("0.0");
        }
    }
}
