using CrudUsingADONet.Models;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography.Pkcs;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CrudUsingADONet
{
    public class StudentsDAL
    {
        string cs = ConnectionString.dbcs;

        public List<Students> getAllStudents()
        {
            List<Students> stuList = new List<Students>();

            using(SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetAllStudent",con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while(dr.Read())
                {
                    Students stu = new Students();
                    stu.Id = Convert.ToInt32(dr["ID"]);
                    stu.Name = dr["Name"].ToString()??"";
                    stu.Age = Convert.ToInt32(dr["Age"]);
                    stu.Gender = dr["Gender"].ToString() ?? "";
                    stu.City = dr["City"].ToString() ?? "";
                    stuList.Add(stu);
                }
            }
            return stuList;
        }

        public Students getStudentById(int? Id)
        {
            Students stu = new Students();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("Select * from Student where Id=@Id", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", Id);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    stu.Id = Convert.ToInt32(dr["Id"]);
                    stu.Name = dr["Name"].ToString()??"";
                    stu.Age = Convert.ToInt32(dr["Age"]);
                    stu.Gender = dr["Gender"].ToString() ?? "";
                    stu.City = dr["City"].ToString() ?? "";
                }
            }
            return stu;
        }

        public void UpdateStudent(Students stu)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spUpdateStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", stu.Id);
                cmd.Parameters.AddWithValue("@Name", stu.Name);
                cmd.Parameters.AddWithValue("@Age", stu.Age);
                cmd.Parameters.AddWithValue("@Gender", stu.Gender);
                cmd.Parameters.AddWithValue("@City", stu.City);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void AddStudents (Students stu)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spAddStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name",stu.Name);
                cmd.Parameters.AddWithValue("@Age", stu.Age);
                cmd.Parameters.AddWithValue("@Gender", stu.Gender);
                cmd.Parameters.AddWithValue("@City", stu.City);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteStudent (int Id)
        {
            using(SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spDeleteStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
