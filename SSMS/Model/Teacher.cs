using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSMS.Model
{
    public class Teacher
    {
        public Teacher(string dbNumber, string name, string gender, string id, string post, string cardid, string dataPath)
        {
            DbNumber = dbNumber;
            Name = name;
            Gender = gender;
            ID = id;
            Post = post;
            CardID = cardid;
            DataPath = dataPath;
        }

        private string dbNumber;//档案编号
        private string name;
        private string gender;
        private string id;//身份证
        private string post;//部职别
        private string cardid;//证件号
        private string dataPath;//资料储存路径
        private string teachTime;

        public string DbNumber { get { return dbNumber; } set { dbNumber = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Gender { get { return gender; } set { gender = value; } }
        public string ID { get { return id; } set { id = value; } }
        public string Post { get { return post; } set { post = value; } }
        public string CardID { get { return cardid; } set { cardid = value; } }
        public string DataPath { get { return dataPath; } set { dataPath = value; } }
        public string TeachTime { get { return teachTime; } set { teachTime = value; } }
    }
}
