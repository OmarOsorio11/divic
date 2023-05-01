using COMMON.DTO;
using COMMON.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL.MySQL
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseDTO
    {
        private DBMySQL db;
        private bool idIsAutonumerico;
        private AbstractValidator<T> validator;

        public GenericRepository(AbstractValidator<T> validator, bool idIsAutonumerico = true)
        {
            this.validator = validator;
            this.idIsAutonumerico = idIsAutonumerico;
            db = new DBMySQL();
            Error = "";
        }

        public string Error { get; private set; }

        public bool Resultado { get; private set; }


        public bool Create(T entity)
        {
            ValidationResult resultadoDeValidacion = validator.Validate(entity);
            if (resultadoDeValidacion.IsValid)
            {
                string sql1 = "INSERT INTO divic_data." + typeof(T).Name + " (";
                string sql2 = ") VALUES (";
                var campos = typeof(T).GetProperties();
                T dato = (T)Activator.CreateInstance(typeof(T));
                Type Ttypo = typeof(T);
                for (int i = 0; i < campos.Length; i++)
                {
                    if (idIsAutonumerico && i == 0)
                    {
                        continue;
                    }
                    sql1 += " " + campos[i].Name;
                    var propiedad = Ttypo.GetProperty(campos[i].Name);
                    var valor = propiedad.GetValue(entity);
                    switch (propiedad.PropertyType.Name)
                    {
                        case "String":
                            sql2 += "'" + valor + "'";
                            break;
                        case "DateTime":
                            DateTime v = (DateTime)valor;
                            sql2 += string.Format($"'{v.Year}-{v.Month}-{v.Day} {v.Hour}:{v.Minute}:00'");
                            break;
                        default:
                            sql2 += " " + valor;
                            break;
                    }
                    if (i != (campos.Length - 1))
                    {
                        sql1 += " ,";
                        sql2 += " ,";
                    }
                }
                return EjecutaComando(sql1 + sql2 + " );");
            }
            else
            {
                Error = "Error de validación";
                foreach (var item in resultadoDeValidacion.Errors)
                {
                    Error += item.ErrorMessage + ". ";
                }
                return false;
            }
        }


        public IEnumerable<T> Read
        {
            get
            {
                try
                {
                    string sql = string.Format("SELECT * FROM divic_data.{0};", typeof(T).Name);
                    MySqlDataReader r = (MySqlDataReader)db.Consulta(sql);
                    List<T> datos = new List<T>();
                    var campos = typeof(T).GetProperties();
                    T dato;
                    Type Ttypo = typeof(T);
                    while (r.Read())
                    {
                        dato = (T)Activator.CreateInstance(Ttypo);
                        for (int i = 0; i < campos.Length; i++)
                        {
                            PropertyInfo prop = Ttypo.GetProperty(campos[i].Name);
                            prop.SetValue(dato, r[i]);
                        }
                        datos.Add(dato);
                    }
                    r.Close();
                    Error = "";
                    return datos;
                }
                catch (Exception ex)
                {
                    Error = ex.Message;
                    return null;
                }
            }
        }

        public bool Update(T entidad)
        {
            try
            {
                string sql1 = "UPDATE divic_data." + typeof(T).Name + " SET ";
                string sql2 = " WHERE ";
                string sql = "";
                var campos = typeof(T).GetProperties();
                T dato = (T)Activator.CreateInstance(typeof(T));
                Type Ttypo = typeof(T);
                for (int i = 0; i < campos.Length; i++)
                {
                    var propiedad = Ttypo.GetProperty(campos[i].Name);
                    var valor = propiedad.GetValue(entidad);
                    sql += propiedad.Name + "=";
                    switch (propiedad.PropertyType.Name)
                    {
                        case "String":
                            sql += "'" + valor + "'";
                            break;
                        case "DateTime":
                            DateTime v = (DateTime)valor;
                            sql += string.Format($"'{v.Year}-{v.Month}-{v.Date} {v.Hour}:{v.Minute}:00'");
                            break;
                        default:
                            sql += " " + valor;
                            break;
                    }
                    if (i == 0)
                    {
                        sql2 += sql;
                    }
                    if (i != campos.Length - 1)
                    {
                        sql += " ,";
                    }
                    sql1 += sql;
                    sql = "";
                }
                if (db.Comando(sql1 + sql2))
                {
                    Error = "";
                    return true;
                }
                else
                {
                    Error = db.Error;
                    return false;
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var campos = typeof(T).GetProperties();
                Type Ttypo = typeof(T);

                string sql = string.Format("DELETE FROM divic_data.{0} WHERE {1} = ", typeof(T).Name, campos[0].Name);

                switch (Ttypo.GetProperty(campos[0].Name).PropertyType.Name)
                {
                    case "String":
                        sql += "'" + id + "'";
                        break;
                    default:
                        sql += " " + id;
                        break;
                }
                if (db.Comando(sql + ";"))
                {
                    Error = "";
                    return true;
                }
                else
                {
                    Error = db.Error;
                    return false;
                }

            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }

        public T SearchById(int id)
        {
            try
            {
                var campos = typeof(T).GetProperties();
                Type Ttypo = typeof(T);

                string sql = string.Format("SELECT * FROM divic_data.{0} WHERE {1} =", typeof(T).Name, campos[0].Name);

                switch (Ttypo.GetProperty(campos[0].Name).PropertyType.Name)
                {
                    case "String":
                        sql += "'" + id + "'";
                        break;
                    default:
                        sql += " " + id;
                        break;
                }


                MySqlDataReader r = (MySqlDataReader)db.Consulta(sql);
                T dato = (T)Activator.CreateInstance(typeof(T));
                int j = 0;
                while (r.Read())
                {
                    dato = (T)Activator.CreateInstance(typeof(T));
                    for (int i = 0; i < campos.Length; i++)
                    {
                        PropertyInfo prop = Ttypo.GetProperty(campos[i].Name);
                        prop.SetValue(dato, r[i]);
                    }
                    j++;
                }
                r.Close();
                if (j > 0)
                {
                    Error = "";
                    return dato;
                }
                else
                {
                    Error = "Id no existe...";
                    return null;
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return null;
            }
        }

        private bool EjecutaComando(string sql)
        {
            if (db.Comando(sql))
            {
                Error = "";
                return true;
            }
            else
            {
                Error = db.Error;
                return false;
            }
        }

        public IEnumerable<T> Query(string query)
        {
            try
            {
                MySqlDataReader r = (MySqlDataReader)db.Consulta(query);
                List<T> datos = new List<T>();
                var campos = typeof(T).GetProperties();
                T dato;
                Type Ttypo = typeof(T);
                while (r.Read())
                {
                    dato = (T)Activator.CreateInstance(Ttypo);
                    for (int i = 0; i < campos.Length; i++)
                    {
                        PropertyInfo prop = Ttypo.GetProperty(campos[i].Name);
                        prop.SetValue(dato, r[i]);
                    }
                    datos.Add(dato);
                }
                r.Close();
                Error = "";
                return datos;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return null;
            }
        }
    }
}
