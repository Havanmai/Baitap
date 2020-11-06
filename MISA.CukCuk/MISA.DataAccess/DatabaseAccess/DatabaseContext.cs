using MISA.Common.Models;
using MISA.DataAccess.Interface;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace MISA.DataAccess.DatabaseAccess
{
    public class DatabaseContext<T>:IDisposable,IDatabaseContext<T>
    {
        #region Declare
        //readonly string _connectionString = "User Id=nvmanh;Password=12345678@Abc;Host=35.194.166.58;Port=3306;Database=MISACukCuk_F09_DTHA;Character Set=utf8";
        readonly string _connectionString = "User Id=nvmanh;Password=12345678@Abc;Host=192.168.15.18;Port=3306;Database=MISACukCuk_F09_DTHA;Character Set=utf8";
        MySqlConnection _sqlConnection;
        MySqlCommand _sqlCommand;
        #endregion
        #region Contructor
        public DatabaseContext()
        {
            // khoi tao ket noi database
            _sqlConnection = new MySqlConnection(_connectionString);
            _sqlConnection.Open();
            // đồi tượng xu ly command
            _sqlCommand = _sqlConnection.CreateCommand();
            _sqlCommand.CommandType = CommandType.StoredProcedure;
        }
        #endregion
        #region method
        /// <summary>
        /// lay du lieu customer
        /// author: HVM(29/05/2020)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> Get(string storeName)
        {
            var entities = new List<T>();
            _sqlCommand.CommandText = storeName;
            // Thực hiện đọc dữ liệu:
            MySqlDataReader mySqlDataReader = _sqlCommand.ExecuteReader();
            while (mySqlDataReader.Read())
            {
                var entity = Activator.CreateInstance<T>();

                for (int i = 0; i < mySqlDataReader.FieldCount; i++)
                {
                    var columnName = mySqlDataReader.GetName(i);
                    var value = mySqlDataReader.GetValue(i);
                    var propertyInfo = entity.GetType().GetProperty(columnName);
                    if (propertyInfo != null && value != DBNull.Value)
                        propertyInfo.SetValue(entity, value);
                }
                entities.Add(entity);
            }
            // 1. Kết nối với Database:
            // 2. Thực thi command lấy dữ liệu:
            // Trả về:
            return entities;
        }

        public object Get(string storeName, string code)
        {
            _sqlCommand.Parameters.Clear();
            _sqlCommand.CommandText = storeName;
            _sqlCommand.Parameters.AddWithValue("@EmployeeCode", code);
            // Thực hiện đọc dữ liệu:
            return _sqlCommand.ExecuteScalar();
        }




        /// <summary>
        /// 
        /// lay dữ liệu của tất cả khach hang 
        /// author:HVM(16/10/2020)
        /// </summary>
        /// <returns>trả về danh sách các bản ghi</returns>
        public IEnumerable<T> Get()
        {
            var entities = new List<T>();
            var className = typeof(T).Name;
            _sqlCommand.CommandText = $"Proc_Get{className}";
            // Thực hiện đọc dữ liệu:
            MySqlDataReader mySqlDataReader = _sqlCommand.ExecuteReader();
            while (mySqlDataReader.Read())
            {
                var entity = Activator.CreateInstance<T>();
                //employee.EmployeeId = mySqlDataReader.GetGuid(0);
                //employee.EmployeeCode = mySqlDataReader.GetString(1);
                //employee.FullName = mySqlDataReader.GetString(2);

                for (int i = 0; i < mySqlDataReader.FieldCount; i++)
                {
                    var columnName = mySqlDataReader.GetName(i);
                    var value = mySqlDataReader.GetValue(i);
                    var propertyInfo = entity.GetType().GetProperty(columnName);
                    if (propertyInfo != null && value != DBNull.Value)
                        propertyInfo.SetValue(entity, value);
                }
                entities.Add(entity);
            }
            // 1. Kết nối với Database:
            // 2. Thực thi command lấy dữ liệu:
            // Trả về:
            return entities;
        }
        /// <summary>
        /// 
        /// lay thong tin khach hang theo id
        /// author:HVM(16/10/2020)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetById(object id)
        {
            // lấy dữ liệu từ database;
            // khởi tạo thông tin kết nối
            //var customers = new List<Customer>();
            var className = typeof(T).Name;
            _sqlCommand.CommandText = $"Proc_Get{className}ID";
            _sqlCommand.Parameters.AddWithValue($"@{className}ID", id);
            // thực hiện đọc dữ liệu

            MySqlDataReader reader = _sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                var entity = Activator.CreateInstance<T>();

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    var columnName = reader.GetName(i);
                    var value = reader.GetValue(i);
                    var propertyInfo = entity.GetType().GetProperty(columnName);
                    if (propertyInfo != null && value != DBNull.Value)
                    {
                        propertyInfo.SetValue(entity, value);
                    }

                }


                return entity;

            }
            // 1 kết nối database
            //2 thực thi câu lệnh
            // trả về dữ liệu

            return default;
        }
        /// <summary>
        /// lấy ra code lớn nhất
        /// </summary>
        /// <returns></returns>
        public string GetbyCode()
        {
           
            var className = typeof(T).Name;
            _sqlCommand.CommandText = $"Proc_Get{className}CodeEnd";
            // thực hiện đọc dữ liệu
            var scalar = _sqlCommand.ExecuteScalar();
                return scalar.ToString();

            }
            
        /// <summary>
        /// Them mơi 1 bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ///  HVM (17/10/2020)
        public int Insert(T entity)
        {
            var entityName = typeof(T).Name;
            _sqlCommand.Parameters.Clear();
            _sqlCommand.CommandText = $"Proc_Insert{entityName}";
            MySqlCommandBuilder.DeriveParameters(_sqlCommand);
            var parameters = _sqlCommand.Parameters;
            var properties = typeof(T).GetProperties();
            // Cách 1:
            //foreach (var property in properties)
            //{
            //    var propertyName = property.Name;
            //    var propertyValue = property.GetValue(entity);
            //    foreach (MySqlParameter param in parameters)
            //    {
            //        var paramName = param.ParameterName;
            //        if (paramName == $"@{propertyName}")
            //            param.Value = propertyValue;
            //    }
            //}

            // Cách 2:
            foreach (MySqlParameter param in parameters)
            {
                var paramName = param.ParameterName.Replace("@", string.Empty);
                var property = entity.GetType().GetProperty(paramName);
                //var property = entity.GetType().GetProperty(paramName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (property != null)
                    param.Value = property.GetValue(entity);
            }
            var affectRows = _sqlCommand.ExecuteNonQuery();
            return affectRows;
        }
        /// <summary>
        /// Hàm update bản ghi
        /// </summary>
        /// <param name="entity">truyền vào 1 đối tượng</param>
        /// <returns> số bản ghi bị cập nhật</returns>
        ///  HVM (17/10/2020)
        public int Update(T entity,object id)
        {
            // lấy dữ liệu từ database;
            // khởi tạo thông tin kết nối
            //var customers = new List<Customer>();
            var entityName = typeof(T).Name;
            //_sqlCommand.Parameters.Clear();
            _sqlCommand.CommandText = $"Proc_Update{entityName}";
            _sqlCommand.Parameters.AddWithValue($"@{entityName}ID", id);
            MySqlCommandBuilder.DeriveParameters(_sqlCommand);
            var parameters = _sqlCommand.Parameters;
            var properties = typeof(T).GetProperties();
            foreach (MySqlParameter param in parameters)
            {
                var paramName = param.ParameterName.Replace("@", string.Empty);
               
                var property = entity.GetType().GetProperty(paramName);

                //var property = entity.GetType().GetProperty(paramName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (paramName == $"{entityName}ID")
                    param.Value = id;
                else if (property != null)
                    param.Value = property.GetValue(entity);
            }
            var affectRows = _sqlCommand.ExecuteNonQuery();
            return affectRows;
        }
        /// <summary>
        /// Hàm xóa bản ghi theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// HVM (17/10/2020)
        public int DeleteId(object id)
        {
            var entityName = typeof(T).Name;
            _sqlCommand.CommandText = $"Proc_Delete{entityName}ID";
            //_sqlCommand.Parameters.AddWithValue($"@{entityName}Id", id);
            MySqlCommandBuilder.DeriveParameters(_sqlCommand);
            if (_sqlCommand.Parameters.Count > 0)
            {
                _sqlCommand.Parameters[0].Value = id;
            }
            var affectRows = _sqlCommand.ExecuteNonQuery();
            return affectRows;
        }
        #endregion
        /// <summary>
        /// hàm đóng kết nối 
        /// </summary>
        /// HVM(16/10/2020)
        public void Dispose()
        {
            _sqlConnection.Close();
        }

       
    }

    

}
